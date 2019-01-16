using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Timers;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Concurrent;

//要引用下列，才能找到 IRtdServer 界面
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;

namespace CMExcelRTD
{ 
    public class DataAPI : IRTD_DataProvider
    {
        private const string API_ROOT_RUL = @"http://192.168.10.17/MobileService/ashx/";
        public Delegate_Update Update_Event;
        Timer timer=new System.Timers.Timer(); 
        object lockObj = new object();

        private ConcurrentDictionary<string, CommSataus> CommPollingState;
        private LoginResult TokenAuth;
        public DataAPI()
        {
            f_Clicnt = new HttpClient();
            CommPollingState = new ConcurrentDictionary<string, CommSataus>();
        } 
                      
        #region 實作
        public void SubComm(string commID)
        {
            CommPollingState.AddOrUpdate(commID, new CommSataus(),
                (commKey, polling) => { polling.SubCount += 1; return polling; });
        }
        public void DisSubComm(string commID)
        {
            CommSataus thisComm = CommPollingState[commID];
            if(CommPollingState[commID].SubCount > 0)
            {
                //移除註冊
                CommPollingState.TryRemove(commID, out thisComm);
            }
            else
            {
                CommPollingState[commID].SubCount -= 1;
            }
        }    
        public object GetRTCommProperty(string CommID, string PropertyName)
        {
            throw new NotImplementedException();
        }
        public List<string> ChangedComms()
        {
            List<string> result = new List<string>();
            var changed = CommPollingState.Where((o) => o.Value.ChangedPackageType != PackageDataType.None);
            if(changed !=null)
            {
                result.AddRange(changed.Select(o => o.Key));
            }
            return result;
        } 
        #endregion

        #region API Control
        HttpClient f_Clicnt;
        private LoginResult f_TokenAuth;
        async Task RequestToken()
        {
            string url = API_ROOT_RUL + @"LoginCheck/LoginCheck.ashx?";
            string arg = "Action=getloginguid&Account={0}&token=&Password={1}&AppId=2&Device=2&isNeedPush=false";
            string md5PW = CMoney2.Kernel.Util.GetMd5Hash("1234");

            url += string.Format(arg, "hawaii@cmoney.com.tw", md5PW);
            f_TokenAuth = JsonConvert.DeserializeObject<LoginResult>(await f_Clicnt.GetStringAsync(url));
        }
                
        async Task<string> Data_Async(string commkey)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            f_Clicnt = new HttpClient();
            string url = API_ROOT_RUL + @"InstantTrading/InstantTrading.ashx?";
            param["action"] = "getstockinstantdata";
            param["commkey"] = commkey;
            param["statusCodes"] = CommPollingState[commkey].PollingStatus.ToString();
            param["AppId"] = "2";
            param["Guid"] = TokenAuth.Guid;
            param["AuthToken"] = TokenAuth.AuthToken;

            url += param.ToUriParam();

            return await f_Clicnt.GetStringAsync(url);
        }        
        private async void CallData()
        {
            var tasks = CommPollingState.Keys.Select(async commKey =>
            {
                if (CommPollingState[commKey].IsBusy == false)
                {
                    CommPollingState[commKey].IsBusy = true;
                    // some pre stuff
                    var response = await Data_Async(commKey);
                    CommPollingState[commKey].ResultAPI = response;
                    CommPollingState[commKey].IsBusy = false;
                }
            });
            await Task.WhenAny(tasks);
            Update_Event();
        }        
        #endregion
        #region timer
        bool err = false;
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //TODO:待建立timer 
            if (err == true)
            {
                timer.Stop();
                timer.Enabled = false;
                return;
            }
            lock (lockObj)
            {
                timer.Stop();
                CallData();

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
    }
}
