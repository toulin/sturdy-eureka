using Microsoft.Win32;
using NetOffice.ExcelApi;
using NetOffice.ExcelApi.Enums;
using NetOffice.ExcelApi.Tools;
using NetOffice.OfficeApi;
using NetOffice.Tools;
using NetOffice.Tools.Native;
using NetOffice.VBIDEApi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Excel = NetOffice.ExcelApi;

namespace ExcelAddin2023TEST
{
    //[ComVisible(true)]
    //[CustomUI("RibbonUI.xml", true), RegistryLocation(RegistrySaveLocation.CurrentUser)]
    [COMAddin("ExcelAddin2023TEST", "Addin description.", LoadBehavior.LoadAtStartup)]
    [ProgId("ExcelAddin2023TEST.Addin")]    
    [Guid("4011D6D3-D064-491F-8A81-FDA5EBBF1AF6")]
    [RegistryLocation(RegistrySaveLocation.CurrentUser)]
    public class Addin : COMAddin
    {
        //private  Excel.Application ExcelApplication;

        private const string REGISTRY_KEY = @"Software\Microsoft\Office\Excel\AddIns\";
        private  static readonly string ProgID= "ExcelAddin2023TEST.Addin";
        private static readonly string FriendlyName = "ExcelAddin2023TEST";
        private static readonly string Description = "Addin description.";
        private static MyLog.ILog Log = new MyLog.MyLog("ExcelAddin2023Test");

        public Addin()
        {
            this.OnConnection += MyAddin_OnConnection;
            this.OnStartupComplete += MyAddin_OnStartupComplete;            
        }

        private void MyAddin_OnStartupComplete(ref Array custom)
        {
            try
            {
                // 創建一個新的工具列
                var toolbar = this.Application.CommandBars.Add("MyToolbar", NetOffice.OfficeApi.Enums.MsoBarPosition.msoBarTop, false, true);
                toolbar.Visible = true;

                // 創建一個新的按鈕，並添加到工具列上
                var button = (CommandBarButton)toolbar.Controls.Add(1);
                button.FaceId = 9;
                button.Style = NetOffice.OfficeApi.Enums.MsoButtonStyle.msoButtonIconAndCaption;
                button.Caption = "ExcelAddin2023Test2";
                button.Tag = "ExcelAddin2023Test";
                button.ClickEvent += new CommandBarButton_ClickEventHandler(Button_ClickEvent);
            }
            catch (Exception exception)
            {
                Log.Log(new Exception("MyAddin_OnStartupComplete", exception));
            }
        }

        private void Button_ClickEvent(CommandBarButton ctrl, ref bool cancelDefault)
        {
            Log.Log("Button_ClickEvent - Hello World");
            DoSomething();


        }
        public void DoSomething()
        {
            try
            {
                Excel.Worksheet workSheet = (Excel.Worksheet)this.Application.ActiveWorkbook.ActiveSheet;
                workSheet.Cells[1, 1].Value = "ExcelVersion";
                workSheet.Cells[1, 2].Value = this.Application.Version;
            }
            catch (Exception exception)
            {
                Log.Log(new Exception("Button_ClickEvent", exception));
            }
        }

        private void MyAddin_OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
        {
            try
            {
                //ExcelApplication = this.Application;

                this.Application.WorkbookOpenEvent += Application_WorkbookOpenEvent;
            }
            catch (Exception exception)
            {
                Log.Log(new Exception("MyAddin_OnConnection", exception));
            }
        }

        private void Application_WorkbookOpenEvent(Workbook workbook)
        {
            using (workbook)
            {
                // start working with the workbook
            }
        }

        [RegisterErrorHandler]
        public static void RegisterErrorHandler(RegisterErrorMethodKind methodKind, System.Exception exception)
        {
            Log.Log(new Exception($"ExcelAddin2023TEST.Addin-{methodKind}",exception));
        }

        [ComRegisterFunction]
        public static void Register(Type type)
        {
            // 註冊 COM Add-in 
            try
            {
                // add codebase value
                Assembly thisAssembly = Assembly.GetAssembly(type);
                RegistryKey key = Registry.ClassesRoot.CreateSubKey(@"CLSID\{" + type.GUID.ToString().ToUpper() + @"}\InprocServer32\\1.0.0.0");
                key.SetValue("CodeBase", thisAssembly.CodeBase);
                key.Close();

                Registry.ClassesRoot.CreateSubKey(@"CLSID\{" + type.GUID.ToString().ToUpper() + @"}\Programmable");

                // add bypass key
                // http://support.microsoft.com/kb/948461
                key = Registry.ClassesRoot.CreateSubKey(@"Interface\{000C0601-0000-0000-C000-000000000046}");
                string defaultValue = key.GetValue("") as string;
                if (null == defaultValue)
                    key.SetValue("", "Office .NET Framework Lockback Bypass Key");
                key.Close();

                // register addin in Excel
                RegistryKey regKeyExcel = Registry.CurrentUser.CreateSubKey(REGISTRY_KEY + ProgID);
                regKeyExcel.SetValue("LoadBehavior", Convert.ToInt32(3));
                regKeyExcel.SetValue("FriendlyName", FriendlyName);
                regKeyExcel.SetValue("Description", Description);
                regKeyExcel.Close();
            }
            catch (Exception ex)
            {
                Log.Log(new IOException("ExcelAddin-Registry", ex));
            }

        }

        [ComUnregisterFunction]
        public static void Unregister(Type type)
        {
            // 取消註冊 COM Add-in            
            try
            {
                // unregister addin
                Registry.ClassesRoot.DeleteSubKey(@"CLSID\{" + type.GUID.ToString().ToUpper() + @"}\Programmable", false);

                // unregister addin in office
                Registry.CurrentUser.DeleteSubKey(REGISTRY_KEY + ProgID, false);

            }
            catch (Exception ex)
            {
                Log.Log(new IOException("ExcelAddin-Registry", ex));
            }
        }
    }
}
