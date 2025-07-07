namespace PomoMeetApp.View
{
    partial class Profile
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profile));
            pictureBox_avatar = new PictureBox();
            siticoneLabel1 = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneLabel2 = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneLabel4 = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneLabel5 = new SiticoneNetCoreUI.SiticoneLabel();
            tbUsername = new SiticoneNetCoreUI.SiticoneTextBox();
            tbEmail = new SiticoneNetCoreUI.SiticoneTextBox();
            tbNewPassword = new SiticoneNetCoreUI.SiticoneTextBox();
            tbConfirmPassword = new SiticoneNetCoreUI.SiticoneTextBox();
            siticoneLabel7 = new SiticoneNetCoreUI.SiticoneLabel();
            bindingSource1 = new BindingSource(components);
            siticoneLabel9 = new SiticoneNetCoreUI.SiticoneLabel();
            editAvatarButton = new PictureBox();
            btnSave = new SiticoneNetCoreUI.SiticoneButton();
            userProfilePanel1 = new UserProfilePanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox_avatar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)editAvatarButton).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_avatar
            // 
            pictureBox_avatar.BackColor = Color.Transparent;
            pictureBox_avatar.BorderStyle = BorderStyle.FixedSingle;
            pictureBox_avatar.Image = (Image)resources.GetObject("pictureBox_avatar.Image");
            pictureBox_avatar.Location = new Point(701, 180);
            pictureBox_avatar.Name = "pictureBox_avatar";
            pictureBox_avatar.Size = new Size(430, 430);
            pictureBox_avatar.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_avatar.TabIndex = 6;
            pictureBox_avatar.TabStop = false;
            // 
            // siticoneLabel1
            // 
            siticoneLabel1.BackColor = Color.Transparent;
            siticoneLabel1.Font = new Font("Inter", 12F, FontStyle.Bold);
            siticoneLabel1.ForeColor = Color.DarkSeaGreen;
            siticoneLabel1.Location = new Point(226, 192);
            siticoneLabel1.Name = "siticoneLabel1";
            siticoneLabel1.Size = new Size(232, 43);
            siticoneLabel1.TabIndex = 7;
            siticoneLabel1.Text = "Tên đăng nhập";
            // 
            // siticoneLabel2
            // 
            siticoneLabel2.BackColor = Color.Transparent;
            siticoneLabel2.Font = new Font("Inter", 12F, FontStyle.Bold);
            siticoneLabel2.ForeColor = Color.DarkSeaGreen;
            siticoneLabel2.Location = new Point(226, 305);
            siticoneLabel2.Name = "siticoneLabel2";
            siticoneLabel2.Size = new Size(110, 44);
            siticoneLabel2.TabIndex = 8;
            siticoneLabel2.Text = "Email";
            // 
            // siticoneLabel4
            // 
            siticoneLabel4.BackColor = Color.Transparent;
            siticoneLabel4.Font = new Font("Inter", 12F, FontStyle.Bold);
            siticoneLabel4.ForeColor = Color.DarkSeaGreen;
            siticoneLabel4.Location = new Point(226, 420);
            siticoneLabel4.Name = "siticoneLabel4";
            siticoneLabel4.Size = new Size(279, 47);
            siticoneLabel4.TabIndex = 10;
            siticoneLabel4.Text = "Mật khẩu mới";
            // 
            // siticoneLabel5
            // 
            siticoneLabel5.BackColor = Color.Transparent;
            siticoneLabel5.Font = new Font("Inter", 12F, FontStyle.Bold);
            siticoneLabel5.ForeColor = Color.DarkSeaGreen;
            siticoneLabel5.Location = new Point(226, 532);
            siticoneLabel5.Name = "siticoneLabel5";
            siticoneLabel5.Size = new Size(296, 36);
            siticoneLabel5.TabIndex = 11;
            siticoneLabel5.Text = "Xác nhận mật khẩu";
            // 
            // tbUsername
            // 
            tbUsername.AccessibleDescription = "A customizable text input field.";
            tbUsername.AccessibleName = "Text Box";
            tbUsername.AccessibleRole = AccessibleRole.Text;
            tbUsername.BackColor = Color.Transparent;
            tbUsername.BlinkCount = 3;
            tbUsername.BlinkShadow = false;
            tbUsername.BorderColor1 = Color.LightSlateGray;
            tbUsername.BorderColor2 = Color.LightSlateGray;
            tbUsername.BorderFocusColor1 = Color.FromArgb(77, 77, 255);
            tbUsername.BorderFocusColor2 = Color.FromArgb(77, 77, 255);
            tbUsername.CanShake = true;
            tbUsername.ContinuousBlink = false;
            tbUsername.CursorBlinkRate = 500;
            tbUsername.CursorColor = Color.Black;
            tbUsername.CursorHeight = 26;
            tbUsername.CursorOffset = 0;
            tbUsername.CursorStyle = SiticoneNetCoreUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            tbUsername.CursorWidth = 1;
            tbUsername.DisabledBackColor = Color.WhiteSmoke;
            tbUsername.DisabledBorderColor = Color.LightGray;
            tbUsername.DisabledTextColor = Color.Gray;
            tbUsername.EnableDropShadow = false;
            tbUsername.FillColor1 = Color.White;
            tbUsername.FillColor2 = Color.White;
            tbUsername.Font = new Font("Inter", 10.2F);
            tbUsername.ForeColor = Color.DimGray;
            tbUsername.HoverBorderColor1 = Color.Gray;
            tbUsername.HoverBorderColor2 = Color.Gray;
            tbUsername.IsEnabled = true;
            tbUsername.Location = new Point(226, 223);
            tbUsername.Name = "tbUsername";
            tbUsername.PlaceholderColor = Color.Gray;
            tbUsername.PlaceholderText = "Nhập vào đây";
            tbUsername.ReadOnlyBorderColor1 = Color.LightGray;
            tbUsername.ReadOnlyBorderColor2 = Color.LightGray;
            tbUsername.ReadOnlyFillColor1 = Color.WhiteSmoke;
            tbUsername.ReadOnlyFillColor2 = Color.WhiteSmoke;
            tbUsername.ReadOnlyPlaceholderColor = Color.DarkGray;
            tbUsername.SelectionBackColor = Color.FromArgb(77, 77, 255);
            tbUsername.ShadowAnimationDuration = 1;
            tbUsername.ShadowBlur = 10;
            tbUsername.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            tbUsername.Size = new Size(255, 47);
            tbUsername.SolidBorderColor = Color.LightSlateGray;
            tbUsername.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            tbUsername.SolidBorderHoverColor = Color.Gray;
            tbUsername.SolidFillColor = Color.White;
            tbUsername.TabIndex = 12;
            tbUsername.Text = "Your username";
            tbUsername.TextPadding = new Padding(8, 0, 6, 0);
            tbUsername.ValidationErrorMessage = "Invalid input.";
            tbUsername.ValidationFunction = null;
            // 
            // tbEmail
            // 
            tbEmail.AccessibleDescription = "A customizable text input field.";
            tbEmail.AccessibleName = "Text Box";
            tbEmail.AccessibleRole = AccessibleRole.Text;
            tbEmail.BackColor = Color.Transparent;
            tbEmail.BlinkCount = 3;
            tbEmail.BlinkShadow = false;
            tbEmail.BorderColor1 = Color.LightSlateGray;
            tbEmail.BorderColor2 = Color.LightSlateGray;
            tbEmail.BorderFocusColor1 = Color.FromArgb(77, 77, 255);
            tbEmail.BorderFocusColor2 = Color.FromArgb(77, 77, 255);
            tbEmail.CanShake = true;
            tbEmail.ContinuousBlink = false;
            tbEmail.CursorBlinkRate = 500;
            tbEmail.CursorColor = Color.Black;
            tbEmail.CursorHeight = 26;
            tbEmail.CursorOffset = 0;
            tbEmail.CursorStyle = SiticoneNetCoreUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            tbEmail.CursorWidth = 1;
            tbEmail.DisabledBackColor = Color.WhiteSmoke;
            tbEmail.DisabledBorderColor = Color.LightGray;
            tbEmail.DisabledTextColor = Color.Gray;
            tbEmail.EnableDropShadow = false;
            tbEmail.FillColor1 = Color.White;
            tbEmail.FillColor2 = Color.White;
            tbEmail.Font = new Font("Inter", 10.2F);
            tbEmail.ForeColor = Color.DimGray;
            tbEmail.HoverBorderColor1 = Color.Gray;
            tbEmail.HoverBorderColor2 = Color.Gray;
            tbEmail.IsEnabled = true;
            tbEmail.Location = new Point(226, 335);
            tbEmail.Name = "tbEmail";
            tbEmail.PlaceholderColor = Color.Gray;
            tbEmail.PlaceholderText = "Nhập vào đây";
            tbEmail.ReadOnlyBorderColor1 = Color.LightGray;
            tbEmail.ReadOnlyBorderColor2 = Color.LightGray;
            tbEmail.ReadOnlyFillColor1 = Color.WhiteSmoke;
            tbEmail.ReadOnlyFillColor2 = Color.WhiteSmoke;
            tbEmail.ReadOnlyPlaceholderColor = Color.DarkGray;
            tbEmail.SelectionBackColor = Color.FromArgb(77, 77, 255);
            tbEmail.ShadowAnimationDuration = 1;
            tbEmail.ShadowBlur = 10;
            tbEmail.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            tbEmail.Size = new Size(255, 47);
            tbEmail.SolidBorderColor = Color.LightSlateGray;
            tbEmail.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            tbEmail.SolidBorderHoverColor = Color.Gray;
            tbEmail.SolidFillColor = Color.White;
            tbEmail.TabIndex = 17;
            tbEmail.Text = "Your email";
            tbEmail.TextPadding = new Padding(8, 0, 6, 0);
            tbEmail.ValidationErrorMessage = "Invalid input.";
            tbEmail.ValidationFunction = null;
            // 
            // tbNewPassword
            // 
            tbNewPassword.AccessibleDescription = "A customizable text input field.";
            tbNewPassword.AccessibleName = "Text Box";
            tbNewPassword.AccessibleRole = AccessibleRole.Text;
            tbNewPassword.BackColor = Color.Transparent;
            tbNewPassword.BlinkCount = 3;
            tbNewPassword.BlinkShadow = false;
            tbNewPassword.BorderColor1 = Color.LightSlateGray;
            tbNewPassword.BorderColor2 = Color.LightSlateGray;
            tbNewPassword.BorderFocusColor1 = Color.FromArgb(77, 77, 255);
            tbNewPassword.BorderFocusColor2 = Color.FromArgb(77, 77, 255);
            tbNewPassword.CanShake = true;
            tbNewPassword.ContinuousBlink = false;
            tbNewPassword.CursorBlinkRate = 500;
            tbNewPassword.CursorColor = Color.Black;
            tbNewPassword.CursorHeight = 26;
            tbNewPassword.CursorOffset = 0;
            tbNewPassword.CursorStyle = SiticoneNetCoreUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            tbNewPassword.CursorWidth = 1;
            tbNewPassword.DisabledBackColor = Color.WhiteSmoke;
            tbNewPassword.DisabledBorderColor = Color.LightGray;
            tbNewPassword.DisabledTextColor = Color.Gray;
            tbNewPassword.EnableDropShadow = false;
            tbNewPassword.FillColor1 = Color.White;
            tbNewPassword.FillColor2 = Color.White;
            tbNewPassword.Font = new Font("Inter", 10.2F);
            tbNewPassword.ForeColor = Color.DimGray;
            tbNewPassword.HoverBorderColor1 = Color.Gray;
            tbNewPassword.HoverBorderColor2 = Color.Gray;
            tbNewPassword.IsEnabled = true;
            tbNewPassword.Location = new Point(226, 454);
            tbNewPassword.Name = "tbNewPassword";
            tbNewPassword.PlaceholderColor = Color.Gray;
            tbNewPassword.PlaceholderText = "Nhập vào đây";
            tbNewPassword.ReadOnlyBorderColor1 = Color.LightGray;
            tbNewPassword.ReadOnlyBorderColor2 = Color.LightGray;
            tbNewPassword.ReadOnlyFillColor1 = Color.WhiteSmoke;
            tbNewPassword.ReadOnlyFillColor2 = Color.WhiteSmoke;
            tbNewPassword.ReadOnlyPlaceholderColor = Color.DarkGray;
            tbNewPassword.SelectionBackColor = Color.FromArgb(77, 77, 255);
            tbNewPassword.ShadowAnimationDuration = 1;
            tbNewPassword.ShadowBlur = 10;
            tbNewPassword.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            tbNewPassword.Size = new Size(255, 47);
            tbNewPassword.SolidBorderColor = Color.LightSlateGray;
            tbNewPassword.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            tbNewPassword.SolidBorderHoverColor = Color.Gray;
            tbNewPassword.SolidFillColor = Color.White;
            tbNewPassword.TabIndex = 19;
            tbNewPassword.Text = "*********";
            tbNewPassword.TextPadding = new Padding(8, 0, 6, 0);
            tbNewPassword.ValidationErrorMessage = "Invalid input.";
            tbNewPassword.ValidationFunction = null;
            // 
            // tbConfirmPassword
            // 
            tbConfirmPassword.AccessibleDescription = "A customizable text input field.";
            tbConfirmPassword.AccessibleName = "Text Box";
            tbConfirmPassword.AccessibleRole = AccessibleRole.Text;
            tbConfirmPassword.BackColor = Color.Transparent;
            tbConfirmPassword.BlinkCount = 3;
            tbConfirmPassword.BlinkShadow = false;
            tbConfirmPassword.BorderColor1 = Color.LightSlateGray;
            tbConfirmPassword.BorderColor2 = Color.LightSlateGray;
            tbConfirmPassword.BorderFocusColor1 = Color.FromArgb(77, 77, 255);
            tbConfirmPassword.BorderFocusColor2 = Color.FromArgb(77, 77, 255);
            tbConfirmPassword.CanShake = true;
            tbConfirmPassword.ContinuousBlink = false;
            tbConfirmPassword.CursorBlinkRate = 500;
            tbConfirmPassword.CursorColor = Color.Black;
            tbConfirmPassword.CursorHeight = 26;
            tbConfirmPassword.CursorOffset = 0;
            tbConfirmPassword.CursorStyle = SiticoneNetCoreUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            tbConfirmPassword.CursorWidth = 1;
            tbConfirmPassword.DisabledBackColor = Color.WhiteSmoke;
            tbConfirmPassword.DisabledBorderColor = Color.LightGray;
            tbConfirmPassword.DisabledTextColor = Color.Gray;
            tbConfirmPassword.EnableDropShadow = false;
            tbConfirmPassword.FillColor1 = Color.White;
            tbConfirmPassword.FillColor2 = Color.White;
            tbConfirmPassword.Font = new Font("Inter", 10.2F);
            tbConfirmPassword.ForeColor = Color.DimGray;
            tbConfirmPassword.HoverBorderColor1 = Color.Gray;
            tbConfirmPassword.HoverBorderColor2 = Color.Gray;
            tbConfirmPassword.IsEnabled = true;
            tbConfirmPassword.Location = new Point(226, 563);
            tbConfirmPassword.Name = "tbConfirmPassword";
            tbConfirmPassword.PlaceholderColor = Color.Gray;
            tbConfirmPassword.PlaceholderText = "Nhập vào đây";
            tbConfirmPassword.ReadOnlyBorderColor1 = Color.LightGray;
            tbConfirmPassword.ReadOnlyBorderColor2 = Color.LightGray;
            tbConfirmPassword.ReadOnlyFillColor1 = Color.WhiteSmoke;
            tbConfirmPassword.ReadOnlyFillColor2 = Color.WhiteSmoke;
            tbConfirmPassword.ReadOnlyPlaceholderColor = Color.DarkGray;
            tbConfirmPassword.SelectionBackColor = Color.FromArgb(77, 77, 255);
            tbConfirmPassword.ShadowAnimationDuration = 1;
            tbConfirmPassword.ShadowBlur = 10;
            tbConfirmPassword.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            tbConfirmPassword.Size = new Size(255, 47);
            tbConfirmPassword.SolidBorderColor = Color.LightSlateGray;
            tbConfirmPassword.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            tbConfirmPassword.SolidBorderHoverColor = Color.Gray;
            tbConfirmPassword.SolidFillColor = Color.White;
            tbConfirmPassword.TabIndex = 20;
            tbConfirmPassword.Text = "*********";
            tbConfirmPassword.TextPadding = new Padding(8, 0, 6, 0);
            tbConfirmPassword.ValidationErrorMessage = "Invalid input.";
            tbConfirmPassword.ValidationFunction = null;
            // 
            // siticoneLabel7
            // 
            siticoneLabel7.BackColor = Color.Transparent;
            siticoneLabel7.Font = new Font("Inter", 28F, FontStyle.Bold);
            siticoneLabel7.ForeColor = SystemColors.ActiveCaptionText;
            siticoneLabel7.Location = new Point(226, 62);
            siticoneLabel7.Name = "siticoneLabel7";
            siticoneLabel7.Size = new Size(165, 64);
            siticoneLabel7.TabIndex = 24;
            siticoneLabel7.Text = "Hồ sơ";
            siticoneLabel7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // siticoneLabel9
            // 
            siticoneLabel9.BackColor = Color.Transparent;
            siticoneLabel9.Font = new Font("Inter", 10F, FontStyle.Bold);
            siticoneLabel9.ForeColor = Color.LimeGreen;
            siticoneLabel9.Location = new Point(1062, 613);
            siticoneLabel9.Name = "siticoneLabel9";
            siticoneLabel9.Size = new Size(69, 28);
            siticoneLabel9.TabIndex = 27;
            siticoneLabel9.Text = "Online";
            // 
            // editAvatarButton
            // 
            editAvatarButton.BackColor = Color.Transparent;
            editAvatarButton.Cursor = Cursors.Hand;
            editAvatarButton.Image = (Image)resources.GetObject("editAvatarButton.Image");
            editAvatarButton.InitialImage = (Image)resources.GetObject("editAvatarButton.InitialImage");
            editAvatarButton.Location = new Point(1137, 180);
            editAvatarButton.Name = "editAvatarButton";
            editAvatarButton.Size = new Size(21, 23);
            editAvatarButton.SizeMode = PictureBoxSizeMode.Zoom;
            editAvatarButton.TabIndex = 28;
            editAvatarButton.TabStop = false;
            // 
            // btnSave
            // 
            btnSave.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnSave.AccessibleName = "Lưu thay đổi";
            btnSave.AutoSizeBasedOnText = false;
            btnSave.BackColor = Color.Transparent;
            btnSave.BadgeBackColor = Color.Red;
            btnSave.BadgeFont = new Font("Inter", 8F, FontStyle.Bold);
            btnSave.BadgeValue = 0;
            btnSave.BadgeValueForeColor = Color.White;
            btnSave.BorderColor = Color.DarkSeaGreen;
            btnSave.BorderWidth = 2;
            btnSave.ButtonBackColor = Color.DarkSeaGreen;
            btnSave.ButtonImage = null;
            btnSave.CanBeep = true;
            btnSave.CanGlow = false;
            btnSave.CanShake = true;
            btnSave.ContextMenuStripEx = null;
            btnSave.CornerRadiusBottomLeft = 0;
            btnSave.CornerRadiusBottomRight = 0;
            btnSave.CornerRadiusTopLeft = 0;
            btnSave.CornerRadiusTopRight = 0;
            btnSave.CustomCursor = Cursors.Default;
            btnSave.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnSave.EnableLongPress = false;
            btnSave.EnablePressAnimation = true;
            btnSave.EnableRippleEffect = true;
            btnSave.EnableShadow = false;
            btnSave.EnableTextWrapping = false;
            btnSave.Font = new Font("Inter", 11F);
            btnSave.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnSave.GlowIntensity = 100;
            btnSave.GlowRadius = 20F;
            btnSave.GradientBackground = false;
            btnSave.GradientColor = Color.Transparent;
            btnSave.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnSave.HintText = null;
            btnSave.HoverBackColor = Color.DarkSeaGreen;
            btnSave.HoverFontStyle = FontStyle.Regular;
            btnSave.HoverTextColor = Color.White;
            btnSave.HoverTransitionDuration = 250;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.ImagePadding = 5;
            btnSave.ImageSize = new Size(16, 16);
            btnSave.IsRadial = false;
            btnSave.IsReadOnly = false;
            btnSave.IsToggleButton = false;
            btnSave.IsToggled = false;
            btnSave.Location = new Point(226, 675);
            btnSave.LongPressDurationMS = 1000;
            btnSave.Name = "btnSave";
            btnSave.NormalFontStyle = FontStyle.Regular;
            btnSave.ParticleColor = Color.FromArgb(200, 200, 200);
            btnSave.ParticleCount = 15;
            btnSave.PressAnimationScale = 0.97F;
            btnSave.PressedBackColor = Color.SeaGreen;
            btnSave.PressedFontStyle = FontStyle.Regular;
            btnSave.PressTransitionDuration = 150;
            btnSave.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnSave.RippleColor = Color.FromArgb(255, 255, 255);
            btnSave.RippleOpacity = 0.3F;
            btnSave.RippleRadiusMultiplier = 0.6F;
            btnSave.ShadowBlur = 5;
            btnSave.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnSave.ShadowOffset = new Point(2, 2);
            btnSave.ShakeDuration = 500;
            btnSave.ShakeIntensity = 5;
            btnSave.Size = new Size(255, 49);
            btnSave.TabIndex = 29;
            btnSave.Text = "Lưu thay đổi";
            btnSave.TextAlign = ContentAlignment.MiddleCenter;
            btnSave.TextColor = Color.White;
            btnSave.TooltipText = null;
            btnSave.UseAdvancedRendering = true;
            btnSave.UseParticles = false;
            btnSave.Click += btnSave_Click_1;
            // 
            // userProfilePanel1
            // 
            userProfilePanel1.BackColor = Color.Transparent;
            userProfilePanel1.Location = new Point(987, 12);
            userProfilePanel1.Name = "userProfilePanel1";
            userProfilePanel1.Size = new Size(277, 71);
            userProfilePanel1.TabIndex = 30;
            // 
            // Profile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 255, 224);
            ClientSize = new Size(1264, 930);
            Controls.Add(userProfilePanel1);
            Controls.Add(btnSave);
            Controls.Add(editAvatarButton);
            Controls.Add(siticoneLabel9);
            Controls.Add(siticoneLabel7);
            Controls.Add(tbConfirmPassword);
            Controls.Add(tbNewPassword);
            Controls.Add(tbEmail);
            Controls.Add(tbUsername);
            Controls.Add(siticoneLabel5);
            Controls.Add(siticoneLabel4);
            Controls.Add(siticoneLabel2);
            Controls.Add(siticoneLabel1);
            Controls.Add(pictureBox_avatar);
            Name = "Profile";
            Text = "Profile";
            ((System.ComponentModel.ISupportInitialize)pictureBox_avatar).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)editAvatarButton).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox_avatar;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel1;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel2;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel4;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel5;
        private SiticoneNetCoreUI.SiticoneTextBox tbUsername;
        private SiticoneNetCoreUI.SiticoneTextBox tbEmail;
        private SiticoneNetCoreUI.SiticoneTextBox tbNewPassword;
        private SiticoneNetCoreUI.SiticoneTextBox tbConfirmPassword;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel7;
        private BindingSource bindingSource1;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel9;
        private PictureBox editAvatarButton;
        private SiticoneNetCoreUI.SiticoneButton btnSave;
        private UserProfilePanel userProfilePanel1;
        private SideBar sideBar1;
    }
}
