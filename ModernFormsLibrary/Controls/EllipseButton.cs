using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ModernForms.Controls
{
    public class EllipseButton : ModernButton
    {
        public EllipseButton()
            : base()
        {
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color foreColor = this.ForeColor;
            Color backColor = this.BackColor;
            Color borderColor = this.BackColor;

            if (this.HotTracked && !this.Pressed) {
                backColor = this.HotTrackColor;
                borderColor = backColor;
            }
            else if (this.Pressed)
            {
                foreColor = ModernColors.PressedForeColor;
                backColor = this.PressedColor;
                borderColor = backColor;
            }

            if(this.DrawBorder)
                borderColor = this.BorderColor;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.FillEllipse(new SolidBrush(backColor), 
                new Rectangle(2, 2, this.Width - (this.BorderThickness + 1), this.Height - (this.BorderThickness + 1)));
            e.Graphics.DrawEllipse(new Pen(this.BorderColor, this.BorderThickness), 
                    new Rectangle(1, 1, this.Width - this.BorderThickness, this.Height - this.BorderThickness));

            if (this.Image != null)
            {
                if (this.LayoutFlags == LayoutFlags.ImageOnly)
                    e.Graphics.DrawImage(this.Image, new Point((this.Width - this.Image.Width) / 2, (this.Height - this.Image.Height) / 2));
            }
            else
                TextRenderer.DrawText(e.Graphics, this.Text, this.Font, e.ClipRectangle, foreColor,
                    Color.Transparent, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            //base.OnPaint(e);
        }
    }
}
