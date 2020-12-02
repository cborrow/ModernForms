using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace ModernForms.Controls
{
    public class ModernControl : Control
    {
        Thread animationThread;
        double framesPerSecond = (1000 / 15);

        protected delegate void MoveControlDelegate(Point location);
        protected delegate void ResizeControlDelegate(Size size);
        protected delegate void SetControlBackColorDelegate(Color c);
        protected delegate void RefreshControlDelegate();

        public event EventHandler EffectStarted;
        public event EventHandler EffectEnded;

        public bool AnimateBackColorChange = false;
        public double SecondsToChange = 0.5;

        public event EventHandler HotTrackChanged;
        public event EventHandler SelectedChanged;

        bool hotTracked = false;
        public bool HotTracked
        {
            get { return hotTracked; }
        }

        bool pressed = false;
        public bool Pressed
        {
            get { return pressed; }
        }

        bool drawBorder;
        public bool DrawBorder
        {
            get { return drawBorder; }
            set { drawBorder = value; }
        }

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

        Color borderColor;
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        int borderThickness;
        public int BorderThickness
        {
            get { return borderThickness; }
            set { borderThickness = value; }
        }

        bool altStyleMode;
        public bool AltStyleMode
        {
            get { return altStyleMode; }
            set { altStyleMode = value; }
        }

        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                if (AnimateBackColorChange)
                    this.SetBackgroundColor(value, SecondsToChange);
                else
                    base.BackColor = value;
            }
        }

        public ModernControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.EffectStarted = new EventHandler(OnEffectStarted);
            this.EffectEnded = new EventHandler(OnEffectEnded);
            this.HotTrackChanged = new EventHandler(OnHotTrackChanged);
            this.SelectedChanged = new EventHandler(OnSelectedChanged);
        }

        public new void Move(Point location, double seconds)
        {
            animationThread = new Thread(new ThreadStart(delegate()
            {
                MoveControl(location, seconds);
            }));
            animationThread.Start();
        }

        public new void Resize(Size size, double seconds)
        {
            animationThread = new Thread(new ThreadStart(delegate()
            {
                ResizeControl(size, seconds);
            }));
            animationThread.Start();
        }

        public void SetBackgroundColor(Color backColor, double seconds)
        {
            animationThread = new Thread(new ThreadStart(delegate()
            {
                FadeToColor(backColor, seconds);
            }));
            animationThread.Start();
        }

        private void MoveControl(Point location, double seconds)
        {
            double x = (location.X - this.Location.X);
            double y = (location.Y - this.Location.Y);

            double xStepDist = (x / (framesPerSecond * seconds));
            double yStepDist = (y / (framesPerSecond * seconds));

            double ox = this.Location.X;
            double oy = this.Location.Y;

            try
            {
                for (int i = 0; i < (seconds * framesPerSecond); i++)
                {
                    ox += xStepDist;
                    oy += yStepDist;

                    Point p = new Point((int)ox, (int)oy);

                    if (this.InvokeRequired)
                    {
                        this.Invoke(new MoveControlDelegate(SetControlLocation), p);
                        this.Invoke(new RefreshControlDelegate(RefreshControl));
                    }
                    else
                    {
                        this.Location = p;
                        this.Refresh();
                    }

                    Thread.Sleep(10);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ResizeControl(Size size, double seconds)
        {
            double x = (size.Width - this.Width);
            double y = (size.Height - this.Height);

            double xStepDist = (x / (framesPerSecond * seconds));
            double yStepDist = (y / (framesPerSecond * seconds));

            double ox = this.Width;
            double oy = this.Height;

            try
            {
                for (int i = 0; i < (seconds * framesPerSecond); i++)
                {
                    ox += xStepDist;
                    oy += yStepDist;

                    Size s = new Size((int)ox, (int)oy);

                    if (this.InvokeRequired)
                    {
                        this.Invoke(new ResizeControlDelegate(SetControlSize), s);
                        this.Invoke(new RefreshControlDelegate(RefreshControl));
                    }
                    else
                    {
                        this.Size = s;
                        this.Refresh();
                    }

                    Thread.Sleep(10);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void FadeToColor(Color color, double seconds)
        {
            double r = (color.R - this.BackColor.R);
            double g = (color.G - this.BackColor.G);
            double b = (color.B - this.BackColor.B);

            double rStep = (r / (framesPerSecond * seconds));
            double gStep = (g / (framesPerSecond * seconds));
            double bStep = (b / (framesPerSecond * seconds));

            double or = this.BackColor.R;
            double og = this.BackColor.G;
            double ob = this.BackColor.B;

            try
            {
                for (int i = 0; i < (seconds * framesPerSecond); i++)
                {
                    or += rStep;
                    og += gStep;
                    ob += gStep;

                    Color c = Color.FromArgb((int)or, (int)og, (int)ob);

                    if (this.InvokeRequired)
                    {
                        this.Invoke(new SetControlBackColorDelegate(SetControlBackColor), c);
                        this.Invoke(new RefreshControlDelegate(RefreshControl));
                    }
                    else
                    {
                        this.BackColor = c;
                        this.Refresh();
                    }

                    Thread.Sleep(10);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void SetControlLocation(Point location)
        {
            this.Location = location;
        }

        protected void SetControlSize(Size size)
        {
            this.Size = size;
        }

        protected void SetControlBackColor(Color c)
        {
            this.BackColor = c;
        }

        protected void RefreshControl()
        {
            this.Refresh();
        }

        protected virtual void OnEffectStarted(object sender, EventArgs e)
        {

        }

        protected virtual void OnEffectEnded(object sender, EventArgs e)
        {

        }

        protected virtual void OnHotTrackChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        protected virtual void OnSelectedChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            hotTracked = true;
            HotTrackChanged(this, EventArgs.Empty);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            hotTracked = false;
            HotTrackChanged(this, EventArgs.Empty);
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            pressed = true;
            SelectedChanged(this, EventArgs.Empty);
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            pressed = false;
            SelectedChanged(this, EventArgs.Empty);
            base.OnMouseUp(e);
        }
    }
}
