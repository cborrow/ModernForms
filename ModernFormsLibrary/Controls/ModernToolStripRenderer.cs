using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ModernForms.Controls
{
    public class ModernToolStripRenderer : ToolStripRenderer
    {
        public Color ForeColor
        {
            get { return ModernColors.ForeColor; }
            set { ModernColors.ForeColor = value; }
        }

        public Color PressedForeColor
        {
            get { return ModernColors.PressedForeColor; }
            set { ModernColors.PressedForeColor = value; }
        }

        public Color BackColor
        {
            get { return ModernColors.BackColor; }
            set { ModernColors.BackColor = value; }
        }

        public Color SelectedColor
        {
            get { return ModernColors.SelectedBackColor; }
            set { ModernColors.SelectedBackColor = value; }
        }

        public Color PressedColor
        {
            get { return ModernColors.PressedBackColor; }
            set { ModernColors.PressedBackColor = value; }
        }

        public ModernToolStripRenderer()
        {

        }

        protected override void Initialize(ToolStrip toolStrip)
        {
            toolStrip.ForeColor = ModernColors.ForeColor;
            toolStrip.BackColor = ModernColors.BackColor;

            base.Initialize(toolStrip);
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            //e.Graphics.FillRectangle(new SolidBrush(foreColor), e.ArrowRectangle);

            base.OnRenderArrow(e);
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderButtonBackground(e);

            Rectangle rect = new Rectangle(0, 0, e.Item.Width, e.Item.Height);
            Color color = this.BackColor;

            if (e.Item.Selected && !e.Item.Pressed)
                color = this.SelectedColor;
            else if (e.Item.Pressed)
                color = this.PressedColor;

            e.Graphics.FillRectangle(new SolidBrush(color), rect);
        }

        protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderDropDownButtonBackground(e);

            Rectangle rect = new Rectangle(0, 0, e.Item.Width, e.Item.Height);
            Color color = this.BackColor;

            if (e.Item.Selected && !e.Item.Pressed)
                color = this.SelectedColor;
            else if (e.Item.Pressed)
                color = this.PressedColor;

            e.Graphics.FillRectangle(new SolidBrush(color), rect);
        }

        protected override void OnRenderItemBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderItemBackground(e);

            Rectangle rect = new Rectangle(0, 0, e.Item.Width, e.Item.Height);
            Color color = this.BackColor;

            if (e.Item.Selected && !e.Item.Pressed)
                color = this.SelectedColor;
            else if (e.Item.Pressed)
                color = this.PressedColor;

            e.Graphics.FillRectangle(new SolidBrush(color), rect);
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderMenuItemBackground(e);

            Rectangle rect = new Rectangle(0, 0, e.Item.Width, e.Item.Height);
            Color color = this.BackColor;

            if (e.Item.Selected && !e.Item.Pressed)
                color = this.SelectedColor;
            else if (e.Item.Pressed)
                color = this.PressedColor;

            e.Graphics.FillRectangle(new SolidBrush(color), rect);
        }

        protected override void OnRenderLabelBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderLabelBackground(e);

            Rectangle rect = new Rectangle(0, 0, e.Item.Width, e.Item.Height);
            Color color = this.BackColor;

            if (e.Item.Selected && !e.Item.Pressed)
                color = this.SelectedColor;
            else if (e.Item.Pressed)
                color = this.PressedColor;

            e.Graphics.FillRectangle(new SolidBrush(color), rect);
        }

        protected override void OnRenderGrip(ToolStripGripRenderEventArgs e)
        {
            base.OnRenderGrip(e);

            e.Graphics.DrawString("GRIP", SystemFonts.MenuFont, Brushes.Black, e.GripBounds);
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            base.OnRenderToolStripBackground(e);
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), e.AffectedBounds);
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            base.OnRenderItemText(e);

            Color foreColor = ModernColors.ForeColor;

            if (e.Item.Pressed)
                foreColor = ModernColors.PressedForeColor;

            TextRenderer.DrawText(e.Graphics, e.Text, e.TextFont, e.TextRectangle, foreColor,
                Color.Transparent, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            base.OnRenderImageMargin(e);
        }

        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            //base.OnRenderItemCheck(e);

            e.Graphics.DrawImage(ModernForms.Properties.Resources.check, e.ImageRectangle);
        }

        protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            base.OnRenderItemImage(e);
        }

        protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderOverflowButtonBackground(e);

            Color color = this.BackColor;

            if (e.Item.Selected && !e.Item.Pressed)
                color = this.SelectedColor;
            else if (e.Item.Pressed)
                color = this.PressedColor;

            e.Graphics.FillRectangle(new SolidBrush(color), e.Item.Bounds);
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            base.OnRenderSeparator(e);
            Rectangle itemRect = e.Item.Bounds;

            if (e.Vertical)
            {
                e.Graphics.DrawLine(Pens.Gainsboro, new Point(0, 0), new Point(0, itemRect.Height));
                e.Graphics.DrawLine(Pens.WhiteSmoke, new Point(1, 0), new Point(1, itemRect.Height));
            }
            else
            {
                //e.Graphics.DrawLine(Pens.Gainsboro, new Point(0, 0), new Point(itemRect.Width, 0));
                //e.Graphics.DrawLine(Pens.WhiteSmoke, new Point(0, 1), new Point(itemRect.Width, 1));
                e.Graphics.DrawLine(new Pen(Color.Gainsboro, 2), new Point(0, 0), new Point(itemRect.Width, 0));
            }
        }

        protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderSplitButtonBackground(e);

            Color color = this.BackColor;

            if (e.Item.Selected && !e.Item.Pressed)
                color = this.SelectedColor;
            else if (e.Item.Pressed)
                color = this.PressedColor;

            e.Graphics.FillRectangle(new SolidBrush(color), e.Item.Bounds);
        }

        protected override void OnRenderStatusStripSizingGrip(ToolStripRenderEventArgs e)
        {
            base.OnRenderStatusStripSizingGrip(e);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            base.OnRenderToolStripBorder(e);

            if (e.ToolStrip.IsDropDown)
            {
                Rectangle rect = new Rectangle(0, 0, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1);
                e.Graphics.DrawRectangle(Pens.Gainsboro, rect);
            }
        }

        protected override void OnRenderToolStripContentPanelBackground(ToolStripContentPanelRenderEventArgs e)
        {
            base.OnRenderToolStripContentPanelBackground(e);
        }

        protected override void OnRenderToolStripPanelBackground(ToolStripPanelRenderEventArgs e)
        {
            base.OnRenderToolStripPanelBackground(e);
        }

        protected override void OnRenderToolStripStatusLabelBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderToolStripStatusLabelBackground(e);
        }
    }
}
