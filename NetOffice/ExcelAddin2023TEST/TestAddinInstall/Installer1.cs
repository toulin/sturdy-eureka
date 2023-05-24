using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TestAddinInstall
{
    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {
        private const string AssemblyName = "ExcelAddin2023TEST";


        public Installer1()
        {
            InitializeComponent();
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
            string targetDir = this.Context.Parameters["targetDir"];
            RegAsmAddin regAsmAddin = new RegAsmAddin( AssemblyName, targetDir, false);
            regAsmAddin.RegAsm(true);
            regAsmAddin.RegAsm(false);
        }
        protected override void OnAfterUninstall(IDictionary savedState)
        {
            base.OnAfterUninstall(savedState);

            string targetDir = this.Context.Parameters["targetDir"];
            RegAsmAddin regAsmAddin = new RegAsmAddin( AssemblyName, targetDir, true);
            regAsmAddin.RegAsm(true);
            regAsmAddin.RegAsm(false);
        }
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            OnAfterUninstall(savedState);
        }
    }
}
