namespace PomoMeetApp.View
{
    partial class NotificationInRoom
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationInRoom));
            picNotificationIcon = new PictureBox();
            lblNotification = new SiticoneNetCoreUI.SiticoneLabel();
            btnClose = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picNotificationIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnClose).BeginInit();
            SuspendLayout();
            // 
            // picNotificationIcon
            // 
            picNotificationIcon.Location = new Point(6, 11);
            picNotificationIcon.Name = "picNotificationIcon";
            picNotificationIcon.Size = new Size(42, 37);
            picNotificationIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            picNotificationIcon.TabIndex = 7;
            picNotificationIcon.TabStop = false;
            // 
            // lblNotification
            // 
            lblNotification.BackColor = Color.Transparent;
            lblNotification.Font = new Font("Inter", 10.2F, FontStyle.Bold);
            lblNotification.ForeColor = Color.White;
            lblNotification.Location = new Point(54, 19);
            lblNotification.Name = "lblNotification";
            lblNotification.Size = new Size(284, 29);
            lblNotification.TabIndex = 9;
            lblNotification.Text = "lblNotification";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Image = Properties.Resources.close;
            btnClose.InitialImage = (Image)resources.GetObject("btnClose.InitialImage");
            btnClose.Location = new Point(450, 11);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(23, 21);
            btnClose.SizeMode = PictureBoxSizeMode.Zoom;
            btnClose.TabIndex = 29;
            btnClose.TabStop = false;
            btnClose.Click += btnClose_Click;
            // 
            // NotificationInRoom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(117, 164, 127);
            Controls.Add(btnClose);
            Controls.Add(lblNotification);
            Controls.Add(picNotificationIcon);
            Name = "NotificationInRoom";
            Size = new Size(491, 60);
            ((System.ComponentModel.ISupportInitialize)picNotificationIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnClose).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox picNotificationIcon;
        private SiticoneNetCoreUI.SiticoneLabel lblNotification;
        private PictureBox btnClose;
    }
}
