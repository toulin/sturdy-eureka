using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Windows.Forms;
using NetOffice;
using NetOffice.Tools;
using Excel = NetOffice.ExcelApi;
using NetOffice.ExcelApi.Enums;
using NetOffice.ExcelApi.Tools;
using Office = NetOffice.OfficeApi;
using NetOffice.OfficeApi.Enums;
using NetOffice.OfficeApi.Tools;
using VBIDE = NetOffice.VBIDEApi;
using NetOffice.VBIDEApi.Enums;
using Microsoft.Win32;
using System.Reflection;
using System.Drawing;

namespace MyTry_NetOfficeAddin
{
    /*
        [COMAddin("DeploymentSample", "Deployment Example Addin in C#", 3)]
    [ProgId("DeploymentSample.Addin"), Guid("1bf185d4-76ee-46d9-b709-afd20f78943b")]
     */
    [COMAddin("ToulinTryNetOfficeAddin", "Assembly Description", 3), ProgId("ToulinTryNetOfficeAddin.Addin"), Guid("4EE8530A-70BA-4F03-9ADB-96D93E87DDC2")]
    [RegistryLocation(RegistrySaveLocation.CurrentUser)]
    public class Addin : NetOffice.ExcelApi.Tools.COMAddin, IDTExtensibility2
    {

        private static readonly string _addinOfficeRegistryKey = "Software\\Microsoft\\Office\\Excel\\AddIns\\";
        private static readonly string _progId = "ToulinTryNetOfficeAddin.Addin";
        private static readonly string _addinFriendlyName = "測試NetOffie取得ExcelVersion";
        private static readonly string _addinDescription = "測試NetOffie取得ExcelVersion";

        // gui elements
        private static readonly string _toolbarName = "取得ExcelVersion_ToolbarName";
        private static readonly string _toolbarButtonName = "取得ExcelVersion_ToolbarButtonName";
        private static readonly string _toolbarPopupName = "取得ExcelVersion_ToolbarPopupName ";
        private static readonly string _menuName = "取得ExcelVersion_MenuName";
        private static readonly string _menuButtonName = "取得ExcelVersion_MenuButtonName";
        private static readonly string _contextName = "取得ExcelVersion_ContextName";
        private static readonly string _contextMenuButtonName = "取得ExcelVersion_ContextMenuButtonName";

        Excel.Application _excelApplication;

        #region IDTExtensibility2 Members

        void IDTExtensibility2.OnConnection(object Application, ext_ConnectMode ConnectMode, object AddInInst, ref Array custom)
        {
            try
            {
                _excelApplication = new Excel.Application(null, Application);
            }
            catch (Exception exception)
            {
                string message = string.Format("An error occured.{0}{0}{1}", Environment.NewLine, exception.Message);
                MessageBox.Show(message, _progId, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void IDTExtensibility2.OnStartupComplete(ref Array custom)
        {
            try
            {
                CreateTemporaryUserInterface();
            }
            catch (Exception exception)
            {
                string message = string.Format("An error occured.{0}{0}{1}", Environment.NewLine, exception.Message);
                MessageBox.Show(message, _progId, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void IDTExtensibility2.OnDisconnection(ext_DisconnectMode RemoveMode, ref Array custom)
        {
            try
            {
                if (null != _excelApplication)
                    _excelApplication.Dispose();
            }
            catch (Exception exception)
            {
                string message = string.Format("An error occured.{0}{0}{1}", Environment.NewLine, exception.Message);
                MessageBox.Show(message, _progId, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void IDTExtensibility2.OnAddInsUpdate(ref Array custom)
        {

        }

        void IDTExtensibility2.OnBeginShutdown(ref Array custom)
        {

        }

        #endregion

        [RegisterErrorHandler]
        public static void RegisterErrorHandler(RegisterErrorMethodKind methodKind, System.Exception exception)
        {
            MessageBox.Show("An error occurend in " + methodKind.ToString(), "ToulinTryNetOfficeAddin");
        }



        #region COM Register Functions

        [ComRegisterFunctionAttribute]
        public static void RegisterFunction(Type type)
        {
            try
            {
                // add codebase value
                Assembly thisAssembly = Assembly.GetAssembly(typeof(Addin));
                RegistryKey key = Registry.ClassesRoot.CreateSubKey("CLSID\\{" + type.GUID.ToString().ToUpper() + "}\\InprocServer32\\1.0.0.0");
                key.SetValue("CodeBase", thisAssembly.CodeBase);
                key.Close();

                Registry.ClassesRoot.CreateSubKey(@"CLSID\{" + type.GUID.ToString().ToUpper() + @"}\Programmable");

                // add bypass key
                // http://support.microsoft.com/kb/948461
                key = Registry.ClassesRoot.CreateSubKey("Interface\\{000C0601-0000-0000-C000-000000000046}");
                string defaultValue = key.GetValue("") as string;
                if (null == defaultValue)
                    key.SetValue("", "Office .NET Framework Lockback Bypass Key");
                key.Close();

                // register addin in Excel
                RegistryKey regKeyExcel = Registry.CurrentUser.CreateSubKey(_addinOfficeRegistryKey + _progId);
                regKeyExcel.SetValue("LoadBehavior", Convert.ToInt32(3));
                regKeyExcel.SetValue("FriendlyName", _addinFriendlyName);
                regKeyExcel.SetValue("Description", _addinDescription);
                regKeyExcel.Close();
            }
            catch (Exception ex)
            {
                string details = string.Format("{1}{1}Details:{1}{1}{0}", ex.Message, Environment.NewLine);
                MessageBox.Show("An error occured." + details, "Register " + _progId, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [ComUnregisterFunctionAttribute]
        public static void UnregisterFunction(Type type)
        {
            try
            {
                // unregister addin
                Registry.ClassesRoot.DeleteSubKey(@"CLSID\{" + type.GUID.ToString().ToUpper() + @"}\Programmable", false);

                // unregister addin in office
                Registry.CurrentUser.DeleteSubKey(_addinOfficeRegistryKey + _progId, false);

            }
            catch (Exception throwedException)
            {
                string details = string.Format("{1}{1}Details:{1}{1}{0}", throwedException.Message, Environment.NewLine);
                MessageBox.Show("An error occured." + details, "Unregister" + _progId, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void CreateTemporaryUserInterface()
        {
            /*
            // How to: Add Commands to Shortcut Menus in Excel
            // http://msdn.microsoft.com/en-us/library/0batekf4.aspx            
            */

            /* create commandbar */
            Office.CommandBar commandBar = _excelApplication.CommandBars.Add(_toolbarName, MsoBarPosition.msoBarTop, System.Type.Missing, true);
            commandBar.Visible = true;

            // add popup to commandbar
            Office.CommandBarPopup commandBarPop = (Office.CommandBarPopup)commandBar.Controls.Add(MsoControlType.msoControlPopup, System.Type.Missing, System.Type.Missing, System.Type.Missing, true);
            commandBarPop.Caption = _toolbarPopupName;
            commandBarPop.Tag = _toolbarPopupName;

            // add a button to the popup
            Office.CommandBarButton commandBarBtn = (Office.CommandBarButton)commandBarPop.Controls.Add(MsoControlType.msoControlButton, System.Type.Missing, System.Type.Missing, System.Type.Missing, true);
            commandBarBtn.Style = MsoButtonStyle.msoButtonIconAndCaption;
            commandBarBtn.FaceId = 9;
            commandBarBtn.Caption = _toolbarButtonName;
            commandBarBtn.Tag = _toolbarButtonName;
            commandBarBtn.ClickEvent += new NetOffice.OfficeApi.CommandBarButton_ClickEventHandler(commandBarBtn_ClickEvent);

            /* create menu */
            commandBar = _excelApplication.CommandBars["Worksheet Menu Bar"];

            // add popup to menu bar
            commandBarPop = (Office.CommandBarPopup)commandBar.Controls.Add(MsoControlType.msoControlPopup, System.Type.Missing, System.Type.Missing, System.Type.Missing, true);
            commandBarPop.Caption = _menuName;
            commandBarPop.Tag = _menuName;

            // add a button to the popup
            commandBarBtn = (Office.CommandBarButton)commandBarPop.Controls.Add(MsoControlType.msoControlButton, System.Type.Missing, System.Type.Missing, System.Type.Missing, true);
            commandBarBtn.Style = MsoButtonStyle.msoButtonIconAndCaption;
            commandBarBtn.FaceId = 9;
            commandBarBtn.Caption = _menuButtonName;
            commandBarBtn.Tag = _menuButtonName;
            commandBarBtn.ClickEvent += new NetOffice.OfficeApi.CommandBarButton_ClickEventHandler(commandBarBtn_ClickEvent);

            /* create context menu */
            commandBarPop = (Office.CommandBarPopup)_excelApplication.CommandBars["Cell"].Controls.Add(MsoControlType.msoControlPopup, System.Type.Missing, System.Type.Missing, System.Type.Missing, true);
            commandBarPop.Caption = _contextName;
            commandBarPop.Tag = _contextName;

            // add a button to the popup
            commandBarBtn = (Office.CommandBarButton)commandBarPop.Controls.Add(MsoControlType.msoControlButton, System.Type.Missing, System.Type.Missing, System.Type.Missing, true);
            commandBarBtn.Style = MsoButtonStyle.msoButtonIconAndCaption;
            commandBarBtn.Caption = _contextMenuButtonName;
            commandBarBtn.Tag = _contextMenuButtonName;
            commandBarBtn.FaceId = 9;
            commandBarBtn.ClickEvent += new NetOffice.OfficeApi.CommandBarButton_ClickEventHandler(commandBarBtn_ClickEvent);
        }

        //private void RemoveUserInterface()
        //{
        //   // _excelApplication.CommandBars("Cell").Reset();
        //}

        #region UI Trigger

        /// <summary>
        /// Click event trigger from created buttons. incoming call comes from excel application thread.
        /// </summary>
        /// <param name="Ctrl"></param>
        /// <param name="CancelDefault"></param>
        private void commandBarBtn_ClickEvent(NetOffice.OfficeApi.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            try
            {
                Excel.Worksheet workSheet = (Excel.Worksheet)_excelApplication.ActiveWorkbook.ActiveSheet;
                workSheet.Cells[1, 1].Value = "ExcelVersion";
                workSheet.Cells[1, 2].Value = _excelApplication.Version;

                // create a utils instance, not need for but helpful to keep the lines of code low
                NetOffice.ExcelApi.Tools.CommonUtils utils = new NetOffice.ExcelApi.Tools.CommonUtils(_excelApplication);

                // draw back color and perform the BorderAround method
                workSheet.Range("$B2:$B5").Interior.Color = utils.Color.ToDouble(Color.DarkGreen);
                workSheet.Range("$B2:$B5").BorderAround(XlLineStyle.xlContinuous, NetOffice.ExcelApi.Enums.XlBorderWeight.xlMedium, NetOffice.ExcelApi.Enums.XlColorIndex.xlColorIndexAutomatic);

                MessageBox.Show(_excelApplication.Version, "ExcelVersion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Ctrl.Dispose();
            }
            catch (Exception exception)
            {
                string message = string.Format("An error occured.{0}{0}{1}", Environment.NewLine, exception.Message);
                MessageBox.Show(message, _progId, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}

