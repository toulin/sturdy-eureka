using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CMExcelRTD
{
    public class LoginResult : ResponseBase
    {
        //{" "ResponseCode":2,"ResponseMsg":"密碼錯誤"}
        public string Guid { get; set; }
        public string AuthToken { get; set; }
        public string MemberPk { get; set; }
    }
    public class ResponseError
    {
        //{"error":{"Code":101,"Message":"Auth Failed"}}
        public string Code { get; set; }
        public string Message { get; set; }
    }

    public class ResponseBase
    {
        public bool IsSuccess { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMsg { get; set; }
        public ResponseError Error { get; set; }
    }

    public class PriceData : ResponseBase
    {
        public bool IsCloseMarket { get; set; }
        /// <summary>
        /// 最後交易的市場時間
        /// </summary>
        public int? MarketTime { get; set; }
        /// <summary>
        /// Polling狀態碼
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// 1:完整資訊 2:價格資訊 3:五檔資訊
        /// </summary>
        public int PackageDataType { get; set; }
        public string Commkey { get; set; }
        /// <summary>
        /// 開盤價
        /// </summary>
        public double? OpenPrice { get; set; }
        /// <summary>
        /// 最高價
        /// </summary>
        public double? CeilingPrice { get; set; }
        /// <summary>
        /// 最低價
        /// </summary>
        public double? LowestPrice { get; set; }
        /// <summary>
        /// 收盤價
        /// </summary>
        public double? ClosePrice { get; set; }
        /// <summary>
        /// 昨日收盤價
        /// </summary>
        public double? PrevClose { get; set; }
        /// <summary>
        /// 漲跌值
        /// </summary>
        public double? PriceChange { get; set; }
        /// <summary>
        /// 漲跌幅
        /// </summary>
        public double? QuoteChange { get; set; }
        /// <summary>
        /// 參考價
        /// </summary>
        public double? RefPrice { get; set; }
        /// <summary>
        /// 單量
        /// </summary>
        public int? TickQty { get; set; }
        /// <summary>
        /// 今日總量
        /// </summary>
        public int? TotalQty { get; set; }
        /// <summary>
        /// 外盤總量
        /// </summary>
        public int? AskQty { get; set; }
        /// <summary>
        /// 內盤總量
        /// </summary>
        public int? BidQty { get; set; }
        /// <summary>
        /// 該檔今日漲停價
        /// </summary>
        public double? LimitDown { get; set; }
        /// <summary>
        /// 該檔今日跌停價
        /// </summary>
        public double? LimitUp { get; set; }
        #region 五檔
        public double?[] BuyPr { get; set; }
        public int?[] BuyQty { get; set; }
        public double?[] SellPr { get; set; }
        public int?[] SellQty { get; set; }
        #endregion
    }
    public class CommSataus
    {
        /// <summary>
        /// 上一次從API接收的回傳值
        /// </summary>
        private string PrevResultAPI;
        /// <summary>
        /// 是否有新值異動(1:完整資料, 2:價格資訊 3:五檔資訊)
        /// </summary>
        private PackageDataType f_ChangedPackageType;
        private int f_SubCount = 0;
        private PriceData f_CommData;

        public CommSataus()
        {
            f_SubCount = 1;
            f_ChangedPackageType = PackageDataType.None;
        }
        public int PollingStatus
        {
            get
            {
                if (f_CommData == null)
                    return 0;
                return f_CommData.StatusCode;
            }            
        }
        /// <summary>
        /// 呼叫API後的回傳值
        /// </summary>
        public string ResultAPI
        {
            get
            {
                return PrevResultAPI;
            }
            set
            {
                //設定的同時,將result解析
                PriceData data = JsonConvert.DeserializeObject<PriceData>(value);
                if (data != null && data.IsSuccess)
                {
                    f_ChangedPackageType =(PackageDataType) data.PackageDataType;
                    f_CommData = data;
                    PrevResultAPI = value;
                }
            }
        }

        /// <summary>
        /// 是否正在忙碌中(呼叫API中)
        /// </summary>
        public bool IsBusy { get; set; }
        /// <summary>
        /// 註冊次數
        /// </summary>
        public int SubCount
        {
            get { return f_SubCount; }
            set { f_SubCount = value; }
        }

        public PriceData CommData
        {
            get
            {
                return f_CommData;
            }
        }
        /// <summary>
        /// 資料異動的類型 (0:沒有異動 1:完整資料 2:價格資訊)
        /// </summary>
        public PackageDataType ChangedPackageType
        {
            get { return f_ChangedPackageType; }
            set { f_ChangedPackageType = value; }
        }
         
    }
    public enum PackageDataType
    {
        None=0,
        FullData=1,
        PriceData=2,
        FiveData=3,
        Ready=99
    }
}
