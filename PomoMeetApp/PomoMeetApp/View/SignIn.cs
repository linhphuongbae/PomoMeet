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
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Oauth2.v2;
using Google.Apis.Oauth2.v2.Data;
using Microsoft.VisualBasic.ApplicationServices;
using SiticoneNetCoreUI;

namespace PomoMeetApp.View
{
    public partial class SignIn : Form
    {
        private string username = "";
        public SignIn()
        {
            InitializeComponent();
        }

        private async void BackToRegs_Click(object sender, EventArgs e)
        {
            await FormTransition.FadeTo(this, new SignUp());
        }

        private async void btnLogIn_Click(object sender, EventArgs e)
        {
            username = tbUsername.Text.Trim();
            string password = tbPassword.Text;

            var db = FirebaseConfig.database;
            try
            {
                var userQuery = db.Collection("User").WhereEqualTo("Username", username);
                QuerySnapshot qr = await userQuery.GetSnapshotAsync();

                if (qr.Count == 0)
                {
                    MessageBox.Show("Username doesn't exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DocumentSnapshot snapshot = qr.Documents[0];
                UserData data = snapshot.ConvertTo<UserData>();
                string userId = snapshot.Id; // Lấy document ID (sẽ là userId)
                UserSession.CurrentUser = data;

                if (data != null)
                {
                    if (password == Security.Decrypt(data.Password))
                    {
                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Wrong password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                await FormTransition.FadeTo(this, new Dashboard(userId));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSignInGG_Click(object sender, EventArgs e)
        {
            try
            {
                using var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read);

                var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    new[] { "https://www.googleapis.com/auth/userinfo.email", "https://www.googleapis.com/auth/userinfo.profile" },
                    Guid.NewGuid().ToString(), CancellationToken.None, new FileDataStore("Google0AuthToken", false));

                if (credential?.Token != null && credential.Token.IsStale)
                {
                    await credential.RefreshTokenAsync(CancellationToken.None);
                }

                var oAuthService = new Oauth2Service(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "PomoMeet"
                });

                var userInfo = await oAuthService.Userinfo.Get().ExecuteAsync();
                string email = userInfo.Email;
                var db = FirebaseConfig.database;
                Query emailQuery = db.Collection("User").WhereEqualTo("Email", email);
                QuerySnapshot emailQuerySnapshot = await emailQuery.GetSnapshotAsync();

                string userId = ""; // Khai báo userId ở phạm vi lớn hơn

                if (emailQuerySnapshot.Count == 0)
                {
                    using (var EnterUsername = new EnterUsername())
                    {
                        if (EnterUsername.ShowDialog() == DialogResult.OK)
                        {
                            userId = Guid.NewGuid().ToString();
                            string username = EnterUsername.EnteredUsername; // Lấy username từ dialog

                            UserData userData = new UserData()
                            {
                                UserId = userId,
                                Username = username,
                                Password = null,
                                Email = email
                            };

                            await db.Collection("User").Document(userId).SetAsync(userData);
                            MessageBox.Show("Success Login using Gmail!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            return; // Người dùng hủy bỏ
                        }
                    }
                }
                else
                {
                    // Lấy userId từ tài liệu hiện có
                    userId = emailQuerySnapshot.Documents[0].Id;
                    MessageBox.Show("Success Login using Gmail!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await FormTransition.FadeTo(this, new Dashboard(userId));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogIn.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogIn.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {

        }

        private void SingIn_Load(object sender, EventArgs e)
        {

        }

        private void ShowPass_Click(object sender, EventArgs e)
        {
            if (!ShowPass.Checked)
            {
                tbPassword.UseSystemPasswordChar = false;
            }
            else
            {
                tbPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
