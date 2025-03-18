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

                await db.Collection("users").Document("user_123").SetAsync(data);
                MessageBox.Show("Da gui du lieu len Firestore!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Loi: {ex.Message}");
            }
        }
    }
}
