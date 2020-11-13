using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomInstall2
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
            DebugPrint("Commit", "Installer1");
        }
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            DebugPrint("Install", "Installer1");
        }
        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
            DebugPrint("Rollback", "Installer1");
        }
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            DebugPrint("Uninstall", "Installer1");

        }
        protected override void OnAfterInstall(IDictionary savedState)
        {
            base.OnAfterInstall(savedState);
            DebugPrint("OnAfterInstall", "Installer1");
        }
        protected override void OnAfterRollback(IDictionary savedState)
        {
            base.OnAfterRollback(savedState);
            DebugPrint("OnAfterRollback", "Installer1");
        }
        protected override void OnAfterUninstall(IDictionary savedState)
        {
            base.OnAfterUninstall(savedState);
            DebugPrint("OnAfterUninstall", "Installer1");
        }
        protected override void OnBeforeInstall(IDictionary savedState)
        {
            base.OnBeforeInstall(savedState);
            DebugPrint("OnBeforeInstall", "Installer1");
        }
        protected override void OnBeforeRollback(IDictionary savedState)
        {
            base.OnBeforeRollback(savedState);
            DebugPrint("OnBeforeRollback", "Installer1");
        }
        protected override void OnBeforeUninstall(IDictionary savedState)
        {
            base.OnBeforeUninstall(savedState);
            DebugPrint("OnBeforeUninstall", "Installer1");
        }
        protected override void OnCommitted(IDictionary savedState)
        {
            base.OnCommitted(savedState);
            DebugPrint("OnCommitted", "Installer1");
        }
        protected override void OnCommitting(IDictionary savedState)
        {
            base.OnCommitting(savedState);
            DebugPrint("OnCommitting", "Installer1");
        }

        private void DebugPrint(string caption, string title)
        {
            MessageBox.Show(caption, title);

        }
    }
}
