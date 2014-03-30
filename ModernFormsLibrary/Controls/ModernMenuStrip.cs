using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ModernForms.Controls
{
    public class ModernMenuStrip : MenuStrip
    {
        Color hotTrackColor;
        public Color HotTrackColor
        {
            get { return hotTrackColor; }
            set { hotTrackColor = value; }
        }

        Color selectedColor;
        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; }
        }

        public ModernMenuStrip()
        {
            this.Renderer = new ModernToolStripRenderer();
            this.Dock = DockStyle.None;
            this.AutoSize = false;
            this.Padding = new Padding(1);
            this.Size = new Size(100, 30);
        }

        protected override void OnItemAdded(ToolStripItemEventArgs e)
        {
            int width = 1;

            for (int i = 0; i < this.Items.Count; i++)
            {
                width += this.Items[i].Width;
            }

            width += 1;

            this.Size = new Size(width, 30);

            base.OnItemAdded(e);
        }

        protected override void OnItemRemoved(ToolStripItemEventArgs e)
        {
            int width = 1;

            for (int i = 0; i < this.Items.Count; i++)
            {
                width += this.Items[i].Width;
            }

            width += 1;

            this.Size = new Size(width, 30);

            base.OnItemRemoved(e);
        }
    }
}
