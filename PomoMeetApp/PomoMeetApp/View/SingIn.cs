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

        private async void btnSignInGG_Click(object sender, EventArgs e)
        {
            string clientId = "1002644567232-b8dhi0ue0o5sb7ar58rtrml6i59qfl7e.apps.googleusercontent.com";
            string clientSecret = "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";

            string[] scopes = new[]
            {
                "https://www.googleapis.com/auth/userinfo.email",
                "https://www.googleapis.com/auth/userinfo.profile"
            };

            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret
                },
                scopes, "user", CancellationToken.None, new FileDataStore("Google0AuthToken", true)
            );

            if (credential != null && credential.Token != null)
            {
                var oAuthService = new Oauth2Service(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "PomoMeetApp"
                });
                // gửi yêu cầu tới google để lấy thông tin user
                var userInfo = await oAuthService.Userinfo.Get().ExecuteAsync();
            }
            
        }
    }
}
