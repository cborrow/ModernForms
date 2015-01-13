using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ModernForms.Controls
{
    public class ModernListBox : Control
    {
        ModernScrollBar scrollBar;

        ModernListBoxItemCollection items;
        public ModernListBoxItemCollection Items
        {
            get { return items; }
        }

        int itemHeight;
        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }

        Color hotLightColor;
        public Color HotLightColor
        {
            get { return hotLightColor; }
            set { hotLightColor = value; }
        }

        Color selectedColor;
        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; }
        }

        int selectedIndex;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; }
        }

        public object SelectedValue
        {
            get { return null; }
        }

        int hotLightedIndex;
        public int HotLightedIndex
        {
            get { return hotLightedIndex; }
            set { hotLightedIndex = value; }
        }

        public object HotLightedItem
        {
            get { return null; }
        }

        public ModernListBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            items = new ModernListBoxItemCollection();
            items.ItemAdded += new EventHandler(items_ItemAdded);
            items.ItemRemoved += new EventHandler(items_ItemRemoved);

            this.ItemHeight = 30;
            this.HotLightColor = ModernColors.SelectedBackColor;
            this.SelectedColor = ModernColors.AccentColor;
            this.SelectedIndex = -1;
            this.HotLightedIndex = -1;

            scrollBar = new ModernScrollBar();
            scrollBar.GutterColor = ModernColors.SelectedBackColor;
            scrollBar.ThumbColor = ModernColors.AccentColor;
            scrollBar.Location = new Point(this.Width - 5, 0);
            scrollBar.Size = new Size(5, this.Height);
            scrollBar.Orientation = Orientation.Vertical;
            scrollBar.ValueChanged += new EventHandler(scrollBar_ValueChanged);
            scrollBar.SmallChange = this.ItemHeight;
            scrollBar.LargeChange = this.ItemHeight * 3;
            scrollBar.Show();

            this.Controls.Add(scrollBar);
            this.Controls.SetChildIndex(scrollBar, 0);
        }

        public int IndexFromPoint(Point p)
        {
            int index = (scrollBar.Value / this.ItemHeight) + (p.Y / this.ItemHeight);

            if (index >= this.Items.Count)
                index = -1;

            return index;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            int index = IndexFromPoint(e.Location);

            if (index >= 0 && index < this.Items.Count)
            {
                this.HotLightedIndex = index;
                this.Refresh();
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.HotLightedIndex = -1;
            this.Refresh();

            base.OnMouseLeave(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            int index = IndexFromPoint(e.Location);

            if (index >= 0 && index < this.Items.Count)
            {
                this.SelectedIndex = index;
                this.Refresh();
            }

            base.OnMouseClick(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {

            this.scrollBar.Value -= (e.Delta / 4);

            base.OnMouseWheel(e);
        }

        protected override void OnResize(EventArgs e)
        {
            scrollBar.Location = new Point(this.Width - 8, 0);
            scrollBar.Size = new Size(8, this.Height);

            base.OnResize(e);
        }

        protected void DrawItem(DrawItemEventArgs e)
        {
            Color foreColor = ModernColors.ForeColor;
            Color backColor = ModernColors.BackColor;
            string text = this.Items[e.Index].ToString();

            if (e.State == DrawItemState.HotLight)
                backColor = ModernColors.SelectedBackColor;
            else if (e.State == DrawItemState.Selected)
            {
                foreColor = ModernColors.PressedForeColor;
                backColor = ModernColors.AccentColor;
            }

            e.Graphics.FillRectangle(new SolidBrush(backColor), e.Bounds);
            TextRenderer.DrawText(e.Graphics, text, this.Font, e.Bounds, foreColor, Color.Transparent,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.LeftAndRightPadding);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int firstVisibleItem = (scrollBar.Value / this.ItemHeight);
            int lastVisibleItem = (scrollBar.Value / this.ItemHeight) + (this.Height / this.ItemHeight) + 1;

            if (firstVisibleItem < 0)
                firstVisibleItem = 0;

            if (lastVisibleItem > this.Items.Count)
                lastVisibleItem = this.Items.Count;

            for (int i = firstVisibleItem; i < lastVisibleItem; i++)
            {
                DrawItemState state = DrawItemState.Default;

                if (i == this.HotLightedIndex && i != this.SelectedIndex)
                    state = DrawItemState.HotLight;
                else if (i == this.SelectedIndex)
                    state = DrawItemState.Selected;

                Rectangle rect = new Rectangle(0, ((i - firstVisibleItem) * this.ItemHeight), this.Width, this.ItemHeight);
                DrawItemEventArgs de = new DrawItemEventArgs(e.Graphics, this.Font, rect, i, state);

                DrawItem(de);
            }
            base.OnPaint(e);
        }

        void items_ItemAdded(object sender, EventArgs e)
        {
            scrollBar.Max = (this.Items.Count * this.ItemHeight);
            scrollBar.Refresh();
        }

        void items_ItemRemoved(object sender, EventArgs e)
        {
            scrollBar.Max = (this.Items.Count * this.ItemHeight);
            scrollBar.Refresh();
        }

        void scrollBar_ValueChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }
    };

    public class ModernListBoxItemCollection : System.Collections.ObjectModel.Collection<object>
    {
        public event EventHandler ItemAdded;
        public event EventHandler ItemRemoved;

        public ModernListBoxItemCollection()
        {
            ItemAdded = new EventHandler(OnItemAdded);
            ItemRemoved = new EventHandler(OnItemRemoved);
        }

        public void AddRange(IEnumerable<object> items)
        {
            foreach (object item in items)
            {
                this.Items.Add(item);
            }
        }

        protected override void InsertItem(int index, object item)
        {
            base.InsertItem(index, item);
            ItemAdded(this, EventArgs.Empty);
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
            ItemRemoved(this, EventArgs.Empty);
        }

        protected virtual void OnItemAdded(object sender, EventArgs e)
        {

        }

        protected virtual void OnItemRemoved(object sender, EventArgs e)
        {

        }
    }
}
