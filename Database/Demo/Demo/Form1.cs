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


        private async void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    // connect Collections and Documents
            //    DocumentReference dr = db.Collection("users").Document("user_123");

            //    // dùng dictionary thay đổi
            //    Dictionary<string, object> dict = new Dictionary<string, object>()
            //    {
            //        {"Age", "20" },
            //        {"Email", "akwydongnai@gmail.com" },
            //        {"Name", "Đậu" }
            //    };
            //    // Note: Đoạn này sau này cho nhập nhỉ?
            //    await dr.UpdateAsync(dict);
            //    MessageBox.Show("Data Patched");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error: {ex.Message}");
            //}
            // ================================================================
            // try to update non-existed document
            try
            {
                // connect Collections and Documents
                DocumentReference dr = db.Collection("pomo").Document("user_123");

                // dùng dictionary thay đổi
                Dictionary<string, object> dict = new Dictionary<string, object>()
                {
                    {"Age", "20" }
                };
                await dr.UpdateAsync(dict);
                MessageBox.Show("Data Patched");
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


    }
}
