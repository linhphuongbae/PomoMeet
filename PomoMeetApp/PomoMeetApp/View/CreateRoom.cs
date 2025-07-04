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
using System.Media;
using NAudio.Wave;
using static PomoMeetApp.View.CreateRoom;
using Microsoft.VisualBasic.ApplicationServices;


namespace PomoMeetApp.View
{
    public partial class CreateRoom : Form
    {

        private WaveOutEvent outputDevice;
        private WaveFileReader audioFile;
        private Image[] backgroundImages;
        private int MusicIndex = 0;
        private int BackgroundIndex = 0;
        private string[] songNames;
        private Image[] songImages;
        private byte[][] songBytes;
        private SoundPlayer[] songAudios;
        private string currentUserId;  // Biến lưu trữ userId

        public CreateRoom(string userId)
        {
            InitializeComponent();
            currentUserId = userId;   
        }

        private void PlaySongFromBytes(byte[] audioData)
        {
            StopMusic();

            var stream = new MemoryStream(audioData);
            audioFile = new WaveFileReader(stream);
            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();
            isPlaying = true;
        }

        private void StopMusic()
        {
            outputDevice?.Stop();
            audioFile?.Dispose();
            outputDevice?.Dispose();
            isPlaying = false;
        }

        private void CreateRoom_Load(object sender, EventArgs e)
        {
            backgroundImages = new Image[]
            {
                Properties.Resources.Image,
                Properties.Resources.studyBackground1,
                Properties.Resources.studyBackground2,
                Properties.Resources.studyBackground3,
            };

            pb_Background.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_Background.Image = backgroundImages[MusicIndex];

            songNames = new string[] { "4'O Clock", "5-32PM", "Alone", "Beneath the Rain", "Better Days", "Childhood Dreams", "Your Smile" };
            songImages = new Image[] {
                Properties.Resources.musicImage1,
                Properties.Resources.musicImage2,
                Properties.Resources.musicImage3,
                Properties.Resources.musicImage4,
                Properties.Resources.musicImage5,
                Properties.Resources.musicImage6,
                Properties.Resources.musicImage7
            };
            songBytes = new byte[][] {
                Properties.Resources._4_O_Clock,
                Properties.Resources._5_32PM,
                Properties.Resources.Alone,
                Properties.Resources.BeneathTheRain,
                Properties.Resources.BetterDays,
                Properties.Resources.ChildhoodDreams,
                Properties.Resources.YourSmile
            };

            // Khởi tạo SoundPlayer ban đầu
            songAudios = songBytes.Select(b => new SoundPlayer(new MemoryStream(b))).ToArray();
        }

        private async void sbtn_CreateRoom_Click(object sender, EventArgs e)
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
            var roomInfo = await CreateNewRoomAndGetInfo(roomName, roomMode, password);
           
            if(roomInfo != null)
            {
                var dashboard = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();
                if (dashboard != null)
                    dashboard.Hide();        // Ẩn Dashboard trước khi vào phòng

                // Cập nhật trạng thái người dùng thành "online" bằng Singleton
                await UserStatusManager.Instance.UpdateUserStatus(currentUserId, "in call");

                this.Hide(); // Ẩn ngay
                MeetingRoom meetingRoom = new MeetingRoom(currentUserId, roomInfo.RoomId);
                meetingRoom.ShowDialog();
                this.Close(); // Đóng sau khi họp xong
            }

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
                return null;
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
        private void Private_CheckedChanged(object sender, SiticoneNetCoreUI.SiticoneCheckBox.CheckedChangedEventArgs e)
        {
            if (scb_Private.Checked)
            {
                scb_Public.Checked = false;
                scb_Public.Enabled = false; // Khóa lại
                stb_RoomPassword.Visible = true;
                btn_TogglePassword.Visible = true; // Hiện nút hiển thị mật khẩu
                btn_TogglePassword.BringToFront();
            }
            else
            {
                scb_Public.Enabled = true;
                stb_RoomPassword.Visible = false;
                btn_TogglePassword.Visible = false; // Ẩn nút hiển thị mật khẩu
            }
        }

        private void Public_CheckedChanged(object sender, SiticoneNetCoreUI.SiticoneCheckBox.CheckedChangedEventArgs e)
        {
            if (scb_Public.Checked)
            {
                scb_Private.Checked = false;
                scb_Private.Enabled = false; // Khóa lại
                stb_RoomPassword.Visible = false;
                btn_TogglePassword.Visible = false; // Ẩn nút hiển thị mật khẩu
            }
            else
            {
                scb_Private.Enabled = true;
            }
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            BackgroundIndex++;
            if (BackgroundIndex >= backgroundImages.Length)
                BackgroundIndex = 0;
            pb_Background.Image = backgroundImages[BackgroundIndex];
        }

        private void btn_Pre_Click(object sender, EventArgs e)
        {
            BackgroundIndex--;
            if (BackgroundIndex < 0)
                BackgroundIndex = backgroundImages.Length - 1;
            pb_Background.Image = backgroundImages[BackgroundIndex];
        }

        bool isPlaying = false;

        private void btn_NextMusic_Click(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                outputDevice.Stop();
                stb_Play.BackgroundImage = Properties.Resources.play;
                isPlaying = false;
            }
            MusicIndex = (MusicIndex + 1) % songNames.Length;
            UpdateUI();
        }

        private void btn_PrevMusic_Click(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                outputDevice.Stop();
                stb_Play.BackgroundImage = Properties.Resources.play;
                isPlaying = false;
            }
            MusicIndex = (MusicIndex - 1 + songNames.Length) % songNames.Length;
            UpdateUI();
        }

        private void UpdateUI()
        {
            lbl_SongName.Text = songNames[MusicIndex];
            pb_picMusic.Image = songImages[MusicIndex];
        }

        private void stb_Play_Click(object sender, EventArgs e)
        {
            if (!isPlaying)
            {
                // Nếu chưa phát thì luôn load lại bài theo MusicIndex
                PlaySongFromBytes(songBytes[MusicIndex]);
                stb_Play.BackgroundImage = Properties.Resources.PauseMusic;
                isPlaying = true;
            }
            else
            {
                // Đang phát thì dừng
                outputDevice.Pause();
                stb_Play.BackgroundImage = Properties.Resources.play;
                isPlaying = false;
            }
        }

        bool isPasswordVisible = false;
        private void btn_TogglePassword_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            stb_RoomPassword.UseSystemPasswordChar = !isPasswordVisible;

            btn_TogglePassword.BackgroundImage = isPasswordVisible
                ? Properties.Resources.eye_open
                : Properties.Resources.eye_close;
        }

        private async void sbtn_InviteFriends_Click(object sender, EventArgs e)
        {
            // Tạo phòng trước
            string roomName = stb_RoomName.Text;
            string roomMode = GetRoomMode();

            if (string.IsNullOrEmpty(roomName))
            {
                MessageBox.Show("Vui lòng nhập tên phòng.");
                return;
            }

            if (string.IsNullOrEmpty(roomMode))
            {
                MessageBox.Show("Vui lòng chọn chế độ phòng (Private hoặc Public).");
                return;
            }

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
            // Tạo phòng và lấy thông tin
            var roomInfo = await CreateNewRoomAndGetInfo(roomName, roomMode, password);

            if (roomInfo != null)
            {
                var roomRequests = new RoomRequests(roomInfo.RoomId, roomName, roomMode, password, currentUserId, this);
                roomRequests.ShowDialog(this);
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thể tạo phòng. Vui lòng thử lại.");
            }
        }

        public async Task<RoomInfo> CreateNewRoomAndGetInfo(string roomName, string roomMode, string password)
        {
            try
            {
                var db = FirebaseConfig.database;

                string roomId = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();

                int pomodoro = (int)numUpDown_Pomodoro.Value;
                int shortBreak = (int)numUpDown_Break.Value;
                string hashedPassword = string.IsNullOrEmpty(password) ? "" : HashPassword(password);
                var room = new
                {
                    roomId = roomId,
                    room_name = roomName,
                    host_id = currentUserId, // Thay bằng user ID thực tế
                    type = roomMode,
                    password = hashedPassword,
                    created_at = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                    deleted_by_host = false,
                    members_status = new Dictionary<string, object>
                    {
                        {
                            currentUserId, new Dictionary<string, object>
                            {
                                { "user_id", currentUserId },
                                { "camera_on", true }, 
                                { "mic_on", false },     // Mặc định mic là tắt
                                { "speaker_on", true },  // Mặc định loa là bật
                            }
                        }
                    }
                };

                var roomRef = db.Collection("Room").Document(roomId);
                await roomRef.SetAsync(room);

                var Pomodoro_Sessions = new
                {
                    roomId = roomId,
                    countdown_time = pomodoro,
                    break_time = shortBreak,
                    music_id = MusicIndex,
                    background_id = BackgroundIndex,
                    created_at = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                };

                var pomodoroRef = db.Collection("Pomodoro_Sessions").Document(roomId);
                await pomodoroRef.SetAsync(Pomodoro_Sessions);

                return new RoomInfo { RoomId = roomId};
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi tạo phòng: {ex.Message}");
                return null;
            }
        }

        // Lớp helper để lưu thông tin phòng
        public class RoomInfo
        {
            public string RoomId { get; set; }
        }
    }
}
