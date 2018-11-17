using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;

using System.IO;
using System.Diagnostics;

namespace Installer64COM
{
    [RunInstaller(true)]
    public partial class Installer : System.Configuration.Install.Installer
    {
        public Installer()
        {
            InitializeComponent();
        }
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
            Regasm(false);
        }
        protected override void OnAfterUninstall(IDictionary savedState)
        {
            base.OnAfterUninstall(savedState);
            Regasm(true);
        }
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            OnAfterUninstall(savedState);
        }

        /// <summary>
        /// 註冊與反註冊的動作
        /// </summary>
        /// <param name="mainName">dll主檔名</param>
        private void Regasm(bool unRegister)
        {
            string targetDir = this.Context.Parameters["targetDir"];
            string dll = Path.Combine(targetDir, "MyCom64.dll");
            string tlb = Path.Combine(targetDir, "MyCom64.tlb");
            string regasmPath = Path.Combine(Environment.GetEnvironmentVariable("windir"), @"Microsoft.NET\Framework64\v4.0.30319\regasm.exe");
            string parame = string.Format(@"""{0}"" /tlb: ""{1}"" /codebase", dll, tlb);
            if (unRegister)
                parame = string.Format(@"/unregister ""{0}""", regasmPath, dll);                 

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
    }
}
