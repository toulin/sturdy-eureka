using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsRadius.Model;

namespace WindowsFormsRadius.Helper
{
    /// <summary>
    /// 自訂表單標題(具有拖曳功能)
    /// </summary>
    internal static class CustomFormTitleHelper
    {
        /// <summary>
        /// 自訂PanelControl為標頭，並且可以透過該控件拖曳表單
        /// </summary>
        /// <param name="panel"></param>
        internal static void CustomFormTitle(Form form, Panel panel, MoveArgs args)
        { 
            panel.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    args.X = e.X;
                    args.Y = e.Y;
                    args.IsMoving = true;
                }
            };
            panel.MouseMove += (s, e) =>
            {
                if (args.IsMoving)
                {
                    form.Location = new Point(form.Left + e.X - args.X, form.Top + e.Y - args.Y);
                }
            };
            panel.MouseUp += (s, e) =>
            {
                args.IsMoving = false;
            };
        }
    }
}
