using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsRadius.Model;

namespace WindowsFormsRadius
{
    public partial class SolFormB : Form
    {
        private MoveArgs MoveArg = new MoveArgs();
        public SolFormB()
        {
            InitializeComponent();
            Helper.CustomFormTitleHelper.CustomFormTitle(this, panel1, MoveArg);
        }



        private int radius = 15;//半径 
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            // base.OnPaintBackground(e);

            // 尽可能高质量绘制
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;

            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            var path = GetRoundedRectPath(rect, radius);

            this.Region = new Region(path);

            Color baseColor;
            //Color borderColor;
            //Color innerBorderColor = this._baseColor;//Color.FromArgb(200, 255, 255, 255); ;

            //switch (ControlState)
            //{
            //    case ControlState.Hover:
            //        baseColor = this._hoverColor;
            //        break;
            //    case ControlState.Pressed:
            //        baseColor = this._pressedColor;
            //        break;
            //    case ControlState.Normal:
            //        baseColor = this._normalColor;
            //        break;
            //    default:
            //        baseColor = this._normalColor;
            //        break;
            //}

            //using (SolidBrush b = new SolidBrush(Color.AliceBlue))
            //{
            //    e.Graphics.FillPath(b, path); // 填充路径，而不是DrawPath
            //    using (Brush brush = new SolidBrush(this.ForeColor))
            //    {
            //        // 文本布局对象
            //        using (StringFormat gs = new StringFormat())
            //        {
            //            // 文字布局
            //            switch (_textAlign)
            //            {
            //                case ContentAlignment.TopLeft:
            //                    gs.Alignment = StringAlignment.Near;
            //                    gs.LineAlignment = StringAlignment.Near;
            //                    break;
            //                case ContentAlignment.TopCenter:
            //                    gs.Alignment = StringAlignment.Center;
            //                    gs.LineAlignment = StringAlignment.Near;
            //                    break;
            //                case ContentAlignment.TopRight:
            //                    gs.Alignment = StringAlignment.Far;
            //                    gs.LineAlignment = StringAlignment.Near;
            //                    break;
            //                case ContentAlignment.MiddleLeft:
            //                    gs.Alignment = StringAlignment.Near;
            //                    gs.LineAlignment = StringAlignment.Center;
            //                    break;
            //                case ContentAlignment.MiddleCenter:
            //                    gs.Alignment = StringAlignment.Center; //居中
            //                    gs.LineAlignment = StringAlignment.Center;//垂直居中
            //                    break;
            //                case ContentAlignment.MiddleRight:
            //                    gs.Alignment = StringAlignment.Far;
            //                    gs.LineAlignment = StringAlignment.Center;
            //                    break;
            //                case ContentAlignment.BottomLeft:
            //                    gs.Alignment = StringAlignment.Near;
            //                    gs.LineAlignment = StringAlignment.Far;
            //                    break;
            //                case ContentAlignment.BottomCenter:
            //                    gs.Alignment = StringAlignment.Center;
            //                    gs.LineAlignment = StringAlignment.Far;
            //                    break;
            //                case ContentAlignment.BottomRight:
            //                    gs.Alignment = StringAlignment.Far;
            //                    gs.LineAlignment = StringAlignment.Far;
            //                    break;
            //                default:
            //                    gs.Alignment = StringAlignment.Center; //居中
            //                    gs.LineAlignment = StringAlignment.Center;//垂直居中
            //                    break;
            //            }
            //            // if (this.RightToLeft== RightToLeft.Yes)
            //            // {
            //            //     gs.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            //            // }  
            //            e.Graphics.DrawString(this.Text, this.Font, brush, rect, gs);
            //        }
            //    }
            //}
        }
        /// <summary>
        /// 根据矩形区域rect，计算呈现radius圆角的Graphics路径
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            #region 正确绘制圆角矩形区域
            int R = radius * 2;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(R, R));
            GraphicsPath path = new GraphicsPath();
            // 左上圆弧 左手坐标系，顺时针为正 从180开始，转90度
            path.AddArc(arcRect, 180, 90);
            // 右上圆弧
            arcRect.X = rect.Right - R;
            path.AddArc(arcRect, 270, 90);
            // 右下圆弧
            arcRect.Y = rect.Bottom - R;
            path.AddArc(arcRect, 0, 90);
            // 左下圆弧
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
            #endregion
        }
    }
}
