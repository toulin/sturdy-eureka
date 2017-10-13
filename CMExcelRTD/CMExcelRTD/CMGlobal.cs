using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
//using Microsoft.CSharp.RuntimeBinder;

//要引用下列，才能找到 IRtdServer 界面
using Excel = Microsoft.Office.Interop.Excel;

namespace CMExcelRTD
{
    public static class CMGlobal
    {
        //public static Excel.IRTDUpdateEvent updateEvent;
        ///// <summary> 股票代號對應接應的即時資料
        ///// 
        ///// </summary>
        //public static Dictionary<string, RtdCommInfo> UpdateComm = new Dictionary<string, RtdCommInfo>();
        public static object TryGetProperty(object obj, string propName)
        {
            Type objType = obj.GetType();
            PropertyInfo pi = objType.GetProperty(propName);
            if (pi == null)
                throw new ApplicationException(
                    "Property " + propName + " not found!");
            else
                return pi.GetValue(obj, null);
        }          
        #region 錯誤處理
        static List<string> msg = new List<string>();
        public static void addErr(string err)
        {
            if (msg.Contains(err)) return;  //排除重覆的錯誤訊息
            msg.Add(err);
        }
        public static bool ShowErrMsg()
        {
            if (msg.Count == 0) return false;
            MessageBox.Show(string.Join(Environment.NewLine, msg));
            msg.Clear();
            return true;
        }
        #endregion
    }
    public static class Extan
    {
        public static object TryGetProperty(object obj, string propName)
        {
            Type objType = obj.GetType();
            System.Reflection.PropertyInfo pi = objType.GetProperty(propName);
            if (pi == null)
                throw new ApplicationException(
                    "Property " + propName + " not found!");
            else
                return pi.GetValue(obj, null);
        }
        public static string ToUriParam(this Dictionary<string, string> obj)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string key in obj.Keys)
            {
                sb.Append(key + "=" + obj[key]);
                sb.Append("&");
            }
            return sb.ToString();
        }
    }
    
}
