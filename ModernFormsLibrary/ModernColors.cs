using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Reflection;

namespace ModernForms
{
    public static class ModernColors
    {
        static Color foreColor = Color.FromArgb(31, 31, 31);
        public static Color ForeColor
        {
            get { return foreColor; }
            set { foreColor = value; }
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

        static Color hotTrackColor = Color.FromArgb(221, 221, 221);
        public static Color HotTrackColor
        {
            get { return hotTrackColor; }
            set { hotTrackColor = value; }
        }

        static Color accentColor = Color.FromArgb(51, 102, 255);
        public static Color AccentColor
        {
            get { return accentColor; }
            set { accentColor = value; }
        }

        static Color pressedForeColor = Color.White;
        public static Color PressedForeColor
        {
            get { return pressedForeColor; }
            set { pressedForeColor = value; }
        }

        static Color pressedBackColor = accentColor;
        public static Color PressedBackColor
        {
            get { return pressedBackColor; }
            set { pressedBackColor = value; }
        }

        static Color selectedBackColor = Color.AliceBlue;
        public static Color SelectedBackColor
        {
            get { return selectedBackColor; }
            set { selectedBackColor = value; }
        }

        static Color selectedForeColor = Color.White;
        public static Color SelectedForeColor
        {
            get { return selectedForeColor; }
            set { selectedForeColor = value; }
        }

        public static void LoadTheme(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();

            string content = File.ReadAllText(path);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(content);

            XmlElement root = doc.DocumentElement;
            XmlNodeList colorNodes = root.GetElementsByTagName("Color");

            foreach(XmlNode node in colorNodes)
            {
                if(node.Attributes["Name"] != null && node.Attributes["Value"] != null)
                {
                    string name = node.Attributes["Name"].Value;
                    Color value = Color.FromName(node.Attributes["Value"].Value);

                    if (name.ToLower() == "forecolor")
                        ForeColor = value;
                    else if (name.ToLower() == "backcolor")
                        BackColor = value;
                    else if (name.ToLower() == "bordercolor")
                        BorderColor = value;
                    else if (name.ToLower() == "hottrackcolor")
                        HotTrackColor = value;
                    else if (name.ToLower() == "accentcolor")
                        AccentColor = value;
                    else if (name.ToLower() == "pressedforecolor")
                        PressedForeColor = value;
                    else if (name.ToLower() == "pressedbackcolor")
                        PressedBackColor = value;
                    else if (name.ToLower() == "selectedbackcolor")
                        SelectedBackColor = value;
                    else if (name.ToLower() == "selectedforecolor")
                        SelectedForeColor = value;
                }
            }
        }
    }
}
