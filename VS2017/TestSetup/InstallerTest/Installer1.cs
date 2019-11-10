using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using IWshRuntimeLibrary;
using System.Windows.Forms;

namespace InstallerTest
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
            string userChoose= this.Context.Parameters["customButton"];
            if (userChoose == "1")
            {
                string targetDir = this.Context.Parameters["targetdir"];
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                CreateShortcut(desktop, "更新精靈", Path.Combine(targetDir, "CMExcel.exe"), "CMExcel捷徑");
            }
        }
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState); 
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DelShortcut(desktop, "更新精靈");

        }
        private void CreateShortcut(string folder, string name, string target, string description)
        {
            string shortcutFullName = Path.Combine(folder, name + ".lnk");

            try
            {
                WshShell shell = new WshShell();
                IWshShortcut link = (IWshShortcut)shell.CreateShortcut(shortcutFullName);
                link.TargetPath = target;
                link.Description = description;
                link.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("The shortcut \"{0}\" could not be created.\n\n{1}", shortcutFullName, ex.ToString()),
                    "Create Shortcut", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DelShortcut(string folder, string name)
        {
            string shortcutFullName = Path.Combine(folder, name + ".lnk");

            try
            {
                if(System.IO.File.Exists(shortcutFullName))
                {
                    System.IO.File.Delete(shortcutFullName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("The shortcut \"{0}\" could not be delete.\n\n{1}", shortcutFullName, ex.ToString()),
                    "Create Shortcut", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
