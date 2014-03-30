using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ModernForms
{
    public static class ModernColors
    {
        static Color foreColor = Color.Black;
        public static Color ForeColor
        {
            get { return foreColor; }
            set { foreColor = value; }
        }

        static Color pressedForeColor = Color.White;
        public static Color PressedForeColor
        {
            get { return pressedForeColor; }
            set { pressedForeColor = value; }
        }

        static Color backColor = Color.FromArgb(243, 243, 243);
        public static Color BackColor
        {
            get { return backColor; }
            set { backColor = value; }
        }

        static Color borderColor = Color.FromArgb(180, 180, 180);
        public static Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        static Color selectedBackColor = Color.FromArgb(221, 221, 221);
        public static Color SelectedBackColor
        {
            get { return selectedBackColor; }
            set { selectedBackColor = value; }
        }

        static Color pressedBackColor = Color.FromArgb(42, 115, 234);
        public static Color PressedBackColor
        {
            get { return pressedBackColor; }
            set { pressedBackColor = value; }
        }
    }
}
