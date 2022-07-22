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
    //https://docs.microsoft.com/zh-tw/dotnet/api/system.configuration.install.installeventargs.savedstate?view=netframework-4.8

    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {
        //public event InstallEventHandler AfterCommit;

        public Installer1()
        {
            InitializeComponent();
            //AfterCommit += new InstallEventHandler(AfterCommitHandler);
        }

        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
            DebugPrint(savedState, "Commit", "MyCustomInstaller");
            //OnAfterCommit(savedState);
        }
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            DebugPrint(stateSaver, "Install", "MyCustomInstaller");
        }
        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
            DebugPrint(savedState, "Rollback", "MyCustomInstaller");
        }
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            DebugPrint(savedState, "Uninstall", "MyCustomInstaller");

        }
        protected override void OnAfterInstall(IDictionary savedState)
        {
            base.OnAfterInstall(savedState);
            DebugPrint(savedState, "OnAfterInstall", "MyCustomInstaller");
        }
        protected override void OnAfterRollback(IDictionary savedState)
        {
            base.OnAfterRollback(savedState);
            DebugPrint(savedState,"OnAfterRollback", "MyCustomInstaller");
        }
        protected override void OnAfterUninstall(IDictionary savedState)
        {
            base.OnAfterUninstall(savedState);
            DebugPrint(savedState, "OnAfterUninstall", "MyCustomInstaller");
        }
        protected override void OnBeforeInstall(IDictionary savedState)
        {
            base.OnBeforeInstall(savedState);
            DebugPrint(savedState, "OnBeforeInstall", "MyCustomInstaller");
        }
        protected override void OnBeforeRollback(IDictionary savedState)
        {
            base.OnBeforeRollback(savedState);
            DebugPrint(savedState, "OnBeforeRollback", "MyCustomInstaller");
        }
        protected override void OnBeforeUninstall(IDictionary savedState)
        {
            base.OnBeforeUninstall(savedState);
            DebugPrint(savedState, "OnBeforeUninstall", "MyCustomInstaller");
        }
        protected override void OnCommitted(IDictionary savedState)
        {
            base.OnCommitted(savedState);
            DebugPrint(savedState, "OnCommitted", "MyCustomInstaller");
        }
        protected override void OnCommitting(IDictionary savedState)
        {
            base.OnCommitting(savedState);
            DebugPrint(savedState,"OnCommitting", "MyCustomInstaller");
        }

        private void DebugPrint(IDictionary savedState,string caption, string title)
        {
            if (savedState.Contains(title))
            {
                savedState[title] = caption;
            }
            else
            {
                savedState.Add(title, caption);
            }
            //MessageBox.Show(caption, title);
            this.Context.LogMessage("It's MyCustomInstaller");
            Console.WriteLine($"{title} - {caption}");

        }


        //protected virtual void OnAfterCommit(IDictionary savedState)
        //{
        //    if (AfterCommit != null)
        //        AfterCommit(this, new InstallEventArgs());
        //}

        //// A simple event handler to exemplify the example.
        //private void AfterCommitHandler(Object sender, InstallEventArgs e)
        //{
        //    Console.WriteLine("AfterCommitHandler event handler has been called\n");
        //}

    }
}
