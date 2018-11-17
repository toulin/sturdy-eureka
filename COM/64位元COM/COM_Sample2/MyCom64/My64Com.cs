using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Data.OleDb;


namespace MyCom64
{
    [ComVisible(true), InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("BAE36943-297A-4CD4-AB00-001B208E7041")]
    public interface IMy64Com
    {
        string version();   
    } 
    [ComVisible(true), ClassInterface(ClassInterfaceType.None), Guid("27B627AA-C60C-4B60-BE46-42C56556F285")]
    public class My64Com : IMy64Com
    {
        /// <summary>
        /// 版本
        /// </summary>
        private string MyVersion = ""; 

        public My64Com() 
        {
            MyVersion = "1.14.214.5"; 
        }
        #region 實作       
       
        /// <summary>
        /// 版本
        /// </summary>
        /// <returns></returns>
        public string version() { return MyVersion; }         
        #endregion

    }
}
