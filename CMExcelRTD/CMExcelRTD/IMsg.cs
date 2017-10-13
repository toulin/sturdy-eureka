using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*注意：RTD Sever上也要有一模一樣的介面(命名空間亦同)*/
namespace CMoney2.RTDRemoting
{
    public enum InOutType : byte { 內盤 = 0, 外盤 = 1 };

    public interface ICMRTD
    {
        DateTime GetServerStartUpTime();
        /* 目前各股最新即時資訊
         * 第一維度 資料 (股票代號,RTComm) ； 第二維度 列
        */
        string[,] GetRTComm(string[] comms);
        void SubComm(string CommID);
        void DisSubComm(string CommID);
        //event SendClose_DGate SendClose_Event;  //推測無法在RTD無法掛載Remoting事件
    }
    //[Serializable]
    public class RtdCommInfo : ICloneable
    {
        public RtdCommInfo() { }
        //public RtdCommInfo(string _name, ushort _CommNo)
        //{
        //    Name = _name;
        //    CommNo = _CommNo;
        //}
        #region 仿理財寶即時類別資訊[RTComm]
        public double BSRate { get; set; }
        public virtual uint BuyContract { get; set; }
        public virtual uint BuyNum { get; set; }
        public virtual double BuyPr { get; set; }
        public virtual uint BuyQty { get; set; }
        public virtual double BuyTotalAmt { get; set; }
        public virtual uint BuyTotalQty { get; set; }
        public double CeilPr { get; set; }
        public ushort CommNo { get; set; }
        public virtual double DealPr { get; set; }
        public virtual DateTime DealTime { get; set; }
        public virtual string DealTimeStr { get; set; }
        public double FloorPr { get; set; }
        public string ID { get; set; }
        public virtual short InOut { get; set; }
        public double InOutRate { get; set; }
        public virtual double InTotalAmt { get; set; }
        public virtual uint InTotalNum { get; set; }
        public virtual uint InTotalQty { get; set; }
        public virtual uint MatchBuyCnt { get; set; }
        public virtual uint MatchSellCnt { get; set; }
        public virtual double MaxPr { get; set; }
        public virtual double MinPr { get; set; }
        public string Name { get; set; }
        public virtual double OpenPr { get; set; }
        public virtual uint OpenQty { get; set; }
        public virtual double OutTotalAmt { get; set; }
        public virtual uint OutTotalNum { get; set; }
        public virtual uint OutTotalQty { get; set; }
        public double RefPr { get; set; }
        public virtual uint SellContract { get; set; }
        public virtual uint SellNum { get; set; }
        public virtual double SellPr { get; set; }
        public virtual uint SellQty { get; set; }
        public virtual double SellTotalAmt { get; set; }
        public virtual uint SellTotalQty { get; set; }
        public virtual uint StUnit { get; set; }
        public virtual double TarBuyPr { get; set; }
        public virtual uint TarBuyQty { get; set; }
        public virtual double TarCeilPr { get; set; }
        public virtual double TarDealPr { get; set; }
        public virtual double TarFloorPr { get; set; }
        public virtual string TarID { get; set; }
        public virtual string TarName { get; set; }
        public virtual double TarRefPr { get; set; }
        public virtual double TarSellPr { get; set; }
        public virtual uint TarSellQty { get; set; }
        public virtual long TarTickQty { get; set; }
        public virtual long TarTotalQty { get; set; }
        public virtual long TickQty { get; set; }
        public virtual long TotalQty { get; set; }
        public double UpDown { get; set; }
        public double UpDownRate { get; set; }
        #endregion

        public int HashCode { get; set; }
        public bool Changed { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    /// <summary>
    /// 成交明細項目
    /// </summary>
    public class DealItem : IComparable<DealItem>
    {
        public int Time;
        public DateTime TimeValue { get; set; }
        public string DispTime { get; set; }
        public string DispTime2 { get; set; }
        public double BuyPr { get; set; }
        public double SellPr { get; set; }
        public double DealPr { get; set; }
        public uint TickQty { get; set; }
        public uint TotalQty { get; set; }
        public uint MatchBuyCnt { get; set; }
        public uint MatchSellCnt { get; set; }
        public InOutType InOut { get; set; }
        public DealItem(int time, double buyPr, double sellPr, double dealPr, uint tickQty, uint totalQty, byte prFlag, uint matchBuyCnt, uint matchSellCnt)
        {
            Time = time;
            BuyPr = buyPr;
            SellPr = sellPr;
            DealPr = dealPr;
            TickQty = tickQty;
            TotalQty = totalQty;
            MatchBuyCnt = matchBuyCnt;
            MatchSellCnt = matchSellCnt;
            InOut = (InOutType)prFlag;
        }

        public void Assign(DealItem item)
        {
            Time = item.Time;
            BuyPr = item.BuyPr;
            SellPr = item.SellPr;
            DealPr = item.DealPr;
            TickQty = item.TickQty;
            TotalQty = item.TotalQty;
            InOut = item.InOut;
        }

        #region IComparable<DealItem> 成員

        public int CompareTo(DealItem other)
        {
            if (Time > other.Time) return 1;
            else if (Time < other.Time) return -1;
            else
            {
                if (TotalQty > other.TotalQty) return 1;
                else if (TotalQty < other.TotalQty) return -1;
                else return 0;
            }
        }
        #endregion
    }

}
