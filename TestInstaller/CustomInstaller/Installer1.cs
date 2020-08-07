using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomInstaller
{
    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {
        public Installer1()
        {
            InitializeComponent();
        }

        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
            DebugPrint("Commit", "MyCustomInstaller");
        }
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            DebugPrint("Install", "MyCustomInstaller");
        }
        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
            DebugPrint("Rollback", "MyCustomInstaller");
        }
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            DebugPrint("Uninstall", "MyCustomInstaller");

        }
        protected override void OnAfterInstall(IDictionary savedState)
        {
            base.OnAfterInstall(savedState);
            DebugPrint("OnAfterInstall", "MyCustomInstaller");
        }
        protected override void OnAfterRollback(IDictionary savedState)
        {
            base.OnAfterRollback(savedState);
            DebugPrint("OnAfterRollback", "MyCustomInstaller");
        }
        protected override void OnAfterUninstall(IDictionary savedState)
        {
            base.OnAfterUninstall(savedState);
            DebugPrint("OnAfterUninstall", "MyCustomInstaller");
        }
        protected override void OnBeforeInstall(IDictionary savedState)
        {
            base.OnBeforeInstall(savedState);
            DebugPrint("OnBeforeInstall", "MyCustomInstaller");
        }
        protected override void OnBeforeRollback(IDictionary savedState)
        {
            base.OnBeforeRollback(savedState);
            DebugPrint("OnBeforeRollback", "MyCustomInstaller");
        }
        protected override void OnBeforeUninstall(IDictionary savedState)
        {
            base.OnBeforeUninstall(savedState);
            DebugPrint("OnBeforeUninstall", "MyCustomInstaller");
        }
        protected override void OnCommitted(IDictionary savedState)
        {
            base.OnCommitted(savedState);
            DebugPrint("OnCommitted", "MyCustomInstaller");
        }
        protected override void OnCommitting(IDictionary savedState)
        {
            base.OnCommitting(savedState);
            DebugPrint("OnCommitting", "MyCustomInstaller");
        }

        private void DebugPrint(string caption, string title)
        {
            MessageBox.Show(caption, title);

        }
    }
}
