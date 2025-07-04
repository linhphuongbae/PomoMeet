using Google.Cloud.Firestore;
using PomoMeetApp.Classes;
using SiticoneNetCoreUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PomoMeetApp.View
{
    public partial class InviteMore : Form
    {
        private string currentUserId;
        private string roomId;

        public InviteMore(string userId, string roomId)
        {
            InitializeComponent();
            this.currentUserId = userId;
            this.roomId = roomId;

            tbMamoi.Text = roomId;
        }

        private void btCopy_Click(object sender, EventArgs e)
        {
            try
            {
                // Sao chép nội dung của tbMamoi (ID phòng) vào clipboard
                Clipboard.SetText(tbMamoi.Text);
                MessageBox.Show("Mã phòng đã được sao chép vào clipboard!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sao chép mã phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
