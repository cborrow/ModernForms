using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ModernForms
{
    public class ModernForm : Form
    {
        private Controls.ModernButton maximizeButton;
        private Controls.ModernButton minimizeButton;
        private Controls.ModernButton closeButton;

        const int WM_NCHITTEST = 0x0084;
        const int HTCLIENT = 0x01;
        const int HTCAPTION = 0x02;

        bool drawBorder;
        public bool DrawBorder
        {
            get { return drawBorder; }
            set { drawBorder = value; }
        }

        int borderThickness;
        public int BorderThickness
        {
            get { return borderThickness; }
            set { borderThickness = value; }
        }

        bool moveable;
        public bool Moveable
        {
            get { return moveable; }
            set { moveable = value; }
        }
    
        public ModernForm()
        {
            InitializeComponent();

            this.ForeColor = ModernColors.ForeColor;
            this.BackColor = ModernColors.BackColor;

            closeButton.BackColor = ModernColors.BackColor;
            closeButton.HotTrackColor = Color.FromArgb(219, 40, 25);
            closeButton.PressedColor = Color.Firebrick;

            maximizeButton.BackColor = ModernColors.BackColor;
            maximizeButton.HotTrackColor = ModernColors.HotTrackColor;
            maximizeButton.PressedColor = ModernColors.PressedBackColor;

            minimizeButton.BackColor = ModernColors.BackColor;
            minimizeButton.HotTrackColor = ModernColors.HotTrackColor;
            minimizeButton.PressedColor = ModernColors.PressedBackColor;

            this.DrawBorder = false;
            this.BorderThickness = 1;
            this.Moveable = true;
        }

        protected override void OnResize(EventArgs e)
        {
            closeButton.Location = new Point(this.Width - 34, 1);
            maximizeButton.Location = new Point(this.Width - 68, 1);
            minimizeButton.Location = new Point(this.Width - 102, 1);

            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.DrawBorder)
            {
                e.Graphics.DrawRectangle(new Pen(ModernColors.BorderColor, this.BorderThickness),
                    new Rectangle(0, 0, this.Width - this.BorderThickness, this.Height - this.BorderThickness));
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST)
            {
                if (this.Moveable)
                {
                    if ((int)m.Result == HTCLIENT)
                        m.Result = new IntPtr(HTCAPTION);
                }
            }

            if (this.ControlBox == false)
            {
                closeButton.Hide();
                minimizeButton.Hide();
                maximizeButton.Hide();
            }
            else if (this.Visible && this.ControlBox == true && !closeButton.Visible)
            {
                closeButton.Show();
                
                if(this.MinimizeBox)
                    minimizeButton.Show();

                if(this.MaximizeBox)
                    maximizeButton.Show();
            }

            if (this.Visible && !this.MinimizeBox && minimizeButton.Visible)
                minimizeButton.Hide();
            else if (this.Visible && this.MinimizeBox && !minimizeButton.Visible && this.ControlBox)
                minimizeButton.Show();

            if (this.Visible && !this.MaximizeBox && maximizeButton.Visible)
                maximizeButton.Hide();
            else if (this.Visible && this.MaximizeBox && !maximizeButton.Visible && this.ControlBox)
                maximizeButton.Show();
        }

        private void InitializeComponent()
        {
            this.minimizeButton = new ModernForms.Controls.ModernButton();
            this.maximizeButton = new ModernForms.Controls.ModernButton();
            this.closeButton = new ModernForms.Controls.ModernButton();
            this.SuspendLayout();
            // 
            // minimizeButton
            // 
            this.minimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.minimizeButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.minimizeButton.BorderThickness = 3;
            this.minimizeButton.DrawBorder = false;
            this.minimizeButton.HotTrackColor = System.Drawing.Color.Gainsboro;
            this.minimizeButton.Image = global::ModernForms.Properties.Resources.minimize;
            this.minimizeButton.LayoutFlags = ModernForms.Controls.LayoutFlags.ImageOnly;
            this.minimizeButton.Location = new System.Drawing.Point(900, 1);
            this.minimizeButton.Margin = new System.Windows.Forms.Padding(1);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.PressedColor = System.Drawing.Color.CornflowerBlue;
            this.minimizeButton.Size = new System.Drawing.Size(33, 30);
            this.minimizeButton.TabIndex = 2;
            this.minimizeButton.Text = "button3";
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // maximizeButton
            // 
            this.maximizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximizeButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.maximizeButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.maximizeButton.BorderThickness = 3;
            this.maximizeButton.DrawBorder = false;
            this.maximizeButton.HotTrackColor = System.Drawing.Color.Gainsboro;
            this.maximizeButton.Image = global::ModernForms.Properties.Resources.maximize;
            this.maximizeButton.LayoutFlags = ModernForms.Controls.LayoutFlags.ImageOnly;
            this.maximizeButton.Location = new System.Drawing.Point(935, 1);
            this.maximizeButton.Margin = new System.Windows.Forms.Padding(1);
            this.maximizeButton.Name = "maximizeButton";
            this.maximizeButton.PressedColor = System.Drawing.Color.CornflowerBlue;
            this.maximizeButton.Size = new System.Drawing.Size(33, 30);
            this.maximizeButton.TabIndex = 1;
            this.maximizeButton.Text = "button2";
            this.maximizeButton.Click += new System.EventHandler(this.maximizeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.closeButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.closeButton.BorderThickness = 3;
            this.closeButton.DrawBorder = false;
            this.closeButton.HotTrackColor = System.Drawing.Color.Gainsboro;
            this.closeButton.Image = global::ModernForms.Properties.Resources.close;
            this.closeButton.LayoutFlags = ModernForms.Controls.LayoutFlags.ImageOnly;
            this.closeButton.Location = new System.Drawing.Point(970, 1);
            this.closeButton.Margin = new System.Windows.Forms.Padding(1);
            this.closeButton.Name = "closeButton";
            this.closeButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.closeButton.Size = new System.Drawing.Size(33, 30);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "button1";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // ModernForm
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1004, 595);
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.maximizeButton);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ModernForm";
            this.ResumeLayout(false);

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maximizeButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
