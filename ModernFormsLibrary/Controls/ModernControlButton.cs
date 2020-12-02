using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ModernForms.Controls
{
    public enum ControlButtonType
    {
        Close,
        Maximize,
        Minimize
    };

    public class ModernControlButton : ModernButton
    {
        ControlButtonType controlButtonType;
        public ControlButtonType ButtonType
        {
            get { return controlButtonType; }
            set { controlButtonType = value; }
        }

        bool minimalStyle;
        public bool MinimalStyle
        {
            get { return minimalStyle; }
            set { minimalStyle = value; }
        }

        int padding = 8;

        public ModernControlButton() : base()
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color penColor = ForeColor;

            if (HotTracked)
                penColor = HotTrackColor;

            Pen thickPen = new Pen(new SolidBrush(penColor), 2);
            Pen thinPen = new Pen(new SolidBrush(penColor));

            if(controlButtonType == ControlButtonType.Close)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                e.Graphics.DrawLine(thickPen, padding, padding,
                    this.Bounds.Width - padding, this.Bounds.Height - padding);

                e.Graphics.DrawLine(thickPen, padding, this.Bounds.Height - padding,
                    this.Bounds.Width - padding, padding);
            }
            else if(controlButtonType == ControlButtonType.Maximize)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;

                Rectangle rect = new Rectangle();
                rect.Location = new Point(padding, padding);
                rect.Size = new Size(this.Width - (padding * 2), this.Height - (padding * 2));

                e.Graphics.DrawRectangle(thinPen, rect);
                e.Graphics.DrawLine(thickPen, rect.Left, rect.Top, rect.Right + 1, rect.Top);
            }
            else if(controlButtonType == ControlButtonType.Minimize)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;

                e.Graphics.DrawLine(thickPen, 5, 10, this.Bounds.Width - 10, 10);
            }
            //base.OnPaint(e);
        }
    }
}
