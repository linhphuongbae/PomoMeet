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

        private async void siticoneButton2_Click(object sender, EventArgs e)
        {
            await FormTransition.FadeTo(this, new SignIn());
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
                MessageBox.Show("password does not match. Try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var userQuery = db.Collection("User").WhereEqualTo("Username", data.Username);
                var snapshot = await userQuery.GetSnapshotAsync();
                if (snapshot.Count > 0)
                {
                    MessageBox.Show("This username is already registered!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DocumentReference docRef = db.Collection("User").Document(data.UserId);
                await docRef.SetAsync(data);

                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await FormTransition.FadeTo(this, new SignIn());
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
            string userID = Guid.NewGuid().ToString();
            string email = txtEmail.Text.Trim();
            return new UserData()
            {
                UserId = userID,
                Username = username,
                Password = passwd,
                Email = email
            };
        }

        private void tbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignUp.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignUp.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void tbPasswordConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignUp.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void siticoneCheckBox1_Click(object sender, EventArgs e)
        {
            if (!siticoneCheckBox1.Checked)
            {
                tbPassword.UseSystemPasswordChar = false;
                tbPasswordConfirm.UseSystemPasswordChar = false;
            }
            else
            {
                tbPasswordConfirm.UseSystemPasswordChar = true;
                tbPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
