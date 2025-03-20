using Google.Cloud.Firestore;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private FirestoreDb db;

        private void Form1_Load(object sender, EventArgs e)
        {
            string jsonPath = @"D:\Downloads_D\HK4_UIT\LTM_NT106_P22_ANTT\DoAnLTM\FirebaseKeys\fir-eddc8-firebase-adminsdk-fbsvc-5e69e54f20.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", jsonPath);

            //Ket noi den Firestore
            db = FirestoreDb.Create("fir-eddc8");
            MessageBox.Show("Ket noi firebase thanh cong");
        }

        private async void btn_ThemTruong_Click(object sender, EventArgs e)
        {
            try
            {
                DocumentReference docRef = db.Collection("users").Document("user_123");

                Dictionary<string, object> updates = new Dictionary<string, object>
        {
            { "PhoneNumber", "0123456789" }  // Thêm trường mới
        };

                await docRef.UpdateAsync(updates);
                MessageBox.Show("Đã thêm trường mới vào Firestore!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        private async void btn_ThemDocumentMoi_Click(object sender, EventArgs e)
        {
            try
            {
                var newUser = new
                {
                    Name = "Nguyen Van C",
                    Age = 30,
                    Email = "nguyenvanc@example.com"
                };

                DocumentReference newDoc = await db.Collection("users").AddAsync(newUser);
                MessageBox.Show($"Đã tạo document mới với ID: {newDoc.Id}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        private async void btn_GuiDuLieuNull_Click(object sender, EventArgs e)
        {
            try
            {
                var newUser = new Dictionary<string, object>
                {
                    { "Name", "Nguyen Van D" },
                    { "Age", null },  // Trường này sẽ bị bỏ qua
                    { "Email", "nguyenvand@example.com" }
                };

                DocumentReference docRef = db.Collection("users").Document("user_456");
                await docRef.SetAsync(newUser, SetOptions.MergeFields("Name", "Email"));

                MessageBox.Show("Đã gửi dữ liệu lên Firestore (bỏ qua trường null).");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
    }
}
