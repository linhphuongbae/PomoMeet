using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PomoMeetApp.Classes
{
    internal static class FormTransition
    {
        public static async Task FadeTo(Form cur, Form next)
        {
            for (double i = 1.0; i >=0; i-= 0.1)
            {
                cur.Opacity = i;
                await Task.Delay(20);
            }

            // Đóng form hiện tại
            cur.Hide();

            next.Opacity = 0;
            next.Show();

            for (double i = 0; i <= 1.0; i+= 0.1)
            {
                next.Opacity = i;
                await Task.Delay(20);
            }    
        }
    }
}
