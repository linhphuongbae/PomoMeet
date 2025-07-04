﻿using Google.Cloud.Firestore;
using PomoMeetApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PomoMeetApp.View.CustomMessageBox;

namespace PomoMeetApp.View
{
    public partial class ReqNotification : Form
    {
        string currentUserId;
        public ReqNotification(string userId)
        {
            InitializeComponent();
            currentUserId = userId;
            LoadNotifications();
        }
private async Task HandleResponse(string inviteId, string roomId, string response)
{
    try
    {
        var db = FirebaseConfig.database;
        if (db == null) return;

        if (response == "Accepted")
        {
            await db.Collection("Invitations").Document(inviteId).UpdateAsync("status", "Accepted");

            // Store reference to dashboard before hiding
            var dashboard = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();
            
            this.Hide();
            
            var meetingRoom = new MeetingRoom(currentUserId, roomId);
            meetingRoom.FormClosed += async (s, e) =>
            {
                // Show dashboard again when meeting room closes (for any reason)
                if (dashboard != null && !dashboard.IsDisposed)
                {
                    dashboard.Show();
                    dashboard.BringToFront();
                }
                
                // If kicked, show notification
                if (meetingRoom.isBeingKicked && !meetingRoom.hasShownKickNotification)
                {
                    CustomMessageBox.Show("Bạn đã bị kick khỏi phòng!", "Thông báo", MessageBoxMode.OK);
                    meetingRoom.hasShownKickNotification = true;
                }
            };

            meetingRoom.ShowDialog();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error handling response: {ex.Message}");
    }
    finally
    {
        await LoadNotifications();
    }
}
        private void ShowKickNotification(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => ShowKickNotification(message)));
                return;
            }

            // Close the meeting room if it's open
            var meetingRoom = Application.OpenForms.OfType<MeetingRoom>()
                .FirstOrDefault(f => f.CurrentUserId == currentUserId);

            if (meetingRoom != null)
            {
                meetingRoom.isBeingKicked = true;
                meetingRoom.hasShownKickNotification = true;
                meetingRoom.Close();
            }

            // Show notification
            CustomMessageBox.Show(message, "Thông báo", MessageBoxMode.OK);

            // Show dashboard again
            var dashboard = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();
            if (dashboard != null)
            {
                dashboard.Show();
                dashboard.BringToFront();
                dashboard.Activate();
            }
        }
        private async Task LoadNotifications()
        {
            try
            {
                var db = FirebaseConfig.database;
                if (db == null) return;

                var query = db.Collection("Invitations")
                              .WhereEqualTo("receiver_id", currentUserId)
                              .WhereEqualTo("status", "Pending")
                              .OrderBy("created_at");

                var snapshot = await query.GetSnapshotAsync();
                panelNotifications.Controls.Clear();

                if (snapshot.Count == 0)
                {
                    ShowNoNotificationsMessage();
                    return;
                }

                foreach (var doc in snapshot.Documents)
                {
                    string senderId = doc.GetValue<string>("sender_id");
                    var senderDoc = await db.Collection("User").Document(senderId).GetSnapshotAsync();
                    string senderName = senderDoc.Exists ? senderDoc.GetValue<string>("Username") : "Anonymous User";
                    string avatarName = senderDoc.Exists ? senderDoc.GetValue<string>("Avatar") : "default_avatar";
                    var resourceManager = Properties.Resources.ResourceManager;
                    Image avatar = (Image)resourceManager.GetObject(avatarName) ?? Properties.Resources.avatar;

                    string createdAt = FormatTime(doc.GetValue<string>("created_at"));
                    string inviteId = doc.Id;
                    string roomId = doc.GetValue<string>("room_id");

                    var notificationItem = new NotificationItem(senderName, createdAt, avatar, inviteId, roomId, currentUserId, async (invId, rId, response) =>
                    {
                        await HandleResponse(invId, rId, response);
                        if (response == "Accepted")
                        {
                            var dashboard = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();
                            if (dashboard != null)
                                dashboard.Hide();   // Ẩn Dashboard trước khi vào phòng

                            this.Close(); // Dong ReqNotification
                            var meetingRoom = new MeetingRoom(currentUserId, roomId);
                            meetingRoom.ShowDialog();
                        }
                    });

                    panelNotifications.Controls.Add(notificationItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading notifications: {ex.Message}");
            }
        }

        private void ShowNoNotificationsMessage()
        {
            if (!panelNotifications.Controls.OfType<Label>().Any(lbl => lbl.Text == "No notifications"))
            {
                panelNotifications.Controls.Add(new Label
                {
                    Text = "No notifications",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Padding = new Padding(10)
                });
            }
        }
        private string FormatTime(string timestamp)
        {
            if (DateTime.TryParse(timestamp, out DateTime dateTime))
            {
                TimeSpan timeDiff = DateTime.Now - dateTime;

                if (timeDiff.TotalMinutes < 1)
                    return "Vừa xong";
                if (timeDiff.TotalHours < 1)
                    return $"{(int)timeDiff.TotalMinutes} phút trước";
                if (timeDiff.TotalDays < 1)
                    return $"{(int)timeDiff.TotalHours} giờ trước";
                if (timeDiff.TotalDays < 30)
                    return $"{(int)timeDiff.TotalDays} ngày trước";

                return dateTime.ToString("dd/MM/yyyy");
            }
            return "Invalid time";
        }
    }
}
