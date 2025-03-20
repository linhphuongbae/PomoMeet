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
            btn_SuaDocument = new Button();
            btn_Xoa = new Button();
            btn_XoaTruong = new Button();
            btn_ThemTruong = new Button();
            btn_ThemDocumentMoi = new Button();
            btn_GuiDuLieuNull = new Button();
            btn_SuaTruong = new Button();
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
            // 
            // btn_SuaDocument
            // 
            btn_SuaDocument.Location = new Point(228, 186);
            btn_SuaDocument.Name = "btn_SuaDocument";
            btn_SuaDocument.Size = new Size(133, 44);
            btn_SuaDocument.TabIndex = 1;
            btn_SuaDocument.Text = "Sửa document";
            btn_SuaDocument.UseVisualStyleBackColor = true;
            btn_SuaDocument.Click += btn_SuaDocument_Click;
            // 
            // btn_Xoa
            // 
            btn_Xoa.Location = new Point(416, 186);
            btn_Xoa.Name = "btn_Xoa";
            btn_Xoa.Size = new Size(137, 44);
            btn_Xoa.TabIndex = 2;
            btn_Xoa.Text = "Xóa dữ liệu";
            btn_Xoa.UseVisualStyleBackColor = true;
            btn_Xoa.Click += btn_Xoa_Click;
            // 
            // btn_XoaTruong
            // 
            btn_XoaTruong.Location = new Point(592, 186);
            btn_XoaTruong.Name = "btn_XoaTruong";
            btn_XoaTruong.Size = new Size(137, 44);
            btn_XoaTruong.TabIndex = 3;
            btn_XoaTruong.Text = "Xóa một trường";
            btn_XoaTruong.UseVisualStyleBackColor = true;
            btn_XoaTruong.Click += btn_XoaTruong_Click;
            // 
            // btn_ThemTruong
            // 
            btn_ThemTruong.Location = new Point(45, 270);
            btn_ThemTruong.Name = "btn_ThemTruong";
            btn_ThemTruong.Size = new Size(184, 44);
            btn_ThemTruong.TabIndex = 4;
            btn_ThemTruong.Text = "Thêm một trường";
            btn_ThemTruong.UseVisualStyleBackColor = true;
            btn_ThemTruong.Click += btn_ThemTruong_Click;
            // 
            // btn_ThemDocumentMoi
            // 
            btn_ThemDocumentMoi.Location = new Point(302, 270);
            btn_ThemDocumentMoi.Name = "btn_ThemDocumentMoi";
            btn_ThemDocumentMoi.Size = new Size(188, 44);
            btn_ThemDocumentMoi.TabIndex = 5;
            btn_ThemDocumentMoi.Text = "Thêm một Document";
            btn_ThemDocumentMoi.UseVisualStyleBackColor = true;
            btn_ThemDocumentMoi.Click += btn_ThemDocumentMoi_Click;
            // 
            // btn_GuiDuLieuNull
            // 
            btn_GuiDuLieuNull.Location = new Point(45, 359);
            btn_GuiDuLieuNull.Name = "btn_GuiDuLieuNull";
            btn_GuiDuLieuNull.Size = new Size(179, 44);
            btn_GuiDuLieuNull.TabIndex = 6;
            btn_GuiDuLieuNull.Text = "Gửi dữ liệu null";
            btn_GuiDuLieuNull.UseVisualStyleBackColor = true;
            btn_GuiDuLieuNull.Click += btn_GuiDuLieuNull_Click;
            // 
            // btn_SuaTruong
            // 
            btn_SuaTruong.Location = new Point(592, 270);
            btn_SuaTruong.Name = "btn_SuaTruong";
            btn_SuaTruong.Size = new Size(133, 44);
            btn_SuaTruong.TabIndex = 7;
            btn_SuaTruong.Text = "Sửa trường";
            btn_SuaTruong.UseVisualStyleBackColor = true;
            btn_SuaTruong.Click += btn_SuaTruong_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_SuaTruong);
            Controls.Add(btn_GuiDuLieuNull);
            Controls.Add(btn_ThemDocumentMoi);
            Controls.Add(btn_ThemTruong);
            Controls.Add(btn_XoaTruong);
            Controls.Add(btn_Xoa);
            Controls.Add(btn_SuaDocument);
            Controls.Add(btn_TaoDuLieu);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_TaoDuLieu;
        private Button btn_SuaDocument;
        private Button btn_Xoa;
        private Button btn_XoaTruong;
        private Button btn_ThemTruong;
        private Button btn_ThemDocumentMoi;
        private Button btn_GuiDuLieuNull;
        private Button btn_SuaTruong;
    }
}
