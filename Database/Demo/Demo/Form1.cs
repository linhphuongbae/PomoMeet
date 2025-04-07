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
            //Thiet lap duong dan json trong bien moi truong
            //string jsonPath = @"/path/to/your/firebase-key.json";
            //Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", jsonPath);

            //Ket noi den Firestore
            db = FirestoreDb.Create("fir-eddc8");
            MessageBox.Show("Ket noi firebase thanh cong");
        }

        private async void btn_TaoDuLieu_Click(object sender, EventArgs e)
        {
            try
            {
                var data = new
                {
                    Name = "Nguyen Van B",
                    Age = 22,
                    Email = "nguyenvanb@example.com"
                };

                await db.Collection("users").Document("user_12").SetAsync(data);
                MessageBox.Show("Da gui du lieu len Firestore!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Loi: {ex.Message}");
            }
        }

        // Sửa document
        private async void btn_SuaDocument_Click(object sender, EventArgs e)
        {
            try
            {
                // connect Collections and Documents
                DocumentReference dr = db.Collection("users").Document("user_123");

                // dùng dictionary thay đổi
                Dictionary<string, object> dict = new Dictionary<string, object>()
                {
                    {"Age", "20" },
                    {"Email", "akwydongnai@gmail.com" },
                    {"Name", "Đậu" }
                };
                // Note: Đoạn này sau này cho nhập nhỉ?
                await dr.SetAsync(dict, SetOptions.MergeAll); // dùng setAsync với SetOptions

                MessageBox.Show("Document Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            // ================================================================
            // try to update non-existed document
            //try
            //{
            //    // connect Collections and Documents
            //    DocumentReference dr = db.Collection("pomo").Document("user_123");

            //    // dùng dictionary thay đổi
            //    Dictionary<string, object> dict = new Dictionary<string, object>()
            //    {
            //        {"Age", "20" }
            //    };
            //    await dr.UpdateAsync(dict);
            //    MessageBox.Show("Data Patched");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error: {ex.Message}");
            //}

        }
        // Sửa 1 hoặc nhiều trường trong document
        private async void btn_SuaTruong_Click(object sender, EventArgs e)
        {
            try
            {
                DocumentReference dr = db.Collection("users").Document("user_123");
                Dictionary<string, object> data = new Dictionary<string, object>()
                {
                        {"Age", "22" },
                        {"Name", "đaulungqua"}
                };

                await dr.UpdateAsync(data);
                MessageBox.Show("Fields Updated!");
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }


        //Xoa 1 document
        private async void btn_Xoa_Click(object sender, EventArgs e)
        {
            DocumentReference docRef = db.Collection("users").Document("user_12");
            await docRef.DeleteAsync();
            MessageBox.Show("Document đã bị xóa!");

        }
        //Xoa 1 truong trong document
        private async void btn_XoaTruong_Click(object sender, EventArgs e)
        {
            DocumentReference docRef = db.Collection("users").Document("user_12");
            Dictionary<string, object> updates = new Dictionary<string, object>
            {
                { "Age", FieldValue.Delete }
            };

            await docRef.UpdateAsync(updates);
            MessageBox.Show("Trường Age đã bị xóa!");
        }

        //Them 1 truong trong document
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

        //Them 1 document
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

        //Gui du lieu null
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
                await docRef.SetAsync(newUser);  // Gửi toàn bộ, kể cả trường null

                MessageBox.Show("Đã gửi dữ liệu lên Firestore cả trường null).");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }


    }
}