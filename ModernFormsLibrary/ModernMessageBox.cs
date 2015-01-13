using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using ModernForms.Controls;

namespace ModernForms
{
    public class ModernMessageBox : ModernForm
    {
        ModernButton okButton = new ModernButton();
        ModernButton yesButton = new ModernButton();
        ModernButton noButton = new ModernButton();
        ModernButton cancelButton = new ModernButton();
        ModernButton retryButton = new ModernButton();

        Form parent;
        public Form FormParent
        {
            get { return parent; }
            set { parent = value; }
        }

        string content;
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        string caption;
        public string Caption
        {
            get { return caption; }
            set { caption = value; }
        }

        MessageBoxButtons buttons;
        public MessageBoxButtons Buttons
        {
            get { return buttons; }
            set { buttons = value; }
        }

        MessageBoxIcon icon;
        public MessageBoxIcon Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        public ModernMessageBox()
            : base()
        {
            this.Font = new Font(new FontFamily("Segoe UI"), 9.75f, FontStyle.Regular);
            this.Moveable = false;
            this.ControlBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;

            okButton.Text = "Ok";
            okButton.Size = new Size(100, 35);
            okButton.Click += okButton_Click;

            yesButton.Text = "Yes";
            yesButton.Size = new Size(100, 35);
            yesButton.Click += yesButton_Click;

            noButton.Text = "No";
            noButton.Size = new Size(100, 35);
            noButton.Click += noButton_Click;

            cancelButton.Text = "Cancel";
            cancelButton.Size = new Size(100, 35);
            cancelButton.Click += cancelButton_Click;

            retryButton.Text = "Retry";
            retryButton.Size = new Size(100, 35);
            retryButton.Click += retryButton_Click;

            this.Controls.Add(okButton);
            this.Controls.Add(yesButton);
            this.Controls.Add(noButton);
            this.Controls.Add(cancelButton);
            this.Controls.Add(retryButton);

            okButton.Hide();
            yesButton.Hide();
            noButton.Hide();
            cancelButton.Hide();
            retryButton.Hide();
        }

        void retryButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
        }

        void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void noButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        void yesButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public static DialogResult Show(Form form, string content)
        {
            return Show(form, content, form.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        public static DialogResult Show(Form form, string content, string caption)
        {
            return Show(form, content, caption, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        public static DialogResult Show(Form form, string content, string caption, MessageBoxButtons buttons)
        {
            return Show(form, content, caption, buttons, MessageBoxIcon.None);
        }

        public static DialogResult Show(Form form, string content, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            if (form == null)
                throw new ArgumentNullException("ModernMessageBox requires a valid form object in the first argument.");

            ModernMessageBox msgBox = new ModernMessageBox();
            msgBox.parent = form;
            msgBox.content = content;
            msgBox.caption = caption;
            msgBox.buttons = buttons;
            msgBox.icon = icon;

            msgBox.Size = form.Size;
            msgBox.Location = form.Location;

            return msgBox.ShowDialog();
        }

        protected new DialogResult ShowDialog()
        {
            okButton.Hide();
            yesButton.Hide();
            noButton.Hide();
            cancelButton.Hide();
            retryButton.Hide();

            int messageBoxHeight = (this.Height / 3);
            int buttonHeight = (messageBoxHeight * 2) - 45;
            int buttonWidth = okButton.Width;
            int oneButtonRight = (this.Width - buttonWidth) - 10;
            int twoButtonRight = (this.Width - (buttonWidth * 2)) - 20;
            int threeButtonRight = (this.Width - (buttonWidth * 3)) - 30;

            if (buttons == MessageBoxButtons.OK)
            {
                okButton.Location = new Point(oneButtonRight, buttonHeight);
                okButton.Show();
            }
            else if (buttons == MessageBoxButtons.OKCancel)
            {
                okButton.Location = new Point(twoButtonRight, buttonHeight);
                okButton.Show();

                cancelButton.Location = new Point(oneButtonRight, buttonHeight);
                cancelButton.Show();
            }
            else if (buttons == MessageBoxButtons.YesNo)
            {
                yesButton.Location = new Point(twoButtonRight, buttonHeight);
                yesButton.Show();

                noButton.Location = new Point(oneButtonRight, buttonHeight);
                noButton.Show();
            }
            else if (buttons == MessageBoxButtons.YesNoCancel)
            {
                yesButton.Location = new Point(threeButtonRight, buttonHeight);
                yesButton.Show();

                noButton.Location = new Point(twoButtonRight, buttonHeight);
                noButton.Show();

                cancelButton.Location = new Point(oneButtonRight, buttonHeight);
                cancelButton.Show();
            }
            else if (buttons == MessageBoxButtons.RetryCancel)
            {
                retryButton.Location = new Point(twoButtonRight, buttonHeight);
                retryButton.Show();

                cancelButton.Location = new Point(oneButtonRight, buttonHeight);
                cancelButton.Show();
            }
            else
            {
                okButton.Location = new Point(oneButtonRight, buttonHeight);
                okButton.Show();
            }

            return base.ShowDialog();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.DarkGray)), e.ClipRectangle);

            Rectangle messageRect = new Rectangle();
            messageRect.Size = new Size(this.Width, (this.Height / 3));
            messageRect.Location = new Point(0, ((this.Height - (this.Height / 3)) / 2));

            Font messageFont = new Font(this.Font.FontFamily, 12.75f, FontStyle.Regular);

            e.Graphics.FillRectangle(new SolidBrush(parent.BackColor), messageRect);

            SolidBrush textBrush = new SolidBrush(parent.ForeColor);
            SolidBrush backBrush = new SolidBrush(parent.BackColor);

            if (!string.IsNullOrEmpty(caption))
                e.Graphics.DrawString(caption, messageFont, new SolidBrush(ModernColors.AccentColor), new PointF(messageRect.Left + 10, messageRect.Top + 10));
            if (!string.IsNullOrEmpty(content))
                e.Graphics.DrawString(content, messageFont, textBrush, new PointF(messageRect.Left + 10, messageRect.Top + 40));

            base.OnPaint(e);
        }
    }
}
