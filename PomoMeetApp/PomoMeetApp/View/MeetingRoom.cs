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
using System.Xml;

namespace PomoMeetApp.View
{
    public partial class MeetingRoom : Form
    {
        private ImageList imageListAvatars;

        public MeetingRoom()
        {
            InitializeComponent();
            InitializeMeetingRoomComponents();
        }

        private void InitializeMeetingRoomComponents()
        {
            // Khởi tạo ImageList
            imageListAvatars = new ImageList();
            imageListAvatars.ImageSize = new Size(16, 16);
            imageListAvatars.Images.Add("avatar", Properties.Resources.avatar);
            imageListAvatars.Images.Add("mic_on", Properties.Resources.mic_on);
            imageListAvatars.Images.Add("mic_off", Properties.Resources.mic_off);
            imageListAvatars.Images.Add("cam_on", Properties.Resources.cam_on);
            imageListAvatars.Images.Add("cam_off", Properties.Resources.cam_off);

            // Giả sử listViewParticipants đã được khởi tạo trong InitializeComponent()
            listViewParticipants.SmallImageList = imageListAvatars;
            listViewParticipants.DrawSubItem += listViewParticipants_DrawSubItem;

            // Thêm dữ liệu mẫu
            var item = new ListViewItem();
            item.ImageKey = "avatar";
            item.SubItems.Add("People 1");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.SubItems[2].Tag = "mic_on";
            item.SubItems[3].Tag = "cam_off";
            listViewParticipants.Items.Add(item);
        }

        private void listViewParticipants_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3) // Mic or Camera column
            {
                string iconKey = e.SubItem.Tag as string;
                if (!string.IsNullOrEmpty(iconKey) && imageListAvatars.Images.ContainsKey(iconKey))
                {
                    var icon = imageListAvatars.Images[iconKey];
                    e.Graphics.DrawImage(icon, e.Bounds.X + 5, e.Bounds.Y + 2, 16, 16); // Vẽ icon
                }
            }
            else
            {
                e.DrawDefault = true; // Vẽ mặc định cho các cột khác
            }
        }

    }
}