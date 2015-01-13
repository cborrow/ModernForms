using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ModernForms;
using ModernForms.Controls;
using ModernForms.Properties;

namespace TestApp
{
    public partial class Form1 : ModernForm
    {
        public Form1()
            : base()
        {
            InitializeComponent();

            for (int i = 0; i < 100; i++)
            {
                modernListBox1.Items.Add("Test Item " + i.ToString());
            }
        }

        private void modernButton1_Click(object sender, EventArgs e)
        {
            ModernMessageBox.Show(this, "This is some not-so crazy, however, odd content.", "This is a test caption.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.None);
        }
    }
}
