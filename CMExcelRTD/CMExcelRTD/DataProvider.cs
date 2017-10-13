using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Timers;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters; 

//要引用下列，才能找到 IRtdServer 界面
using Excel = Microsoft.Office.Interop.Excel;
using CMoney2.RTDRemoting;

namespace CMoneyRTD
{
    public class RemotingClient
    {  
        ICMRTD imsg; 
        public Delegate_Update Update_Event;
        Timer timer=new System.Timers.Timer();
        TcpChannel tcpChannel = null;
        object lockObj = new object();

        public RemotingClient()
        {
            int setup = 0;
            try
            {
                ////讀入 Remoting 設定檔
                //RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

                setup = 1;
                //透過Activator.GetObject取得指定 url 的 Remoting 物件, 並轉換該物件型別至RemotingLib.RemotingMsg
                //url中的IP與port, 要視 RemotingServer 的設定資訊, 進行調整
                imsg = (ICMRTD)Activator.GetObject(typeof(ICMRTD), "tcp://127.0.0.1:8791/CMoneyRTDRemoting");
                 
                setup = 5;

            }
            catch (Exception ex)
            {
                string msg = string.Format("RemotingClient({0}):{1};{2}", setup, ex.GetType().ToString(), ex.Message);
                System.Windows.Forms.MessageBox.Show(msg, "提示", System.Windows.Forms.MessageBoxButtons.OK);
            }
            finally
            {
                timer.Enabled = false;
                timer.Interval = 1;
                timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            }
        }
        #region 即時
        /// <summary> 有註冊的即時代號
        /// (key:股票代號 ,Item:註冊次數)
        /// </summary>
        private Dictionary<string, int> RTComms = new Dictionary<string, int>();
        public void SubComm(string commID)
        {
            try
            {
                imsg.SubComm(commID);
                if (RTComms.ContainsKey(commID))
                { RTComms[commID] += 1; }
                else
                { RTComms.Add(commID, 1); }
            }
            catch
            { } //遠端連線不存在時
        }
        public void DisSubComm(string commID)
        {
            try
            {
                imsg.DisSubComm(commID);
                if (RTComms.ContainsKey(commID))
                {
                    RTComms[commID] -= 1;
                    if (RTComms[commID] == 0)   //註冊次數歸0時,移除代號
                        RTComms.Remove(commID);
                }
            }
            catch
            { } //遠端連線不存在時
        }
        /// <summary>
        /// 移除註冊所有代號
        /// </summary>
        public void DisAllSubComm()
        {
            lock (lockObj)
            {
                timer.Stop();
                timer.Enabled = false;
                
                foreach (string key in RTComms.Keys.ToArray())
                {
                    int count = RTComms[key];
                    if (count <= 0) continue;
                    for (int i = 0; i < count; i++)
                        DisSubComm(key);
                }
            }
        }
        #endregion
        /// <summary>
        /// 對 Server 做 polling 的動作 (避免 Server 重啟)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DoWork()
        {
            try
            {
                //取得資料
                foreach (string id in CMGlobal.UpdateComm.Keys.ToArray())
                {
                    if (RTComms.Keys.Contains(id) == false)
                        CMGlobal.UpdateComm.Remove(id); //移除已被移除註冊的代號
                }

                string[,] InfoList = imsg.GetRTComm(RTComms.Keys.ToArray());
                if (InfoList != null)
                {                         
                    for (int row = 0; row < InfoList.GetLength(1); row++)
                    {
                        if (InfoList[0, row] == null || InfoList[0, row].Length == 0) continue;
                        string id = InfoList[0, row];
                        RtdCommInfo info = SToMyInfo(InfoList[1, row]);
                        info.Changed = true;
                        //嘗試加入判斷是否已接收 
                        if (CMGlobal.UpdateComm.ContainsKey(id))
                        {
                            if(CMGlobal.UpdateComm[id].HashCode!= info.HashCode)
                                CMGlobal.UpdateComm[id] = info;
                        }
                        else
                        {
                            CMGlobal.UpdateComm[id] = info;
                        }
                        
                    }
                    Update_Event();
                }
            }
            catch (Exception ex)
            {
                err = true;
                System.Windows.Forms.MessageBox.Show("將停止服務。" + ex.Message, "提示", System.Windows.Forms.MessageBoxButtons.OK);                
            }                       
        }
        #region timer
        bool err = false;  
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (err == true)
            {
                timer.Stop();
                timer.Enabled = false;
                return;
            }
            lock (lockObj)
            {
                timer.Stop();
                DoWork();

                timer.Start();
            }
        }
        public void StartWork()
        {
            timer.Enabled = true;
            timer.Start();
        }
        public void StopWork()
        {
            timer.Stop();
        }
        #endregion
        #region 反序列化
        /// <summary>
        /// 將字串反序列化為 RtdCommInfo
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public RtdCommInfo SToMyInfo(string s)
        {
            try
            {
                // 如果傳入的 s 字串不是有效的 XML 格式的話，會發生 Exception，記得要做好 Error Handling
                System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
                xdoc.LoadXml(s);
                System.Xml.XmlNodeReader reader = new System.Xml.XmlNodeReader(xdoc.DocumentElement);
                System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(RtdCommInfo));
                object obj = ser.Deserialize(reader);

                return obj as RtdCommInfo;
            }
            catch (Exception ex)
            {
                throw new Exception("無法反序列化:" + ex.Message);
            }
        }
        #endregion 
    }
}
