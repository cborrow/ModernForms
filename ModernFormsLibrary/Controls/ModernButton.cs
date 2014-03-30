﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ModernForms.Controls {

    public enum LayoutFlags {
        TextOnly,
        ImageOnly,
        ImageBeforeText,
        TextBeforeImage,
        TextAboveImage,
        ImageAboveText
    };

    public class ModernButton : ModernControl
    {
        bool hotTracked = false;
        bool pressed = false;

        Color hotTrackColor;
        public Color HotTrackColor
        {
            get { return hotTrackColor; }
            set { hotTrackColor = value; }
        }

        Color pressedColor;
        public Color PressedColor
        {
            get { return pressedColor; }
            set { pressedColor = value; }
        }

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
            this.BackColor = Color.Gainsboro;
            this.HotTrackColor = Color.CornflowerBlue;
            this.PressedColor = Color.DarkBlue;

            this.Image = null;
            this.LayoutFlags = LayoutFlags.ImageBeforeText;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            hotTracked = true;
            this.Refresh();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            hotTracked = false;
            this.Refresh();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            pressed = true;
            this.Refresh();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            pressed = false;
            this.Refresh();
            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color foreColor = ModernColors.ForeColor;
            Color backColor = this.BackColor;

            if (hotTracked && !pressed)
                backColor = hotTrackColor;
            else if (pressed)
            {
                foreColor = ModernColors.PressedForeColor;
                backColor = pressedColor;
            }

            e.Graphics.FillRectangle(new SolidBrush(backColor), e.ClipRectangle);

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