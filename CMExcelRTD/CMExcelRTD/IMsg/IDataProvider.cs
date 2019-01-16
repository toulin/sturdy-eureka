using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMExcelRTD
{ 
    /// <summary>
    /// 泛型-個股資訊
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRTD_DataProvider
    {          
        void SubComm(string CommID);
        void DisSubComm(string CommID);
        /// <summary>
        /// 提供個股指定的屬性資料
        /// </summary>
        /// <param name="CommID"></param>
        /// <param name="PropertyName"></param>
        /// <returns></returns>
        object GetRTCommProperty(string CommID,string PropertyName);
        //資料有變化的個股
        List<string> ChangedComms();
        ///// <summary>
        ///// 設定個股資訊已存放好
        ///// </summary>
        ///// <param name="CommID"></param>
        //void SetReady(string CommID);
    }     
}
