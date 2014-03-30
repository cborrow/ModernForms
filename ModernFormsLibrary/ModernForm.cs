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
    
        public ModernForm()
        {
            InitializeComponent();

            this.ForeColor = ModernColors.ForeColor;
            this.BackColor = ModernColors.BackColor;

            closeButton.BackColor = ModernColors.BackColor;
            closeButton.HotTrackColor = ModernColors.SelectedBackColor;
            closeButton.PressedColor = Color.FromArgb(189, 75, 93);

            maximizeButton.BackColor = ModernColors.BackColor;
            maximizeButton.HotTrackColor = ModernColors.SelectedBackColor;
            maximizeButton.PressedColor = ModernColors.PressedBackColor;

            minimizeButton.BackColor = ModernColors.BackColor;
            minimizeButton.HotTrackColor = ModernColors.SelectedBackColor;
            minimizeButton.PressedColor = ModernColors.PressedBackColor;
        }

        protected override void OnResize(EventArgs e)
        {
            closeButton.Location = new Point(this.Width - 34, 1);
            maximizeButton.Location = new Point(this.Width - 68, 1);
            minimizeButton.Location = new Point(this.Width - 102, 1);

            base.OnResize(e);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST)
            {
                if ((int)m.Result == HTCLIENT)
                    m.Result = new IntPtr(HTCAPTION);
            }
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
