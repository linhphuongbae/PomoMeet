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
    public partial class Friends : Form
    {
        public Friends()
        {
            InitializeComponent();
        }

        private void btn_AllFriends_Click(object sender, EventArgs e)
        {
            lbAllFriends.Text = "All Friends";
            pnAllFriends.Visible = true;
            pn_OnlineFriends.Visible = false;
            pnFriendRequests.Visible = false;
            pnFindFriends.Visible = false;

        }

        private void btn_OnlineFriends_Click(object sender, EventArgs e)
        {
            lbAllFriends.Text = "Online Friends";
            pnAllFriends.Visible = false;
            pn_OnlineFriends.Visible = true;
            pnFriendRequests.Visible = false;
            pnFindFriends.Visible = false;
        }

        private void btn_FriendRequests_Click(object sender, EventArgs e)
        {
            lbAllFriends.Text = "Friends Requests";
            pnAllFriends.Visible = false;
            pn_OnlineFriends.Visible = false;
            pnFriendRequests.Visible = true;
            pnFindFriends.Visible = false;
        }

        private void btn_FindFriends_Click(object sender, EventArgs e)
        {
            lbAllFriends.Text = "Results";
            pnAllFriends.Visible = false;
            pn_OnlineFriends.Visible = false;
            pnFriendRequests.Visible = false;
            pnFindFriends.Visible = true;

        }
    }
}
