using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using PomoMeetApp.Classes;

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

        }

        private void siticoneButton7_Click(object sender, EventArgs e)
        {
            Friends fr = new Friends();
            fr.Show();
        }

        private void siticoneButton6_Click(object sender, EventArgs e)
        {
            Setting st = new Setting();
            st.Show();
        }

        private void siticoneButton8_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton5_Click(object sender, EventArgs e)
        {
            UserSession.CurrentUser = null;
            Form parent = this.FindForm();
            
            SignIn sg = new SignIn();
            FormTransition.FadeTo(parent, sg);
            
            parent.Hide();
        }
    }
}
