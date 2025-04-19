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

namespace PomoMeetApp.View
{
    public partial class SingIn : Form
    {
        public SingIn()
        {
            InitializeComponent();
        }

        private async void BackToRegs_Click(object sender, EventArgs e)
        {
            await FormTransition.FadeTo(this, new SignUp());
        }

        private async void btnLogIn_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text.Trim();
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


                if (data != null)
                {
                    if (password == Security.Decrypt(data.Password))
                    {
                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Wrong password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                await FormTransition.FadeTo(this, new Dashboard());
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
                     Guid.NewGuid().ToString(), CancellationToken.None, new FileDataStore("Google0AuthToken", false) // ko lưu token
                );

                if (credential?.Token != null && credential.Token.IsStale)
                {
                    await credential.RefreshTokenAsync(CancellationToken.None);
                }


                var oAuthService = new Oauth2Service(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "PomoMeet"
                });
                // gửi yêu cầu tới google để lấy thông tin user
                var userInfo = await oAuthService.Userinfo.Get().ExecuteAsync();

                // Xử lí các kiểu nè
                string email = userInfo.Email;
                var db = FirebaseConfig.database;
                Query emailQuery = db.Collection("User").WhereEqualTo("Email", email);
                QuerySnapshot emailQuerySnapshot = await emailQuery.GetSnapshotAsync();

                if (emailQuerySnapshot.Count == 0)
                {
                    using (var EnterUsername = new EnterUsername())
                    {
                        if (EnterUsername.ShowDialog() == DialogResult.OK)
                        {

                            string username = EnterUsername.EnteredUsername;

                            UserData userData = new UserData()
                            {
                                Username = username,
                                Password = null,
                                Email = email
                            };

                            await db.Collection("User").Document(username).SetAsync(userData);
                            MessageBox.Show("Success Login using Gmail!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Success Login using Gmail!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                await FormTransition.FadeTo(this, new Dashboard());
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
    }
}
