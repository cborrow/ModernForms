using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ModernForms.Controls {

    public enum LayoutFlags 
    {
        TextOnly,
        ImageOnly,
        ImageBeforeText,
        TextBeforeImage,
        TextAboveImage,
        ImageAboveText
    };

    public class ModernButton : ModernControl
    {
        Image image;
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        LayoutFlags layoutFlags;
        public LayoutFlags LayoutFlags
        {
            get { return layoutFlags; }
            set { layoutFlags = value; }
        }
        
        public ModernButton()
        {
            this.BackColor = ModernColors.BackColor;
            this.HotTrackColor = ModernColors.HotTrackColor;
            this.PressedColor = ModernColors.PressedBackColor;
            this.BorderColor = ModernColors.BorderColor;
            this.DrawBorder = true;
            this.BorderThickness = 3;

            this.Image = null;
            this.LayoutFlags = LayoutFlags.ImageBeforeText;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color foreColor = this.ForeColor;
            Color backColor = this.BackColor;

            if (HotTracked && !Pressed)
            {
                if (!AltStyleMode)
                    backColor = HotTrackColor;
                else
                    foreColor = HotTrackColor;
            }
            else if (Pressed)
            {
                foreColor = ModernColors.PressedForeColor;
                backColor = PressedColor;
            }

            e.Graphics.FillRectangle(new SolidBrush(backColor), e.ClipRectangle);

            if (this.DrawBorder)
                e.Graphics.DrawRectangle(new Pen(this.BorderColor, this.BorderThickness),
                    new Rectangle(1, 1, this.Width - this.BorderThickness, this.Height - this.BorderThickness));

            SizeF textSize = e.Graphics.MeasureString(this.Text, this.Font);

            if (this.Image != null)
            {
                if (this.LayoutFlags == LayoutFlags.ImageBeforeText)
                {
                    e.Graphics.DrawImage(this.Image, new Point(0, 0));
                    e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(foreColor),
                        new PointF(this.Image.Width + 2, (this.Height - textSize.Height) / 2));
                }
                else if (this.LayoutFlags == LayoutFlags.TextBeforeImage)
                {
                    e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(foreColor),
                        new PointF(0, (this.Height - textSize.Height) / 2));
                    e.Graphics.DrawImage(this.Image, new Point(this.Width - this.Image.Width, 0));
                }
                else if (this.LayoutFlags == LayoutFlags.ImageOnly)
                {
                    e.Graphics.DrawImage(this.Image, new Point((this.Width - this.Image.Width) / 2, (this.Height - this.Image.Height) / 2));
                }
                else if (this.LayoutFlags == LayoutFlags.TextOnly)
                {
                    e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(foreColor),
                        new PointF((this.Width - textSize.Width) / 2, (this.Height - textSize.Height) / 2));
                }
            }
            else
            {
                e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(foreColor),
                        new PointF((this.Width - textSize.Width) / 2, (this.Height - textSize.Height) / 2));
            }
            base.OnPaint(e);
        }
    }
}
