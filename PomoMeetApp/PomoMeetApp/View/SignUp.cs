using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PomoMeetApp.Classes;
using Google.Cloud.Firestore;

namespace PomoMeetApp.View
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            Hide();
            SingIn sg = new SingIn();
            sg.ShowDialog();
            Close();
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {

        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void SignUp_Load_1(object sender, EventArgs e)
        {

        }

        private async void btnSignUp_Click(object sender, EventArgs e)
        {

            var db = FirebaseConfig.database;
            var data = getData();
            string passwordConfirm = tbPasswordConfirm.Text;

            // check rỗng
            if (string.IsNullOrWhiteSpace(data.Username) || string.IsNullOrWhiteSpace(data.Password))
            {
                MessageBox.Show("Please enter both username and password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // check confirmed password
            if (passwordConfirm != Security.Decrypt(data.Password))
            {
                MessageBox.Show("Password does not match. Try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DocumentReference docRef = db.Collection("User").Document(data.Username);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    MessageBox.Show("This username is already registered!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                await docRef.SetAsync(data);

                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Registration failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private UserData getData()
        {
            string username = tbUsername.Text.Trim();
            string passwd = Security.Encrypt(tbPassword.Text);

            return new UserData()
            {
                Username = username,
                Password = passwd
            };
        }
    }
}
