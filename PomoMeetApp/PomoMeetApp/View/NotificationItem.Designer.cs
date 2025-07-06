namespace PomoMeetApp.View
{
    partial class NotificationItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Declare the missing field for panelSeparator
        private Panel panelSeparator;

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
            picAvatar = new PictureBox();
            lblText = new Label();
            lblTime = new Label();
            btnAccept = new Button();
            btnDecline = new Button();
            panelSeparator = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            SuspendLayout();
            // 
            // picAvatar
            // 
            picAvatar.Location = new Point(18, 13);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(71, 64);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.Font = new Font("Inter", 10F, FontStyle.Bold);
            lblText.Location = new Point(95, 16);
            lblText.Name = "lblText";
            lblText.Size = new Size(96, 24);
            lblText.TabIndex = 1;
            lblText.Text = "Username";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Inter", 8F);
            lblTime.ForeColor = Color.Green;
            lblTime.Location = new Point(95, 38);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(42, 21);
            lblTime.TabIndex = 2;
            lblTime.Text = "Time";
            // 
            // btnAccept
            // 
            btnAccept.BackColor = Color.FromArgb(117, 164, 127);
            btnAccept.FlatStyle = FlatStyle.Flat;
            btnAccept.Font = new Font("Inter", 7F);
            btnAccept.ForeColor = Color.White;
            btnAccept.Location = new Point(535, 8);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(80, 32);
            btnAccept.TabIndex = 3;
            btnAccept.Text = "Chấp nhận";
            btnAccept.UseVisualStyleBackColor = false;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnDecline
            // 
            btnDecline.BackColor = Color.FromArgb(230, 230, 230);
            btnDecline.FlatStyle = FlatStyle.Flat;
            btnDecline.Font = new Font("Inter", 7F);
            btnDecline.ForeColor = Color.Black;
            btnDecline.Location = new Point(535, 46);
            btnDecline.Name = "btnDecline";
            btnDecline.Size = new Size(80, 32);
            btnDecline.TabIndex = 4;
            btnDecline.Text = "Từ chối";
            btnDecline.UseVisualStyleBackColor = false;
            // 
            // panelSeparator
            // 
            panelSeparator.BackColor = Color.LightGray;
            panelSeparator.Dock = DockStyle.Bottom;
            panelSeparator.Location = new Point(0, 88);
            panelSeparator.Name = "panelSeparator";
            panelSeparator.Size = new Size(635, 1);
            panelSeparator.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Inter", 8F);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(95, 57);
            label1.Name = "label1";
            label1.Size = new Size(278, 21);
            label1.TabIndex = 6;
            label1.Text = "Mời bạn tham gia phòng học cùng với họ";
            // 
            // NotificationItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label1);
            Controls.Add(panelSeparator);
            Controls.Add(btnDecline);
            Controls.Add(btnAccept);
            Controls.Add(lblTime);
            Controls.Add(lblText);
            Controls.Add(picAvatar);
            Name = "NotificationItem";
            Size = new Size(635, 89);
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picAvatar;
        private Label lblText;
        private Label lblTime;
        private Button btnAccept;
        private Button btnDecline;
        private Label label1;
    }
}