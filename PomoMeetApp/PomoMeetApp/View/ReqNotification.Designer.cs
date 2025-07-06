using System;

namespace PomoMeetApp.View
{
    partial class ReqNotification
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            siticonePanel2 = new SiticoneNetCoreUI.SiticonePanel();
            siticoneLabel3 = new SiticoneNetCoreUI.SiticoneLabel();
            panelNotifications = new FlowLayoutPanel();
            siticonePanel2.SuspendLayout();
            SuspendLayout();
            // 
            // siticonePanel2
            // 
            siticonePanel2.AcrylicTintColor = Color.FromArgb(128, 255, 255, 255);
            siticonePanel2.BackColor = Color.Transparent;
            siticonePanel2.BorderAlignment = System.Drawing.Drawing2D.PenAlignment.Center;
            siticonePanel2.BorderDashPattern = null;
            siticonePanel2.BorderGradientEndColor = Color.Purple;
            siticonePanel2.BorderGradientStartColor = Color.Blue;
            siticonePanel2.BorderThickness = 2F;
            siticonePanel2.Controls.Add(siticoneLabel3);
            siticonePanel2.CornerRadiusBottomLeft = 0F;
            siticonePanel2.CornerRadiusBottomRight = 0F;
            siticonePanel2.CornerRadiusTopLeft = 20F;
            siticonePanel2.CornerRadiusTopRight = 20F;
            siticonePanel2.EnableAcrylicEffect = false;
            siticonePanel2.EnableMicaEffect = false;
            siticonePanel2.EnableRippleEffect = false;
            siticonePanel2.FillColor = Color.FromArgb(117, 164, 127);
            siticonePanel2.GradientColors = new Color[]
    {
    Color.White,
    Color.LightGray,
    Color.Gray
    };
            siticonePanel2.GradientPositions = new float[]
    {
    0F,
    0.5F,
    1F
    };
            siticonePanel2.Location = new Point(-1, -1);
            siticonePanel2.Name = "siticonePanel2";
            siticonePanel2.PatternStyle = System.Drawing.Drawing2D.HatchStyle.Max;
            siticonePanel2.RippleAlpha = 50;
            siticonePanel2.RippleAlphaDecrement = 3;
            siticonePanel2.RippleColor = Color.FromArgb(50, 255, 255, 255);
            siticonePanel2.RippleMaxSize = 600F;
            siticonePanel2.RippleSpeed = 15F;
            siticonePanel2.ShowBorder = true;
            siticonePanel2.Size = new Size(649, 69);
            siticonePanel2.TabIndex = 14;
            siticonePanel2.TabStop = true;
            siticonePanel2.UseBorderGradient = false;
            siticonePanel2.UseMultiGradient = false;
            siticonePanel2.UsePatternTexture = false;
            siticonePanel2.UseRadialGradient = false;
            // 
            // siticoneLabel3
            // 
            siticoneLabel3.BackColor = Color.Transparent;
            siticoneLabel3.Font = new Font("Inter", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            siticoneLabel3.ForeColor = Color.White;
            siticoneLabel3.Location = new Point(246, 11);
            siticoneLabel3.Name = "siticoneLabel3";
            siticoneLabel3.Size = new Size(361, 52);
            siticoneLabel3.TabIndex = 0;
            siticoneLabel3.Text = "Thông báo";
            // 
            // panelNotifications
            // 
            panelNotifications.AutoScroll = true;
            panelNotifications.BackColor = Color.White;
            panelNotifications.FlowDirection = FlowDirection.TopDown;
            panelNotifications.Location = new Point(10, 80);
            panelNotifications.Name = "panelNotifications";
            panelNotifications.Size = new Size(630, 370);
            panelNotifications.TabIndex = 0;
            panelNotifications.WrapContents = false;
            // 
            // ReqNotification
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(648, 458);
            Controls.Add(panelNotifications);
            Controls.Add(siticonePanel2);
            Name = "ReqNotification";
            Text = "ReqNotification";
            Load += ReqNotification_Load;
            siticonePanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private SiticoneNetCoreUI.SiticonePanel siticonePanel2;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel3;
        private FlowLayoutPanel panelNotifications;
    }
}