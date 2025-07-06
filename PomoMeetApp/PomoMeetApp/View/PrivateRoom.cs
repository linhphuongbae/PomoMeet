using Microsoft.VisualBasic.ApplicationServices;
using PomoMeetApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Diagnostics;

namespace PomoMeetApp.View
{
    public partial class PrivateRoom : Form
    {
        private string currentUserId; 
        private string currentRoomId;
        private RoomData joinedRoomData;

        public PrivateRoom(string userId, string roomId)
        {
            currentUserId = userId;
            currentRoomId = roomId;
            InitializeComponent();
        }

        private async void sbtn_JoinRoom_Click(object sender, EventArgs e)
        {
            var room = await GetRoomByroomId(currentRoomId);
            if (room == null)
            {
                CustomMessageBox.Show("Không tìm thấy phòng.");
                return;
            }

            joinedRoomData = room;

            if (room.type == "Private")
            {
                lb_Password.Visible = true; // Hiện label mật khẩu
                stb_Password.Visible = true; // Hiện textbox mật khẩu
                btn_TogglePassword.Visible = true; // Hiện nút hiện mật khẩu
                btn_TogglePassword.BringToFront();
                // Nếu phòng là Private, yêu cầu nhập mật khẩu
                string enteredPassword = stb_Password.Text.Trim(); // Nhận mật khẩu từ textbox

                if (string.IsNullOrEmpty(enteredPassword))
                {
                    CustomMessageBox.Show("Vui lòng nhập mật khẩu.");
                    return;
                }

                // So sánh mật khẩu đã nhập với mật khẩu trong phòng
                string hashedPassword = HashPassword(enteredPassword);

                if (hashedPassword == joinedRoomData.password)
                {
                    // Mật khẩu đúng, vào phòng
                    OpenMeetingRoom(currentUserId, joinedRoomData.room_id);
                }
                else
                {
                    CustomMessageBox.Show("Mật khẩu không chính xác.");
                }
            }
        }
        private async Task<RoomData> GetRoomByroomId(string roomId)
        {
            var db = FirebaseConfig.database;
            var query = db.Collection("Room").WhereEqualTo("roomId", roomId);
            var snapshot = await query.GetSnapshotAsync();

            if (snapshot.Count == 0)
                return null;

            var doc = snapshot.Documents.First();
            var data = doc.ToDictionary();

            return new RoomData
            {
                room_id = doc.Id,
                room_name = data["room_name"]?.ToString(),
                type = data["type"]?.ToString(),
                password = data["password"]?.ToString(),
                host_id = data["host_id"]?.ToString()
            };
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        private async void OpenMeetingRoom(string userId, string roomId)
        {
            // Gọi form phòng học truyền dữ liệu người tham gia
            var db = FirebaseConfig.database;
            var roomRef = db.Collection("Room").Document(roomId);

            // Cập nhật mảng members, thêm ID người tham gia vào
            try
            {

                // Tạo thông tin trạng thái mặc định của thành viên
                Dictionary<string, object> memberData = new Dictionary<string, object>
                {
                    { "camera_on", false },
                    { "mic_on", false },
                    { "speaker_on", true },
                    { "user_id", currentUserId },
                };

                Dictionary<string, object> updates = new Dictionary<string, object>
                {
                    { $"members_status.{currentUserId}", memberData }
                };

                await roomRef.UpdateAsync(updates);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Lỗi khi thêm trạng thái thành viên vào phòng: " + ex.Message);
            }


            MeetingRoom meetingRoom = new MeetingRoom(userId, roomId);
            meetingRoom.ShowDialog();
            this.Close();
        }

        bool isPasswordVisible = false;

        private void btn_TogglePassword_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            stb_Password.UseSystemPasswordChar = !isPasswordVisible;

            btn_TogglePassword.BackgroundImage = isPasswordVisible
                ? Properties.Resources.eye_open
                : Properties.Resources.eye_close;
        }
    }
}
