using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Reflection;

namespace MyTry_NetOffice_Installer
{
    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {
        public Installer1()
        {
            InitializeComponent();
            //System.Diagnostics.Debugger.Launch();
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
            Regasm(false);

            //string targetDir = this.Context.Parameters["targetDir"];
            ////覆寫範本
            //prjoFileReplace repFile = new prjoFileReplace(targetDir,
            //"TemplatePPT", @"Output\WordTemplate",
            //@"Replace\PPT", @"Replace\Word");
            //repFile.ReplaceFile();

            ////***重建捷徑
            //string pgMenuFolder = Path.Combine(this.Context.Parameters["programMenuFolder"], "群益研究報告管理系統"); //所在程式集目錄
            ////桌面
            //CreateShortcut(this.Context.Parameters["desktopFolder"],
            //                "群益研究報告管理系統", Path.Combine(targetDir, "CMProjectLogin.exe"), "群益研究報告管理系統");
            ////程式集
            //CreateShortcut(pgMenuFolder,
            //                "群益研究報告管理系統", Path.Combine(targetDir, "CMProjectLogin.exe"), "群益研究報告管理系統");
            //CreateShortcut(pgMenuFolder,
            //                "帳號與股票權限管理工具", Path.Combine(targetDir, "CMoney2.ActManager.exe"), "帳號與股票權限管理工具");
            //CreateShortcut(pgMenuFolder,
            //                "群益研究報告產出模組", Path.Combine(targetDir, @"Output\CMoneyTradex.exe"), "群益研究報告產出模組");  
            //CreateShortcut(pgMenuFolder,
            //                "Word範本資料夾", Path.Combine(targetDir, @"Output\WordTemplate"), "Word範本資料夾");            
            //CreateShortcut(pgMenuFolder,
            //                "研究報告輸出資料夾", Path.Combine(targetDir, @"Output\WordOutput"), "研究報告輸出資料夾");            

            ////***


            //this.Committed += new InstallEventHandler(Installer1_Committed);
            //string allUsersString = this.Context.Parameters["allUsers"];            
            //OpenCloseFile();
        }
        protected override void OnAfterUninstall(IDictionary savedState)
        {
            base.OnAfterUninstall(savedState);
            Regasm(true);
            // string targetDir = this.Context.Parameters["targetDir"];


        }
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            OnAfterUninstall(savedState);

            //string targetDir = this.Context.Parameters["targetDir"];

        }

        //void Installer1_Committed(object sender, InstallEventArgs e)
        //{
        //    OpenCloseFile();
        //}

        /// <summary>
        /// 註冊與反註冊的動作
        /// </summary>
        /// <param name="mainName">dll主檔名</param>
        private void Regasm(bool unRegister)
        {
            string targetDir = this.Context.Parameters["targetDir"];
            string dll = Path.Combine(targetDir, "MyTry_NetOfficeAddin.dll");
            string tlb = Path.Combine(targetDir, "MyTry_NetOfficeAddin.tlb");
            string regasmPath = Path.Combine(Environment.GetEnvironmentVariable("windir"), @"Microsoft.NET\Framework\v3.5\regasm.exe");
            if (File.Exists(regasmPath) == false)
            { regasmPath = Path.Combine(Environment.GetEnvironmentVariable("windir"), @"Microsoft.NET\Framework\v4.0.30319\regasm.exe"); }

            string parame = string.Format(@"""{0}"" /tlb: ""{1}"" /codebase", dll, tlb);
            if (unRegister)
                parame = string.Format(@"-u ""{0}"" /codebase", regasmPath, dll);
            //parame = string.Format(@"/unregister ""{0}""", regasmPath, dll);

            try
            {
                if (File.Exists(regasmPath) == false)
                    throw new Exception("找不到檔案,請重新安裝.Net framework 4.0\r\n" + regasmPath);
                Process proc = new Process();
                proc.StartInfo.FileName = regasmPath;
                proc.StartInfo.Arguments = parame;
                proc.Start();
            }
            catch (Exception err)
            { throw new Exception(string.Format("{0} \r\n{1}\r\n{2}", err.Message, regasmPath, parame)); }
        }
        #region COM Register Functions

        //public  void RegisterFunction()
        //{
        //    try
        //    {
        //        string targetDir = this.Context.Parameters["targetDir"];
        //        string dll = Path.Combine(targetDir, "MyTry_NetOfficeAddin.dll");
        //        // add codebase value
        //        Assembly thisAssembly = Assembly.LoadFile(dll);
        //        Type type = thisAssembly.GetType();
        //        RegistryKey key = Registry.ClassesRoot.CreateSubKey("CLSID\\{" + type.GUID.ToString().ToUpper() + "}\\InprocServer32\\1.0.0.0");
        //        key.SetValue("CodeBase", thisAssembly.CodeBase);
        //        key.Close();

        //        Registry.ClassesRoot.CreateSubKey(@"CLSID\{" + type.GUID.ToString().ToUpper() + @"}\Programmable");

        //        // add bypass key
        //        // http://support.microsoft.com/kb/948461
        //        key = Registry.ClassesRoot.CreateSubKey("Interface\\{000C0601-0000-0000-C000-000000000046}");
        //        string defaultValue = key.GetValue("") as string;
        //        if (null == defaultValue)
        //            key.SetValue("", "Office .NET Framework Lockback Bypass Key");
        //        key.Close();

        //        // register addin in Excel
        //        RegistryKey regKeyExcel = Registry.CurrentUser.CreateSubKey(_addinOfficeRegistryKey + _progId);
        //        regKeyExcel.SetValue("LoadBehavior", Convert.ToInt32(3));
        //        regKeyExcel.SetValue("FriendlyName", _addinFriendlyName);
        //        regKeyExcel.SetValue("Description", _addinDescription);
        //        regKeyExcel.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        string details = string.Format("{1}{1}Details:{1}{1}{0}", ex.Message, Environment.NewLine);
        //        MessageBox.Show("An error occured." + details, "Register " + _progId, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //public  void UnregisterFunction()
        //{
        //    try
        //    {
        //        string targetDir = this.Context.Parameters["targetDir"];
        //        string dll = Path.Combine(targetDir, "MyTry_NetOfficeAddin.dll");
        //        Assembly thisAssembly = Assembly.LoadFile(dll);
        //        Type type = thisAssembly.GetType();
        //        // unregister addin
        //        Registry.ClassesRoot.DeleteSubKey(@"CLSID\{" + type.GUID.ToString().ToUpper() + @"}\Programmable", false);

        //        // unregister addin in office
        //        Registry.CurrentUser.DeleteSubKey(_addinOfficeRegistryKey + _progId, false);

        //    }
        //    catch (Exception throwedException)
        //    {
        //        string details = string.Format("{1}{1}Details:{1}{1}{0}", throwedException.Message, Environment.NewLine);
        //        MessageBox.Show("An error occured." + details, "Unregister" + _progId, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        #endregion
    }

}
