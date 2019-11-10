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
using Microsoft.CSharp;

namespace InstallerProject1
{
    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {
        public Installer1()
        {
            InitializeComponent();

            string targetDir= this.Context.Parameters["targetdir"]; ;
            CreateShortcut(targetDir, "更新精靈", "CMExcel.exe", "CMExcel捷徑");
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
    }
}
