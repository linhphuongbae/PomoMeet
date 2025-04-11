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
    public partial class EnterUsername : Form
    {
        public string EnteredUsername { get; private set; }
        public EnterUsername()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EnteredUsername = tbEnter.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
