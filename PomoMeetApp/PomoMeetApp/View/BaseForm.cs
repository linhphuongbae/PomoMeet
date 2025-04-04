using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomoMeetApp.View
{
    public class BaseForm : Form
    {
        protected NotificationButton notifyButton;
        protected Label nameLabel;
        protected ProfileDropdown profileDropdown;
        protected int rightMargin = 20;
        protected int spacing = 10;

        public BaseForm()
        {
            InitializeCustomComponents();
            this.Resize += BaseForm_Resize;
            this.Click += HideDropdownOnClickOutside;
        }

        protected virtual void InitializeCustomComponents()
        {
            // Tạo nút thông báo
            notifyButton = new NotificationButton
            {
                Location = new Point(10, 20)
            };
            this.Controls.Add(notifyButton);

            // Tạo tên tài khoản
            nameLabel = new Label
            {
                Text = "User",
                Font = new Font("Inter", 11, FontStyle.Bold),
                Cursor = Cursors.Hand,
                AutoSize = true
            };
            nameLabel.Click += NameLabel_Click;
            this.Controls.Add(nameLabel);

            // Tạo dropdown menu
            profileDropdown = new ProfileDropdown
            {
                Location = new Point(nameLabel.Left, nameLabel.Bottom + 7),
                Visible = false
            };
            this.Controls.Add(profileDropdown);
        }

        protected virtual void BaseForm_Resize(object sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        protected virtual void UpdateControlPositions()
        {
            // Đặt notifyButton gần góc phải
            notifyButton.Location = new Point(this.ClientSize.Width - notifyButton.Width - rightMargin - 150, 20);


            nameLabel.Location = new Point(notifyButton.Right + spacing, notifyButton.Top + (notifyButton.Height - nameLabel.Height) / 2);

            profileDropdown.Location = new Point(nameLabel.Left, nameLabel.Bottom + 7);
        }

        protected virtual void HideDropdownOnClickOutside(object sender, EventArgs e)
        {
            if (!nameLabel.ClientRectangle.Contains(this.PointToClient(Cursor.Position)) &&
                !profileDropdown.ClientRectangle.Contains(this.PointToClient(Cursor.Position)))
            {
                profileDropdown.Visible = false;
            }
        }

        protected virtual void NameLabel_Click(object sender, EventArgs e)
        {
            profileDropdown.Visible = !profileDropdown.Visible;

            if (profileDropdown.Visible)
            {
                profileDropdown.BringToFront();
                profileDropdown.AdjustDropdownSize();
            }
        }
    }
}
