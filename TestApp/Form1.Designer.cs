namespace TestApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.modernListBox1 = new ModernForms.Controls.ModernListBox();
            this.modernMenuStrip1 = new ModernForms.Controls.ModernMenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.file1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.file2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ellipseButton1 = new ModernForms.Controls.EllipseButton();
            this.modernButton1 = new ModernForms.Controls.ModernButton();
            this.modernMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // modernListBox1
            // 
            this.modernListBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.modernListBox1.ForeColor = System.Drawing.Color.Black;
            this.modernListBox1.HotLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.modernListBox1.HotLightedIndex = -1;
            this.modernListBox1.ItemHeight = 30;
            this.modernListBox1.Location = new System.Drawing.Point(31, 107);
            this.modernListBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.modernListBox1.MultiSelection = false;
            this.modernListBox1.Name = "modernListBox1";
            this.modernListBox1.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(115)))), ((int)(((byte)(234)))));
            this.modernListBox1.SelectedIndex = -1;
            this.modernListBox1.Size = new System.Drawing.Size(288, 241);
            this.modernListBox1.TabIndex = 3;
            // 
            // modernMenuStrip1
            // 
            this.modernMenuStrip1.AutoSize = false;
            this.modernMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.modernMenuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.modernMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modernMenuStrip1.ForeColor = System.Drawing.Color.Black;
            this.modernMenuStrip1.HotTrackColor = System.Drawing.Color.Empty;
            this.modernMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.modernMenuStrip1.Location = new System.Drawing.Point(1, 1);
            this.modernMenuStrip1.Name = "modernMenuStrip1";
            this.modernMenuStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.modernMenuStrip1.SelectedColor = System.Drawing.Color.Empty;
            this.modernMenuStrip1.Size = new System.Drawing.Size(175, 30);
            this.modernMenuStrip1.TabIndex = 4;
            this.modernMenuStrip1.Text = "modernMenuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.toolStripSeparator2,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 30);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file1ToolStripMenuItem,
            this.file2ToolStripMenuItem,
            this.customFileToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // file1ToolStripMenuItem
            // 
            this.file1ToolStripMenuItem.AutoToolTip = true;
            this.file1ToolStripMenuItem.Checked = true;
            this.file1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.file1ToolStripMenuItem.Name = "file1ToolStripMenuItem";
            this.file1ToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.file1ToolStripMenuItem.Text = "File 1";
            // 
            // file2ToolStripMenuItem
            // 
            this.file2ToolStripMenuItem.Name = "file2ToolStripMenuItem";
            this.file2ToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.file2ToolStripMenuItem.Text = "File 2";
            // 
            // customFileToolStripMenuItem
            // 
            this.customFileToolStripMenuItem.Name = "customFileToolStripMenuItem";
            this.customFileToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.customFileToolStripMenuItem.Text = "Custom File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Checked = true;
            this.saveToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(118, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.printToolStripMenuItem.Text = "Print";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(118, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(42, 30);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // ellipseButton1
            // 
            this.ellipseButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.ellipseButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ellipseButton1.BorderThickness = 3;
            this.ellipseButton1.DrawBorder = true;
            this.ellipseButton1.HotTrackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.ellipseButton1.Image = global::TestApp.Properties.Resources.close;
            this.ellipseButton1.LayoutFlags = ModernForms.Controls.LayoutFlags.ImageOnly;
            this.ellipseButton1.Location = new System.Drawing.Point(552, 333);
            this.ellipseButton1.Name = "ellipseButton1";
            this.ellipseButton1.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(115)))), ((int)(((byte)(234)))));
            this.ellipseButton1.Size = new System.Drawing.Size(50, 50);
            this.ellipseButton1.TabIndex = 6;
            this.ellipseButton1.Text = "ellipseButton1";
            // 
            // modernButton1
            // 
            this.modernButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.modernButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.modernButton1.BorderThickness = 3;
            this.modernButton1.DrawBorder = true;
            this.modernButton1.HotTrackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.modernButton1.Image = null;
            this.modernButton1.LayoutFlags = ModernForms.Controls.LayoutFlags.ImageBeforeText;
            this.modernButton1.Location = new System.Drawing.Point(633, 82);
            this.modernButton1.Name = "modernButton1";
            this.modernButton1.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(115)))), ((int)(((byte)(234)))));
            this.modernButton1.Size = new System.Drawing.Size(221, 143);
            this.modernButton1.TabIndex = 7;
            this.modernButton1.Text = "modernButton1";
            this.modernButton1.Click += new System.EventHandler(this.modernButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 595);
            this.Controls.Add(this.modernButton1);
            this.Controls.Add(this.ellipseButton1);
            this.Controls.Add(this.modernListBox1);
            this.Controls.Add(this.modernMenuStrip1);
            this.DrawBorder = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.modernMenuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.modernMenuStrip1, 0);
            this.Controls.SetChildIndex(this.modernListBox1, 0);
            this.Controls.SetChildIndex(this.ellipseButton1, 0);
            this.Controls.SetChildIndex(this.modernButton1, 0);
            this.modernMenuStrip1.ResumeLayout(false);
            this.modernMenuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ModernForms.Controls.ModernListBox modernListBox1;
        private ModernForms.Controls.ModernMenuStrip modernMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem file1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem file2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customFileToolStripMenuItem;
        private ModernForms.Controls.EllipseButton ellipseButton1;
        private ModernForms.Controls.ModernButton modernButton1;
    }
}

