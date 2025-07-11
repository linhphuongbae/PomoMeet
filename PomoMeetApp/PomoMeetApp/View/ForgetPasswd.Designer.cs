namespace PomoMeetApp.View
{
    partial class ForgetPasswd
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
            Rectangle = new PictureBox();
            lbEmail = new Label();
            label1 = new Label();
            btnSendOTP = new SiticoneNetCoreUI.SiticoneButton();
            tbToEmail = new SiticoneNetCoreUI.SiticoneTextBox();
            tbOTP = new SiticoneNetCoreUI.SiticoneTextBox();
            lbOTP = new Label();
            lbNewpass = new Label();
            tbNewPass = new SiticoneNetCoreUI.SiticoneTextBox();
            ((System.ComponentModel.ISupportInitialize)Rectangle).BeginInit();
            SuspendLayout();
            // 
            // Rectangle
            // 
            Rectangle.BackColor = Color.FromArgb(233, 240, 201);
            Rectangle.Image = Properties.Resources.Rectangle;
            Rectangle.Location = new Point(-9, -3);
            Rectangle.Name = "Rectangle";
            Rectangle.Size = new Size(648, 441);
            Rectangle.TabIndex = 2;
            Rectangle.TabStop = false;
            Rectangle.Click += Rectangle_Click;
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.BackColor = Color.FromArgb(220, 229, 185);
            lbEmail.Font = new Font("Inter", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbEmail.ForeColor = Color.FromArgb(117, 164, 127);
            lbEmail.Location = new Point(53, 118);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(285, 40);
            lbEmail.TabIndex = 5;
            lbEmail.Text = "Nhập email của bạn";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(220, 229, 185);
            label1.Font = new Font("Inter", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(117, 164, 127);
            label1.Location = new Point(139, 37);
            label1.Name = "label1";
            label1.Size = new Size(380, 53);
            label1.TabIndex = 6;
            label1.Text = "Khôi phục tài khoản";
            // 
            // btnSendOTP
            // 
            btnSendOTP.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnSendOTP.AccessibleName = "Gửi OTP";
            btnSendOTP.AutoSizeBasedOnText = false;
            btnSendOTP.BackColor = Color.Transparent;
            btnSendOTP.BadgeBackColor = Color.Red;
            btnSendOTP.BadgeFont = new Font("Inter", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSendOTP.BadgeValue = 0;
            btnSendOTP.BadgeValueForeColor = Color.White;
            btnSendOTP.BorderColor = Color.FromArgb(117, 164, 127);
            btnSendOTP.BorderWidth = 2;
            btnSendOTP.ButtonBackColor = Color.White;
            btnSendOTP.ButtonImage = null;
            btnSendOTP.CanBeep = true;
            btnSendOTP.CanGlow = false;
            btnSendOTP.CanShake = true;
            btnSendOTP.ContextMenuStripEx = null;
            btnSendOTP.CornerRadiusBottomLeft = 0;
            btnSendOTP.CornerRadiusBottomRight = 0;
            btnSendOTP.CornerRadiusTopLeft = 0;
            btnSendOTP.CornerRadiusTopRight = 0;
            btnSendOTP.CustomCursor = Cursors.Default;
            btnSendOTP.DisabledTextColor = Color.FromArgb(117, 164, 127);
            btnSendOTP.EnableLongPress = false;
            btnSendOTP.EnablePressAnimation = true;
            btnSendOTP.EnableRippleEffect = true;
            btnSendOTP.EnableShadow = false;
            btnSendOTP.EnableTextWrapping = false;
            btnSendOTP.Font = new Font("Inter", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSendOTP.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnSendOTP.GlowIntensity = 100;
            btnSendOTP.GlowRadius = 20F;
            btnSendOTP.GradientBackground = false;
            btnSendOTP.GradientColor = Color.White;
            btnSendOTP.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnSendOTP.HintText = null;
            btnSendOTP.HoverBackColor = Color.FromArgb(117, 164, 127);
            btnSendOTP.HoverFontStyle = FontStyle.Regular;
            btnSendOTP.HoverTextColor = Color.White;
            btnSendOTP.HoverTransitionDuration = 250;
            btnSendOTP.ImageAlign = ContentAlignment.MiddleLeft;
            btnSendOTP.ImagePadding = 5;
            btnSendOTP.ImageSize = new Size(16, 16);
            btnSendOTP.IsRadial = false;
            btnSendOTP.IsReadOnly = false;
            btnSendOTP.IsToggleButton = false;
            btnSendOTP.IsToggled = false;
            btnSendOTP.Location = new Point(53, 292);
            btnSendOTP.LongPressDurationMS = 1000;
            btnSendOTP.Name = "btnSendOTP";
            btnSendOTP.NormalFontStyle = FontStyle.Regular;
            btnSendOTP.ParticleColor = Color.FromArgb(200, 200, 200);
            btnSendOTP.ParticleCount = 15;
            btnSendOTP.PressAnimationScale = 0.97F;
            btnSendOTP.PressedBackColor = Color.FromArgb(117, 164, 127);
            btnSendOTP.PressedFontStyle = FontStyle.Regular;
            btnSendOTP.PressTransitionDuration = 150;
            btnSendOTP.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnSendOTP.RippleColor = Color.FromArgb(255, 255, 255);
            btnSendOTP.RippleOpacity = 0.3F;
            btnSendOTP.RippleRadiusMultiplier = 0.6F;
            btnSendOTP.ShadowBlur = 5;
            btnSendOTP.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnSendOTP.ShadowOffset = new Point(2, 2);
            btnSendOTP.ShakeDuration = 500;
            btnSendOTP.ShakeIntensity = 5;
            btnSendOTP.Size = new Size(537, 47);
            btnSendOTP.TabIndex = 20;
            btnSendOTP.Text = "Gửi OTP";
            btnSendOTP.TextAlign = ContentAlignment.MiddleCenter;
            btnSendOTP.TextColor = Color.FromArgb(117, 164, 127);
            btnSendOTP.TooltipText = null;
            btnSendOTP.UseAdvancedRendering = true;
            btnSendOTP.UseParticles = false;
            btnSendOTP.Click += btnSendOTP_Click;
            // 
            // tbToEmail
            // 
            tbToEmail.AccessibleDescription = "A customizable text input field.";
            tbToEmail.AccessibleName = "Text Box";
            tbToEmail.AccessibleRole = AccessibleRole.Text;
            tbToEmail.BackColor = Color.Transparent;
            tbToEmail.BlinkCount = 3;
            tbToEmail.BlinkShadow = false;
            tbToEmail.BorderColor1 = Color.LightSlateGray;
            tbToEmail.BorderColor2 = Color.LightSlateGray;
            tbToEmail.BorderFocusColor1 = Color.FromArgb(77, 77, 255);
            tbToEmail.BorderFocusColor2 = Color.FromArgb(77, 77, 255);
            tbToEmail.CanShake = true;
            tbToEmail.ContinuousBlink = false;
            tbToEmail.CursorBlinkRate = 500;
            tbToEmail.CursorColor = Color.Black;
            tbToEmail.CursorHeight = 26;
            tbToEmail.CursorOffset = 0;
            tbToEmail.CursorStyle = SiticoneNetCoreUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            tbToEmail.CursorWidth = 1;
            tbToEmail.DisabledBackColor = Color.WhiteSmoke;
            tbToEmail.DisabledBorderColor = Color.LightGray;
            tbToEmail.DisabledTextColor = Color.Gray;
            tbToEmail.EnableDropShadow = false;
            tbToEmail.FillColor1 = Color.White;
            tbToEmail.FillColor2 = Color.White;
            tbToEmail.Font = new Font("Inter", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbToEmail.ForeColor = Color.DimGray;
            tbToEmail.HoverBorderColor1 = Color.Gray;
            tbToEmail.HoverBorderColor2 = Color.Gray;
            tbToEmail.IsEnabled = true;
            tbToEmail.Location = new Point(53, 184);
            tbToEmail.Name = "tbToEmail";
            tbToEmail.PlaceholderColor = Color.Gray;
            tbToEmail.PlaceholderText = "Nhập vào đây";
            tbToEmail.ReadOnlyBorderColor1 = Color.LightGray;
            tbToEmail.ReadOnlyBorderColor2 = Color.LightGray;
            tbToEmail.ReadOnlyFillColor1 = Color.WhiteSmoke;
            tbToEmail.ReadOnlyFillColor2 = Color.WhiteSmoke;
            tbToEmail.ReadOnlyPlaceholderColor = Color.DarkGray;
            tbToEmail.SelectionBackColor = Color.FromArgb(77, 77, 255);
            tbToEmail.ShadowAnimationDuration = 1;
            tbToEmail.ShadowBlur = 10;
            tbToEmail.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            tbToEmail.ShowBorder = false;
            tbToEmail.Size = new Size(537, 63);
            tbToEmail.SolidBorderColor = Color.LightSlateGray;
            tbToEmail.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            tbToEmail.SolidBorderHoverColor = Color.Gray;
            tbToEmail.SolidFillColor = Color.White;
            tbToEmail.TabIndex = 21;
            tbToEmail.TextPadding = new Padding(16, 0, 6, 0);
            tbToEmail.ValidationErrorMessage = "Invalid input.";
            tbToEmail.ValidationFunction = null;
            // 
            // tbOTP
            // 
            tbOTP.AccessibleDescription = "A customizable text input field.";
            tbOTP.AccessibleName = "Text Box";
            tbOTP.AccessibleRole = AccessibleRole.Text;
            tbOTP.BackColor = Color.Transparent;
            tbOTP.BlinkCount = 3;
            tbOTP.BlinkShadow = false;
            tbOTP.BorderColor1 = Color.LightSlateGray;
            tbOTP.BorderColor2 = Color.LightSlateGray;
            tbOTP.BorderFocusColor1 = Color.FromArgb(77, 77, 255);
            tbOTP.BorderFocusColor2 = Color.FromArgb(77, 77, 255);
            tbOTP.CanShake = true;
            tbOTP.ContinuousBlink = false;
            tbOTP.CursorBlinkRate = 500;
            tbOTP.CursorColor = Color.Black;
            tbOTP.CursorHeight = 26;
            tbOTP.CursorOffset = 0;
            tbOTP.CursorStyle = SiticoneNetCoreUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            tbOTP.CursorWidth = 1;
            tbOTP.DisabledBackColor = Color.WhiteSmoke;
            tbOTP.DisabledBorderColor = Color.LightGray;
            tbOTP.DisabledTextColor = Color.Gray;
            tbOTP.EnableDropShadow = false;
            tbOTP.FillColor1 = Color.White;
            tbOTP.FillColor2 = Color.White;
            tbOTP.Font = new Font("Inter", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbOTP.ForeColor = Color.DimGray;
            tbOTP.HoverBorderColor1 = Color.Gray;
            tbOTP.HoverBorderColor2 = Color.Gray;
            tbOTP.IsEnabled = true;
            tbOTP.Location = new Point(51, 187);
            tbOTP.Name = "tbOTP";
            tbOTP.PlaceholderColor = Color.Gray;
            tbOTP.PlaceholderText = "Nhập vào đây";
            tbOTP.ReadOnlyBorderColor1 = Color.LightGray;
            tbOTP.ReadOnlyBorderColor2 = Color.LightGray;
            tbOTP.ReadOnlyFillColor1 = Color.WhiteSmoke;
            tbOTP.ReadOnlyFillColor2 = Color.WhiteSmoke;
            tbOTP.ReadOnlyPlaceholderColor = Color.DarkGray;
            tbOTP.SelectionBackColor = Color.FromArgb(77, 77, 255);
            tbOTP.ShadowAnimationDuration = 1;
            tbOTP.ShadowBlur = 10;
            tbOTP.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            tbOTP.ShowBorder = false;
            tbOTP.Size = new Size(537, 63);
            tbOTP.SolidBorderColor = Color.LightSlateGray;
            tbOTP.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            tbOTP.SolidBorderHoverColor = Color.Gray;
            tbOTP.SolidFillColor = Color.White;
            tbOTP.TabIndex = 22;
            tbOTP.TextPadding = new Padding(16, 0, 6, 0);
            tbOTP.ValidationErrorMessage = "Invalid input.";
            tbOTP.ValidationFunction = null;
            tbOTP.Visible = false;
            // 
            // lbOTP
            // 
            lbOTP.AutoSize = true;
            lbOTP.BackColor = Color.FromArgb(220, 229, 185);
            lbOTP.Font = new Font("Inter", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbOTP.ForeColor = Color.FromArgb(117, 164, 127);
            lbOTP.Location = new Point(51, 118);
            lbOTP.Name = "lbOTP";
            lbOTP.Size = new Size(154, 40);
            lbOTP.TabIndex = 23;
            lbOTP.Text = "Nhập OTP";
            lbOTP.Visible = false;
            // 
            // lbNewpass
            // 
            lbNewpass.AutoSize = true;
            lbNewpass.BackColor = Color.FromArgb(220, 229, 185);
            lbNewpass.Font = new Font("Inter", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbNewpass.ForeColor = Color.FromArgb(117, 164, 127);
            lbNewpass.Location = new Point(196, 118);
            lbNewpass.Name = "lbNewpass";
            lbNewpass.Size = new Size(279, 40);
            lbNewpass.TabIndex = 24;
            lbNewpass.Text = "Nhập Mật khẩu mới";
            lbNewpass.Visible = false;
            // 
            // tbNewPass
            // 
            tbNewPass.AccessibleDescription = "A customizable text input field.";
            tbNewPass.AccessibleName = "Text Box";
            tbNewPass.AccessibleRole = AccessibleRole.Text;
            tbNewPass.BackColor = Color.Transparent;
            tbNewPass.BlinkCount = 3;
            tbNewPass.BlinkShadow = false;
            tbNewPass.BorderColor1 = Color.LightSlateGray;
            tbNewPass.BorderColor2 = Color.LightSlateGray;
            tbNewPass.BorderFocusColor1 = Color.FromArgb(77, 77, 255);
            tbNewPass.BorderFocusColor2 = Color.FromArgb(77, 77, 255);
            tbNewPass.CanShake = true;
            tbNewPass.ContinuousBlink = false;
            tbNewPass.CursorBlinkRate = 500;
            tbNewPass.CursorColor = Color.Black;
            tbNewPass.CursorHeight = 26;
            tbNewPass.CursorOffset = 0;
            tbNewPass.CursorStyle = SiticoneNetCoreUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            tbNewPass.CursorWidth = 1;
            tbNewPass.DisabledBackColor = Color.WhiteSmoke;
            tbNewPass.DisabledBorderColor = Color.LightGray;
            tbNewPass.DisabledTextColor = Color.Gray;
            tbNewPass.EnableDropShadow = false;
            tbNewPass.FillColor1 = Color.White;
            tbNewPass.FillColor2 = Color.White;
            tbNewPass.Font = new Font("Inter", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbNewPass.ForeColor = Color.DimGray;
            tbNewPass.HoverBorderColor1 = Color.Gray;
            tbNewPass.HoverBorderColor2 = Color.Gray;
            tbNewPass.IsEnabled = true;
            tbNewPass.Location = new Point(53, 187);
            tbNewPass.Name = "tbNewPass";
            tbNewPass.PlaceholderColor = Color.Gray;
            tbNewPass.PlaceholderText = "Nhập vào đây";
            tbNewPass.ReadOnlyBorderColor1 = Color.LightGray;
            tbNewPass.ReadOnlyBorderColor2 = Color.LightGray;
            tbNewPass.ReadOnlyFillColor1 = Color.WhiteSmoke;
            tbNewPass.ReadOnlyFillColor2 = Color.WhiteSmoke;
            tbNewPass.ReadOnlyPlaceholderColor = Color.DarkGray;
            tbNewPass.SelectionBackColor = Color.FromArgb(77, 77, 255);
            tbNewPass.ShadowAnimationDuration = 1;
            tbNewPass.ShadowBlur = 10;
            tbNewPass.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            tbNewPass.ShowBorder = false;
            tbNewPass.Size = new Size(537, 63);
            tbNewPass.SolidBorderColor = Color.LightSlateGray;
            tbNewPass.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            tbNewPass.SolidBorderHoverColor = Color.Gray;
            tbNewPass.SolidFillColor = Color.White;
            tbNewPass.TabIndex = 25;
            tbNewPass.TextPadding = new Padding(16, 0, 6, 0);
            tbNewPass.ValidationErrorMessage = "Invalid input.";
            tbNewPass.ValidationFunction = null;
            tbNewPass.Visible = false;
            // 
            // ForgetPasswd
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(639, 437);
            Controls.Add(tbNewPass);
            Controls.Add(lbNewpass);
            Controls.Add(lbOTP);
            Controls.Add(tbOTP);
            Controls.Add(tbToEmail);
            Controls.Add(btnSendOTP);
            Controls.Add(label1);
            Controls.Add(lbEmail);
            Controls.Add(Rectangle);
            MaximumSize = new Size(657, 484);
            Name = "ForgetPasswd";
            Text = "ForgetPasswd";
            ((System.ComponentModel.ISupportInitialize)Rectangle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Rectangle;
        private Label lbEmail;
        private Label label1;
        private SiticoneNetCoreUI.SiticoneButton btnSendOTP;
        private SiticoneNetCoreUI.SiticoneTextBox tbToEmail;
        private SiticoneNetCoreUI.SiticoneTextBox tbOTP;
        private Label lbOTP;
        private Label lbNewpass;
        private SiticoneNetCoreUI.SiticoneTextBox tbNewPass;
    }
}