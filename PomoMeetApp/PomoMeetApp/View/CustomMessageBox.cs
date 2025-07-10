using System;
using System.Drawing;
using System.Windows.Forms;

namespace PomoMeetApp.View
{
    public partial class CustomMessageBox : Form
    {
        public enum MessageBoxMode
        {
            OK,
            YesNo
        }

        public CustomMessageBox(string message, string title, MessageBoxMode mode)
        {
            InitializeComponent();

            // Thiết lập cơ bản cho form
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.StartPosition = FormStartPosition.CenterParent;

            // Thiết lập tiêu đề
            lb_Title.AutoSize = true;
            lb_Title.Text = title;
            CenterControl(lb_Title, pn_Title);

            pn_Title.Resize += (s, e) =>
            {
                CenterControl(lb_Title, pn_Title);
            };

            // Thiết lập nội dung thông báo
            lb_Message.AutoSize = true;
            lb_Message.MaximumSize = new Size(440, 0); // cho phép xuống dòng
            lb_Message.Text = message;
            lb_Message.Left = (this.ClientSize.Width - lb_Message.Width) / 2;

            this.Resize += (s, e) =>
            {
                lb_Message.Left = (this.ClientSize.Width - lb_Message.Width) / 2;
                AdjustButtonPositions(mode);
            };

            // Tính toán vị trí nút
            int bottomY = lb_Message.Bottom + 20;
            btn_Ok.Top = bottomY;
            btn_Co.Top = bottomY;
            btn_No.Top = bottomY;

            // Xử lý chế độ
            switch (mode)
            {
                case MessageBoxMode.OK:
                    btn_Ok.Visible = true;
                    btn_Co.Visible = false;
                    btn_No.Visible = false;
                    this.AcceptButton = btn_Ok;
                    break;

                case MessageBoxMode.YesNo:
                    btn_Ok.Visible = false;
                    btn_Co.Visible = true;
                    btn_No.Visible = true;
                    this.AcceptButton = btn_Co;
                    this.CancelButton = btn_No;
                    break;
            }


            AdjustButtonPositions(mode);

            // Chiều cao tổng thể
            this.Height = bottomY + btn_Ok.Height + 40;
        }

        public static DialogResult Show(string message, string title = "Thông báo", MessageBoxMode mode = MessageBoxMode.OK)
        {
            var box = new CustomMessageBox(message, title, mode);
            return box.ShowDialog();
        }

        private void CustomMessageBox_Load(object sender, EventArgs e) { }

        // Hàm căn giữa control trong container
        private void CenterControl(Control control, Control container)
        {
            control.Left = (container.Width - control.Width) / 2;
            control.Top = (container.Height - control.Height) / 2;
        }

        // Hàm căn nút OK hoặc Yes/No
        private void AdjustButtonPositions(MessageBoxMode mode)
        {
            int formWidth = this.ClientSize.Width;
            int spacing = 20;

            if (mode == MessageBoxMode.OK && btn_Ok.Visible)
            {
                btn_Ok.Left = (formWidth - btn_Ok.Width) / 2;
            }
            else if (mode == MessageBoxMode.YesNo && btn_Co.Visible && btn_No.Visible)
            {
                int totalButtonWidth = btn_Co.Width + spacing + btn_No.Width;
                int startX = (formWidth - totalButtonWidth) / 2;
                btn_Co.Left = startX;
                btn_No.Left = startX + btn_Co.Width + spacing;
            }
        }

        private void btn_No_Click(object sender, EventArgs e)
        {

        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {

        }
    }
}
