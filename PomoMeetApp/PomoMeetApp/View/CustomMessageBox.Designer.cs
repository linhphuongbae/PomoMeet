namespace PomoMeetApp.View
{
    partial class CustomMessageBox
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
            lb_Message = new Label();
            btn_Yes = new Button();
            btn_No = new Button();
            lb_Title = new Label();
            pn_Title = new Panel();
            btn_Ok = new Button();
            btn_Co = new Button();
            pn_Title.SuspendLayout();
            SuspendLayout();
            // 
            // lb_Message
            // 
            lb_Message.AutoSize = true;
            lb_Message.Font = new Font("Inter", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_Message.Location = new Point(43, 81);
            lb_Message.Name = "lb_Message";
            lb_Message.Size = new Size(368, 28);
            lb_Message.TabIndex = 1;
            lb_Message.Text = "Bạn có muốn xóa phòng này không ?";
            // 
            // btn_Yes
            // 
            btn_Yes.BackColor = Color.FromArgb(117, 164, 127);
            btn_Yes.DialogResult = DialogResult.Yes;
            btn_Yes.Font = new Font("Inter", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Yes.ForeColor = Color.White;
            btn_Yes.Location = new Point(43, 130);
            btn_Yes.Name = "btn_Yes";
            btn_Yes.Size = new Size(0, 0);
            btn_Yes.TabIndex = 2;
            btn_Yes.Text = "Có";
            btn_Yes.UseVisualStyleBackColor = false;
            // 
            // btn_No
            // 
            btn_No.BackColor = Color.FromArgb(117, 164, 127);
            btn_No.DialogResult = DialogResult.No;
            btn_No.Font = new Font("Inter", 10.2F, FontStyle.Bold);
            btn_No.ForeColor = Color.White;
            btn_No.Location = new Point(299, 130);
            btn_No.Name = "btn_No";
            btn_No.Size = new Size(108, 36);
            btn_No.TabIndex = 3;
            btn_No.Text = "Không";
            btn_No.UseVisualStyleBackColor = false;
            btn_No.Visible = false;
            btn_No.Click += btn_No_Click;
            // 
            // lb_Title
            // 
            lb_Title.AutoSize = true;
            lb_Title.Font = new Font("Inter", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_Title.ForeColor = Color.White;
            lb_Title.Location = new Point(143, 9);
            lb_Title.Name = "lb_Title";
            lb_Title.Size = new Size(163, 40);
            lb_Title.TabIndex = 0;
            lb_Title.Text = "Thông báo";
            lb_Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pn_Title
            // 
            pn_Title.BackColor = Color.FromArgb(117, 164, 127);
            pn_Title.Controls.Add(lb_Title);
            pn_Title.Location = new Point(-2, 0);
            pn_Title.Name = "pn_Title";
            pn_Title.Size = new Size(460, 58);
            pn_Title.TabIndex = 0;
            // 
            // btn_Ok
            // 
            btn_Ok.AutoSize = true;
            btn_Ok.BackColor = Color.FromArgb(117, 164, 127);
            btn_Ok.DialogResult = DialogResult.OK;
            btn_Ok.Font = new Font("Inter", 10.2F, FontStyle.Bold);
            btn_Ok.ForeColor = Color.White;
            btn_Ok.Location = new Point(176, 130);
            btn_Ok.Name = "btn_Ok";
            btn_Ok.Size = new Size(92, 36);
            btn_Ok.TabIndex = 4;
            btn_Ok.Text = "OK";
            btn_Ok.UseVisualStyleBackColor = false;
            btn_Ok.Click += btn_Ok_Click;
            // 
            // btn_Co
            // 
            btn_Co.BackColor = Color.FromArgb(117, 164, 127);
            btn_Co.DialogResult = DialogResult.Yes;
            btn_Co.Font = new Font("Inter", 10.2F, FontStyle.Bold);
            btn_Co.ForeColor = Color.White;
            btn_Co.Location = new Point(43, 130);
            btn_Co.Name = "btn_Co";
            btn_Co.Size = new Size(108, 36);
            btn_Co.TabIndex = 5;
            btn_Co.Text = "Có";
            btn_Co.UseVisualStyleBackColor = false;
            btn_Co.Visible = false;
            // 
            // CustomMessageBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(457, 186);
            Controls.Add(btn_Co);
            Controls.Add(btn_Ok);
            Controls.Add(btn_No);
            Controls.Add(btn_Yes);
            Controls.Add(lb_Message);
            Controls.Add(pn_Title);
            Name = "CustomMessageBox";
            Text = "CustomMessageBox";
            Load += CustomMessageBox_Load;
            pn_Title.ResumeLayout(false);
            pn_Title.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lb_Message;
        private Button btn_Yes;
        private Button btn_No;
        private Label lb_Title;
        private Panel pn_Title;
        private Button btn_Ok;
        private Button btn_Co;
    }
}