using NetOffice.ExcelApi;
using NetOffice.ExcelApi.Tools;
using NetOffice.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ExcelAddin2
{
    [ComVisible(true)]
    [Guid("632262fd-6bb7-4ea0-b7f5-a7a03d7241b2")]
    [ProgId("ExcelAddin2.MyAddin")]
    [COMAddin("MyAddin", "Addin description.", LoadBehavior.LoadAtStartup)]
    public class MyAddin : COMAddin
    {
        public MyAddin()
        {
            this.OnConnection += MyAddin_OnConnection;
        }

        private void MyAddin_OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
        {
            this.Application.WorkbookOpenEvent += Application_WorkbookOpenEvent;
        }

        private void Application_WorkbookOpenEvent(Workbook workbook)
        {
            using (workbook)
            {
                // start working with the workbook
            }
        }
    }
}
