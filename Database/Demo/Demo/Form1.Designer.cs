namespace Demo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_TaoDuLieu = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // btn_TaoDuLieu
            // 
            btn_TaoDuLieu.Location = new Point(45, 186);
            btn_TaoDuLieu.Name = "btn_TaoDuLieu";
            btn_TaoDuLieu.Size = new Size(133, 44);
            btn_TaoDuLieu.TabIndex = 0;
            btn_TaoDuLieu.Text = "Tạo dữ liệu";
            btn_TaoDuLieu.UseVisualStyleBackColor = true;
            btn_TaoDuLieu.Click += btn_TaoDuLieu_Click;
            // 
            // button1
            // 
            button1.Location = new Point(228, 186);
            button1.Name = "button1";
            button1.Size = new Size(133, 44);
            button1.TabIndex = 1;
            button1.Text = "Sửa dữ liệu";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(btn_TaoDuLieu);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_TaoDuLieu;
        private Button button1;
    }
}
