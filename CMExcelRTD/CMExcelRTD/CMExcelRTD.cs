using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using System.Configuration;
using System.Runtime.Remoting;
using System.Reflection;
using System.Diagnostics;

//要引用下列，才能找到 IRtdServer 界面
using Excel = Microsoft.Office.Interop.Excel;
//使用 InteropServices 擴展屬性
using System.Runtime.InteropServices; 

namespace CMExcelRTD
{
    public delegate void Delegate_Update();
    /// <summary>
    /// CMoney Real Tick RTD 伺服器    
    /// 主要與接收即時 Tick 的資料源進行執行緒進行同步，將收到的資料 透過 Excel.IRtdServer 的操作，傳遞給 Excel 進行更新
    /// </summary>
    [ProgId("CMExcelRTD")] //在Excel函數中，要輸入此 Server 的 Name，就是 ProgID
    [ComVisible(true), ClassInterface(ClassInterfaceType.None), Guid("5179E888-83C3-4F4A-9B83-4AF6ABD8E31A")]
    public class CMRTD : Excel.IRtdServer
    {
        /// <summary> 用來處理同步用的 
        /// Critical Section Lock
        /// </summary>
        private object fSyncLock = new object();
        private Excel.IRTDUpdateEvent fTargetUpdateEvent;
        private DataAPI f_Data;

        /// <summary>
        /// 記錄當前未執行的更新
        /// 每一個 Topic 都具有一個值，在 Excel 裡可視為是一個最小的取值單位，同樣的 Excel 欄公式會共用相同的 Topic 取值
        /// 一個 topic 只記最新的一筆，不記歷史過程，以減少更新率
        /// </summary>
        private Dictionary<int, object> fUpdateList;
        /// <summary>
        /// 記錄每個 Comm 所對應的 Topic資訊
        /// </summary>
        private Dictionary<string, List<CMoneyTopic>> fComm2TopicId;
        /// <summary>
        ///  記錄每個 TopicID 所對應的 Comm
        /// </summary>
        private Dictionary<int, string> fTopic2Comm = new Dictionary<int, string>();

        /// <summary>
        /// 記錄這個 RTD 元件是否具正常運作的功能
        /// </summary>
        private bool fIsWorking = false;

        #region 更新
        public void UpdateExcel(IRTD_DataProvider IRTD_Data)
        {
            lock (fSyncLock)
            {
                if (fIsWorking == false) return;
                if (fComm2TopicId != null)
                {
                    foreach(string id in IRTD_Data.GetChangedComms())
                    { 
                        foreach (CMoneyTopic topic in fComm2TopicId[id])
                        {
                            fUpdateList[topic.TopicID] = IRTD_Data.GetRTCommProperty(id, topic.PropertyName);
                        }
                    }                     
                }
                fTargetUpdateEvent.UpdateNotify();
            }
        }
        #endregion
        #region 實作 IRtdServer 成員

        /// <summary>
        /// 當 Excel 建立一個新的資料連接時，會給予一個 TopicId，它可以被多個 Excel cell 共用，表同一個資料，每次 Excel 判斷需要以新的連接來連結資料時就會呼叫這個函式
        /// 並以傳入的 TopicId 作為該連接的識別碼
        /// </summary>
        /// <param key="TopicID">資料連接識別碼</param>
        /// <param key="Strings">連接所夾帶的參數列，可以是變動的陣列</param>
        /// <param key="GetNewValues">MSDN:True to determine if new values are to be acquired</param>
        /// <returns>該連結的預設值</returns>
        object Microsoft.Office.Interop.Excel.IRtdServer.ConnectData(int TopicID, ref Array Strings, ref bool GetNewValues)
        {
            lock (fSyncLock)
            {
                try
                {
                    ////一個新的 Topic 進來，先解出與它相關聯的 commkey and column 設定，將關聯加到資料結構裡
                    string commID = Strings.GetValue(0).ToString();
                    if (commID.ToLower() == "version")
                        return "Ver：" + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion.ToString();
                    string pName = Strings.GetValue(1).ToString();  //屬性名稱 
                    f_Data.SubComm(commID);  //註冊即時代號
                    #region 建立關聯
                    List<CMoneyTopic> topicList = new List<CMoneyTopic>();
                    if (fComm2TopicId.ContainsKey(commID))
                        topicList = fComm2TopicId[commID]; //股票代號的關聯資料

                    int findTopic = (topicList.FindIndex(o => o.TopicID == TopicID));
                    if (findTopic == -1)
                        topicList.Add(new CMoneyTopic(TopicID, commID, pName));
                    fComm2TopicId[commID] = topicList;
                    //Topic
                    //string[] commIDs = commkey.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);  
                    fTopic2Comm[TopicID] = commID;
                    #endregion

                    if (f_Data.ChangedComms().Contains(commID)==false)
                    {
                        GetNewValues = false;
                        return commID + ":Not Ready";
                    }
                    //ColumnIndicater colIndex = (ColumnIndicater)int.Parse(Strings.GetValue(1).ToString());
                    //AddTopicIdIntoDataStructure(TopicID, commkey, colIndex);

                    //標回傳有用的值，如果有值就刷值，沒值也要刷個空白或問號的，所以來呼叫了就是會有新值刷回去 
                    GetNewValues = true;

                    return commID + ":Ready";
                }
                catch (Exception e)
                {
                    CMGlobal.addErr(e.Message);
                }
                CMGlobal.ShowErrMsg();
                //沒有正常取得的，目前就是給它一個問號，刷掉原本畫面上的資料
                return "?";
            }
        }

        /// <summary>
        /// 當 Excel 因為被修改而刪除一個無用的資料連接時，會呼叫本函式來通知，讓 RTD 可以除去無用的 TopicId，減少資料異動的維護
        /// </summary>
        /// <param key="TopicID">指定要刪除的資料連接</param>
        void Microsoft.Office.Interop.Excel.IRtdServer.DisconnectData(int TopicID)
        {
            lock (fSyncLock)
            {
                try
                {
                    //一個 Topic 不要了，移除關聯

                    if (fTopic2Comm.ContainsKey(TopicID))
                    {
                        string commkey = fTopic2Comm[TopicID];
                        if (fComm2TopicId.ContainsKey(commkey))
                        {
                            List<CMoneyTopic> topicList = fComm2TopicId[commkey]; //股票代號的關聯資料
                            topicList.RemoveAll(o => o.TopicID == TopicID);
                        }
                        f_Data.DisSubComm(commkey);  //移除註冊即時代號
                    }
                    fTopic2Comm.Remove(TopicID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("CmRealTickRtd[IRtdServer.DisconnectData] 發生例外：" + ex.Message + ", RTD 代號：" + TopicID.ToString());
                }
                CMGlobal.ShowErrMsg();
            }
        }

        /// <summary>
        /// 這裡是 Excel 用來判斷 RTD 回應是否正常的心跳函式，主動回予 1 表示正常， 0 表示不正常
        /// </summary>
        /// <returns>主動回予 1 表示正常， 0 表示不正常</returns>
        int Microsoft.Office.Interop.Excel.IRtdServer.Heartbeat()
        {
            if (fIsWorking)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 當 Excel 收到我們通知需要更新時，會呼叫本函式來取得更新的內容，更新資料以 TopicId 為單位形成二元陣列 Object[x,y] 
        /// x 為 TopicId， y 為值，這裡我預設兩個物件都是 string 型別
        /// </summary>
        /// <param key="TopicCount">更新筆數，就是回傳陣列的長度</param>
        /// <returns>更新資料陣列</returns>
        Array Microsoft.Office.Interop.Excel.IRtdServer.RefreshData(ref int TopicCount)
        {
            lock (fSyncLock)
            {
                try
                {
                    object[,] result = null;
                    #region 更新

                    //如果有任何的 Topic 需要 更新
                    if (fUpdateList.Count > 0)
                    {
                        result = new object[2, fUpdateList.Count];

                        int i = 0;
                        foreach (KeyValuePair<int, object> kv in fUpdateList)
                        {
                            result[0, i] = kv.Key;
                            result[1, i] = kv.Value;
                            i++;
                        }

                        TopicCount = fUpdateList.Count();
                        fUpdateList.Clear();
                        foreach (RtdCommInfo item in CMGlobal.UpdateComm.Values)
                            item.Changed = false;
                    }

                    //fProvider.OperateThreadLock(true);
                    #endregion                    
                    return result;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("CmRealTickRtd[IRtdServer.RefreshData] 發生例外：" + ex.Message + ", RTD 代號：" + fMyId.ToString());
                    MessageBox.Show("CmRealTickRtd[IRtdServer.RefreshData] 發生例外：" + ex.Message);
                    TopicCount = 0;

                    return null;
                }
            }
        }

        /// <summary>
        /// 當一個 RTD 被 Excel 建立時，會呼叫 RTD 的這個函式，將該 Excel 的通知物件傳入，以供 RTD 使用，當 RTD 要更新資料時，就需要呼叫它
        /// 我們可以在這個函式建立 RTD 的初始化動作
        /// </summary>
        /// <param key="CallbackObject"> Excel 更新通知物件</param>
        /// <returns> 主動回予 1 表示正常， 0 表示不正常 </returns>
        int Microsoft.Office.Interop.Excel.IRtdServer.ServerStart(Excel.IRTDUpdateEvent CallbackObject)
        {
            try
            {
                lock (fSyncLock)
                {
                    fIsWorking = true;
                    //接入 Excel 更新物件
                    fTargetUpdateEvent = CallbackObject;

                    fUpdateList = new Dictionary<int, object>();
                    fComm2TopicId = new Dictionary<string, List<CMoneyTopic>>();
                    f_Data = new DataProvider();
                    f_Data.Update_Event += new Delegate_Update(UpdateExcel);
                    f_Data.StartWork();
                    ////初始資料提供者，這時資料提供者應該要進行初始化資料的取得
                    //InitDataProvider();

                    //todo :這裡應該要檢查該有的都有了才回傳 1 不然還是要回 0
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("[CmRealTickRtd]無法正常啟動，錯誤訊息：" + ex.Message);
                return 0;
            }

            CMGlobal.ShowErrMsg();

            //MessageBox.Show("[CmRealTickRtd]服務啟動");
            return 1;
        }

        /// <summary>
        /// 當一個 RTD 被 Excel 棄用時，會呼叫 RTD 的這個函式，這時我們可以進行 RTD 資料釋放的動作
        /// </summary>
        void Microsoft.Office.Interop.Excel.IRtdServer.ServerTerminate()
        {
            lock (fSyncLock)
            {
                //fProvider.Dispose();
                fIsWorking = false;
                f_Data.DisAllSubComm();
                //清空資料結構
                fComm2TopicId.Clear();
                fTopic2Comm.Clear();
            }

            //MessageBox.Show("[CmRealTickRtd]服務終止");
        }

        #endregion
    }
}
