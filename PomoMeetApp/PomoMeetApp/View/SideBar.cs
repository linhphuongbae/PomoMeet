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
    public partial class SideBar : UserControl
    {
        public SideBar()
        {
            InitializeComponent();
        }

        private void siticonePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
            CreateRoom cr = new CreateRoom();
            cr.StartPosition = FormStartPosition.CenterScreen; // cho nó vào giữa màn hình
            cr.Show();
        }

        private void siticoneButton7_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton6_Click(object sender, EventArgs e)
        {

        }
    }
}
