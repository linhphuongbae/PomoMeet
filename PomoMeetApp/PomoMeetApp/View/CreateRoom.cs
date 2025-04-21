using PomoMeetApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace PomoMeetApp.View
{
    public partial class CreateRoom : Form
    {
        public CreateRoom()
        {
            InitializeComponent();
        }

        private void sbtn_CreateRoom_Click(object sender, EventArgs e)
        {
            string roomName = stb_RoomName.Text; // Lấy tên phòng từ TextBox
            string roomMode = GetRoomMode();    // Lấy chế độ phòng đã chọn

            if (string.IsNullOrEmpty(roomName))
            {
                MessageBox.Show("Vui lòng nhập tên phòng.");
                return;
            }

            if (string.IsNullOrEmpty(roomMode)) // Kiểm tra xem người dùng đã chọn chế độ hay chưa
            {
                MessageBox.Show("Vui lòng chọn chế độ phòng (Private hoặc Public).");
                return;
            }

            // Kiểm tra mật khẩu nếu chế độ là Private
            string password = "";
            if (roomMode == "Private" && !string.IsNullOrEmpty(stb_RoomPassword.Text))
            {
                password = stb_RoomPassword.Text;
            }
            else if (roomMode == "Private" && string.IsNullOrEmpty(stb_RoomPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                return;
            }

            // Tạo phòng với thông tin đã nhập
            CreateNewRoom(roomName, roomMode, password);
        }

        private string GetRoomMode()
        {
            if (scb_Private.Checked)
            {
                return "Private";
            }
            else if (scb_Public.Checked)
            {
                return "Public";
            }
            else
                return "Unknown";
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
        // Hàm tạo phòng (kết nối cơ sở dữ liệu hoặc hệ thống khác)
        private async void CreateNewRoom(string roomName, string roomMode, string password)
        {
            try
            {
                // Khởi tạo Firestore
                var db = FirebaseConfig.database;

                // Tạo roomId tự động
                string roomId = Guid.NewGuid().ToString();

                // Mã hóa password
                string hashedPassword = string.IsNullOrEmpty(password) ? "" : HashPassword(password);


                // Tạo thông tin phòng
                var room = new
                {
                    roomId = roomId,
                    room_name = roomName,
                    invite_code = Guid.NewGuid().ToString().Substring(0, 6), // Mã mời phòng ngẫu nhiên
                    host_id = "guest",  // Tạm thời lưu host_id là "guest"
                    type = roomMode,
                    password = hashedPassword,
                    created_at = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")
                };

                // Lưu vào Firestore
                var roomRef = db.Collection("Room").Document(roomId);
                await roomRef.SetAsync(room);

                MessageBox.Show($"Phòng '{roomName}' đã được tạo với chế độ {roomMode}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi tạo phòng: {ex.Message}");
            }

        }
        private void Private_CheckedChanged(object sender, SiticoneNetCoreUI.SiticoneCheckBox.CheckedChangedEventArgs e)
        {
            if (scb_Private.Checked)
            {
                scb_Public.Checked = false;
                scb_Public.Enabled = false; // Khóa lại
                stb_RoomPassword.Visible = true;
            }
            else
            {
                scb_Public.Enabled = true;
                stb_RoomPassword.Visible = false;
            }
        }

        private void Public_CheckedChanged(object sender, SiticoneNetCoreUI.SiticoneCheckBox.CheckedChangedEventArgs e)
        {
            if (scb_Public.Checked)
            {
                scb_Private.Checked = false;
                scb_Private.Enabled = false; // Khóa lại
                stb_RoomPassword.Visible = false;
            }
            else
            {
                scb_Private.Enabled = true;
                stb_RoomPassword.Visible = true;
            }
        }
    }
}
