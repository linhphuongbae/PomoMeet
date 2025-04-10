using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;
using PomoMeetApp.Classes;

namespace PomoMeetApp.View
{
    public partial class SingIn : Form
    {
        public SingIn()
        {
            InitializeComponent();
        }

        private void BackToRegs_Click(object sender, EventArgs e)
        {
            Hide();
            SignUp sg = new SignUp();
            sg.ShowDialog();
            Close();
        }

        private async void btnLogIn_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text.Trim();
            string password = tbPassword.Text;

            var db = FirebaseConfig.database;
            try
            {
                DocumentReference docRef = db.Collection("User").Document(username);
                UserData data = await docRef.GetSnapshotAsync().ContinueWith(task => task.Result.ConvertTo<UserData>());

                if (data != null)
                {
                    if (password == Security.Decrypt(data.Password))
                    {
                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("username or password is wrong", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Login failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
