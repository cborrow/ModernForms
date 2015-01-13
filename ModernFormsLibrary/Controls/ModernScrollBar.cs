using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ModernForms.Controls
{
    public class ModernScrollBar : ModernControl
    {
        public event EventHandler ValueChanged;

        Color gutterColor;
        public Color GutterColor
        {
            get { return gutterColor; }
            set { gutterColor = value; }
        }

        Color thumbColor;
        public Color ThumbColor
        {
            get { return thumbColor; }
            set { thumbColor = value; }
        }

        int value;
        public int Value
        {
            get { return value; }
            set
            {
                if (value < 0)
                    this.value = 0;
                else if (value > Max)
                    this.value = Max;
                else
                {
                    this.value = value;
                    ValueChanged(this, EventArgs.Empty);
                }
            }
        }

        int min;
        public int Min
        {
            get { return min; }
            set { min = value; }
        }

        int max;
        public int Max
        {
            get { return max; }
            set
            {
                max = value;

                if (this.Orientation == Orientation.Vertical)
                {
                    if (max > this.Height)
                        thumbSize = (double)this.Height * ((double)this.Height / (double)max);
                    else
                        thumbSize = 0;
                }
                else if (this.Orientation == Orientation.Horizontal)
                {
                    if (max > this.Width)
                        thumbSize = (double)this.Width * ((double)this.Width / (double)max);
                    else
                        thumbSize = 0;
                }

                this.Refresh();
            }
        }

        int smallChange;
        public int SmallChange
        {
            get { return smallChange; }
            set { smallChange = value; }
        }

        int largeChange;
        public int LargeChange
        {
            get { return largeChange; }
            set { largeChange = value; }
        }

        double thumbSize;
        bool thumbSelected;
        Point lastMousePos;

        Orientation orientation;
        public Orientation Orientation
        {
            get { return orientation; }
            set { orientation = value; }
        }

        public ModernScrollBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.Selectable, true);

            ValueChanged = new EventHandler(OnValueChanged);

            gutterColor = Color.GhostWhite;
            thumbColor = Color.Silver;

            this.Value = 0;
            this.Min = 0;
            this.Max = 1;
            this.SmallChange = 10;
            this.LargeChange = 50;
            this.Orientation = Orientation.Vertical;

            thumbSize = 10;
            thumbSelected = false;
        }

        protected void DrawGutter(PaintEventArgs e)
        {
            if(this.Max > this.Height)
                e.Graphics.FillRectangle(new SolidBrush(this.GutterColor), e.ClipRectangle);
        }

        protected void DrawThumb(PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, 10, 10);


            if (this.Orientation == Orientation.Vertical)
            {
                thumbSize = (double)this.Height * ((double)this.Height / (double)max);
                double y = (double)(this.Height - thumbSize) * ((double)this.Value / (double)max);
                

                rect = new Rectangle(new Point(0, (int)y), new Size(this.Width, (int)thumbSize));
            }
            else if (this.Orientation == Orientation.Horizontal)
            {
                thumbSize = (double)this.Width * ((double)this.Width / (double)max);
                double x = (double)(this.Width - thumbSize) * ((double)this.Value / (double)max);

                rect = new Rectangle(new Point((int)x, 0), new Size((int)thumbSize, this.Height));
            }

            e.Graphics.FillRectangle(new SolidBrush(this.ThumbColor), rect);
        }

        protected virtual void OnValueChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                this.Value -= this.SmallChange;

                if (this.Value < this.Min)
                    this.Value = this.Min;
            }
            else if (e.Delta < 0)
            {
                this.Value += this.SmallChange;

                if (this.Value > this.Max)
                    this.Value = this.Max;
            }

            this.Refresh();
            base.OnMouseWheel(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.Focus();

            base.OnMouseEnter(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Rectangle mouseRect = new Rectangle(e.X, e.Y, 1, 1);
            Rectangle gutterRect = new Rectangle(0, 0, this.Width, this.Height);
            Rectangle thumbRect = new Rectangle(0, 0, 10, 10);

            if (this.Orientation == Orientation.Vertical)
            {
                thumbSize = (double)this.Height * ((double)this.Height / (double)max);
                double y = (double)(this.Height - thumbSize) * ((double)this.Value / (double)max);

                thumbRect = new Rectangle(0, (int)y, this.Width, (int)thumbSize);
            }
            else if (this.Orientation == Orientation.Horizontal)
            {
                thumbSize = (double)this.Width * ((double)this.Width / (double)max);
                double x = (double)(this.Width - thumbSize) * ((double)this.Value / (double)max);

                thumbRect = new Rectangle((int)x, 0, (int)thumbSize, this.Height);
            }

            if (mouseRect.IntersectsWith(gutterRect))
            {
                if (mouseRect.IntersectsWith(thumbRect))
                {
                    thumbSelected = true;
                }
                else
                {
                    if (this.Orientation == Orientation.Vertical)
                    {
                        if (mouseRect.Y < thumbRect.Top)
                            this.Value -= largeChange;
                        else if (mouseRect.Y > thumbRect.Bottom)
                            this.Value += largeChange;
                    }
                    else if (this.Orientation == Orientation.Horizontal)
                    {
                        if (mouseRect.X < thumbRect.Left)
                            this.Value -= largeChange;
                        else if (mouseRect.X > thumbRect.Right)
                            this.Value += largeChange;
                    }
                }
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            thumbSelected = false;

            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (thumbSelected)
            {
                if (this.Orientation == Orientation.Vertical)
                {
                    if (e.Y != lastMousePos.Y)
                    {
                        double y = (double)e.Y - (thumbSize / 2);
                        y = Math.Min(y, (this.Height - thumbSize));
                        y = Math.Max(y, 0);

                        double v = (double)this.Max * (y / ((double)this.Height - thumbSize));
                        this.Value = (int)v;
                    }
                }
                else if (this.Orientation == Orientation.Horizontal)
                {
                    if (e.X != lastMousePos.X)
                    {
                        double x = (double)e.X - (thumbSize / 2);
                        x = Math.Min(x, (this.Width - thumbSize));
                        x = Math.Max(x, 0);

                        double v = (double)this.Max * (x / ((double)this.Width - thumbSize));
                        this.Value = (int)v;
                    }
                }
            }

            lastMousePos = new Point(e.X, e.Y);
            base.OnMouseMove(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawGutter(e);
            DrawThumb(e);

            base.OnPaint(e);
        }
    }
}
