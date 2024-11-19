using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsRadius.Model
{
    /// <summary>
    /// 移動參數類別
    /// </summary>
    internal class MoveArgs
    {
        internal int X { get; set; }
        internal int Y { get; set; }
        internal bool IsMoving { get; set; }
    }
}
