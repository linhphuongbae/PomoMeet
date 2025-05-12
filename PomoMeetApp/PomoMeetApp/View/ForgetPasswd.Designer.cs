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
            email = new Label();
            label1 = new Label();
            btnSendOTP = new SiticoneNetCoreUI.SiticoneButton();
            tbToEmail = new SiticoneNetCoreUI.SiticoneTextBox();
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
            // email
            // 
            email.AutoSize = true;
            email.BackColor = Color.FromArgb(220, 229, 185);
            email.Font = new Font("Inter", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            email.ForeColor = Color.FromArgb(117, 164, 127);
            email.Location = new Point(53, 118);
            email.Name = "email";
            email.Size = new Size(285, 40);
            email.TabIndex = 5;
            email.Text = "Nhập email của bạn";
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
            tbToEmail.PlaceholderText = "Enter text here...";
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
            // ForgetPasswd
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(639, 437);
            Controls.Add(tbToEmail);
            Controls.Add(btnSendOTP);
            Controls.Add(label1);
            Controls.Add(email);
            Controls.Add(Rectangle);
            Name = "ForgetPasswd";
            Text = "ForgetPasswd";
            ((System.ComponentModel.ISupportInitialize)Rectangle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Rectangle;
        private Label email;
        private Label label1;
        private SiticoneNetCoreUI.SiticoneButton btnSendOTP;
        private SiticoneNetCoreUI.SiticoneTextBox tbToEmail;
    }
}