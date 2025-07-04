﻿using Google.Cloud.Firestore;
using PomoMeetApp.Classes;
using SiticoneNetCoreUI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PomoMeetApp.View
{
    public class UserProfilePanel : Panel
    {
        // Components
        private SiticoneNotificationButton btnNotify;
        private PictureBox avatar;
        private Label lblUserName;
        private SiticoneButton btnProfile;
        private Panel dropdownPanel;
        private Action<string> profileClickCallback; // Callback now expects userId
        private FirestoreChangeListener _notificationListener;

        // Store current userId
        private string currentUserId;

        public void SetProfileClickCallback(Action<string> callback)
        {
            profileClickCallback = callback;
        }

        public UserProfilePanel()
        {
            InitializePanel();
            InitializeComponents();
        }

        private void InitializePanel()
        {
            this.Size = new Size(250, 60); // Kích thước tổng
            this.BackColor = Color.Transparent;
            this.BorderStyle = BorderStyle.None;
        }

        private void InitializeComponents()
        {
            // 1. Notification Button (Bên trái)
            btnNotify = new SiticoneNotificationButton
            {
                Size = new Size(50, 50),
                Location = new Point(0, 5),
                // Enable the badge display and set a notification count
                ShowBadge = true,
                BadgeValue = 0,
                BadgeBackColor = Color.Red,
                BadgeTextColor = Color.White,
                BadgeFont = new Font("Inter", 8f, FontStyle.Bold),
                BadgeBorderColor = Color.White,
                BadgeBorderThickness = 1,
                // Configure animation settings
                BadgeAnimationSpeed = 200,
                BadgeAnimationType = BadgeAnimationType.ScaleInOut,
                // Optional: Refresh badge on click
                RefreshBadgeOnClick = true,
                NotificationTooltip = "You have new notifications",
                BellColor = Color.Black,
                Text = string.Empty, // No notifications initially
                Cursor = Cursors.Hand
            };
            this.Controls.Add(btnNotify);
            btnNotify.Click += BtnNotify_Click;

            // 2. Avatar (Ảnh đại diện)
            avatar = new PictureBox
            {
                Size = new Size(50, 50),
                Location = new Point(60, 5),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Properties.Resources.avatar, // Thay bằng avatar mặc định
                Cursor = Cursors.Hand
            };
            avatar.Click += ToggleDropdown;
            this.Controls.Add(avatar);

            // 3. Tên người dùng
            lblUserName = new Label
            {
                Text = "Username",
                Font = new Font("Inter", 10, FontStyle.Bold),
                Location = new Point(120, 20),
                AutoSize = true,
                Cursor = Cursors.Hand
            };
            lblUserName.Click += ToggleDropdown;
            this.Controls.Add(lblUserName);

            // 4. Dropdown Panel (Ẩn ban đầu)
            dropdownPanel = new SiticoneFlatPanel
            {
                Size = new Size(150, 50),
                Location = new Point(120, 50),
                BackColor = Color.Transparent,
                BorderStyle = BorderStyle.None,
                Visible = false
            };

            // Nút "View Profile" trong dropdown
            btnProfile = new SiticoneButton
            {
                Text = "View Profile",
                Size = new Size(140, 40),
                Location = new Point(5, 5),
                Font = new Font("Inter", 10, FontStyle.Bold),
                ButtonBackColor = Color.DarkSeaGreen,
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                RippleColor = Color.DarkSeaGreen,
                HoverBackColor = Color.DarkSeaGreen,
                CornerRadiusBottomLeft = 10,
                CornerRadiusBottomRight = 10,
                CornerRadiusTopLeft = 10,
                CornerRadiusTopRight = 10,
                BorderColor = Color.DarkSeaGreen,
                PressedBackColor = Color.SeaGreen
            };
            btnProfile.Click += (sender, e) =>
            {
                profileClickCallback?.Invoke(currentUserId); // Pass userId instead of username
                dropdownPanel.Visible = false;
            };
            dropdownPanel.Controls.Add(btnProfile);

            this.Controls.Add(dropdownPanel);
        }

        // Hiển thị/Ẩn dropdown
        private void ToggleDropdown(object sender, EventArgs e)
        {
            dropdownPanel.Visible = !dropdownPanel.Visible;
            this.Height = dropdownPanel.Visible ? 110 : 60; // Điều chỉnh chiều cao
        }


        private ReqNotification _notificationForm;
        private void BtnNotify_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentUserId))
            {
                if (_notificationForm == null || _notificationForm.IsDisposed)
                {
                    _notificationForm = new ReqNotification(currentUserId);
                    _notificationForm.FormClosed += (s, args) => _notificationForm = null;
                    _notificationForm.Show();
                }
                else
                {
                    _notificationForm.BringToFront();
                }
            }
            else
            {
                MessageBox.Show("User ID is not set. Please log in first.");
            }
        }

        private int _notificationCountBackingField = 0;
        private int NotificationCount
        {
            get => _notificationCountBackingField;
            set
            {
                _notificationCountBackingField = value;

                if (btnNotify.IsHandleCreated)
                {
                    btnNotify.Invoke((MethodInvoker)delegate
                    {
                        // Update badge value
                        btnNotify.BadgeValue = _notificationCountBackingField;

                        // Only show badge if there are notifications
                        btnNotify.ShowBadge = _notificationCountBackingField > 0;

                        btnNotify.BellColor = _notificationCountBackingField > 0 ?
                            Color.Red : Color.Black;
                    });
                }
            }
        }

        public async Task UpdateNotificationBadge()
        {
            try
            {
                var db = FirebaseConfig.database;
                if (db == null || string.IsNullOrEmpty(currentUserId)) return;

                // Query to count pending invitations for the current user
                var query = db.Collection("Invitations")
                    .WhereEqualTo("receiver_id", currentUserId)
                    .WhereEqualTo("status", "Pending");

                var snapshot = await query.GetSnapshotAsync();

                // Update the notification count on UI thread
                if (this.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        NotificationCount = snapshot.Count;
                    });
                }
                else
                {
                    // If handle not created yet, try again later
                    await Task.Delay(500);
                    await UpdateNotificationBadge();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating notification badge: {ex.Message}");
            }
        }

        private async void StartListeningForNotifications()
        {
            try
            {
                var db = FirebaseConfig.database;
                if (db == null || string.IsNullOrEmpty(currentUserId)) return;

                // Stop the previous listener if it exists
                if (_notificationListener != null)
                {
                    await _notificationListener.StopAsync();
                }

                var query = db.Collection("Invitations")
                    .WhereEqualTo("receiver_id", currentUserId)
                    .WhereEqualTo("status", "Pending");

                _notificationListener = query.Listen(snapshot =>
                {
                    if (this.IsHandleCreated)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            NotificationCount = snapshot.Count;

                            // Visual feedback when new notifications arrive
                            if (snapshot.Count > 0 && snapshot.Count > NotificationCount)
                            {
                                btnNotify.BellColor = Color.Red;
                                Task.Delay(500).ContinueWith(t =>
                                {
                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        btnNotify.BellColor = Color.Black;
                                    });
                                });
                            }
                        });
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting up listener: {ex.Message}");
            }
        }

        // Update user info
        public async void UpdateUserInfo(string userId, string userName, Image avatarImage)
        {
            currentUserId = userId;

            if (lblUserName.IsHandleCreated && avatar.IsHandleCreated)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lblUserName.Text = userName;
                    avatar.Image = avatarImage ?? Properties.Resources.avatar;
                });
            }

            // Start notification updates
            await UpdateNotificationBadge().ConfigureAwait(false);
            StartListeningForNotifications();
        }
    }
}