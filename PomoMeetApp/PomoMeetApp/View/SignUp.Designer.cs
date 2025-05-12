namespace PomoMeetApp.View
{
    partial class SignUp
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
            tbUsername = new SiticoneNetCoreUI.SiticoneTextBox();
            label2 = new Label();
            tbPassword = new SiticoneNetCoreUI.SiticoneTextBox();
            label3 = new Label();
            tbPasswordConfirm = new SiticoneNetCoreUI.SiticoneTextBox();
            btnSignUp = new SiticoneNetCoreUI.SiticoneButton();
            label4 = new Label();
            siticoneButton2 = new SiticoneNetCoreUI.SiticoneButton();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            siticoneCheckBox1 = new SiticoneNetCoreUI.SiticoneCheckBox();
            txtEmail = new SiticoneNetCoreUI.SiticoneTextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)Rectangle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // Rectangle
            // 
            Rectangle.Image = Properties.Resources.Rectangle;
            Rectangle.Location = new Point(385, 36);
            Rectangle.Name = "Rectangle";
            Rectangle.Size = new Size(645, 823);
            Rectangle.TabIndex = 0;
            Rectangle.TabStop = false;
            Rectangle.Click += Rectangle_Click;
            // 
            // email
            // 
            email.AutoSize = true;
            email.BackColor = Color.FromArgb(233, 240, 201);
            email.Font = new Font("Inter", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            email.ForeColor = Color.FromArgb(117, 164, 127);
            email.Location = new Point(428, 144);
            email.Name = "email";
            email.Size = new Size(157, 40);
            email.TabIndex = 1;
            email.Text = "Username";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(233, 240, 201);
            label1.Font = new Font("Inter", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(117, 164, 127);
            label1.Location = new Point(618, 88);
            label1.Name = "label1";
            label1.Size = new Size(170, 53);
            label1.TabIndex = 2;
            label1.Text = "Đăng ký";
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
            tbUsername.Font = new Font("Inter", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbUsername.ForeColor = Color.DimGray;
            tbUsername.HoverBorderColor1 = Color.Gray;
            tbUsername.HoverBorderColor2 = Color.Gray;
            tbUsername.IsEnabled = true;
            tbUsername.Location = new Point(437, 187);
            tbUsername.Name = "tbUsername";
            tbUsername.PlaceholderColor = Color.Gray;
            tbUsername.PlaceholderText = "Enter text here...";
            tbUsername.ReadOnlyBorderColor1 = Color.LightGray;
            tbUsername.ReadOnlyBorderColor2 = Color.LightGray;
            tbUsername.ReadOnlyFillColor1 = Color.WhiteSmoke;
            tbUsername.ReadOnlyFillColor2 = Color.WhiteSmoke;
            tbUsername.ReadOnlyPlaceholderColor = Color.DarkGray;
            tbUsername.SelectionBackColor = Color.FromArgb(77, 77, 255);
            tbUsername.ShadowAnimationDuration = 1;
            tbUsername.ShadowBlur = 10;
            tbUsername.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            tbUsername.ShowBorder = false;
            tbUsername.Size = new Size(537, 63);
            tbUsername.SolidBorderColor = Color.LightSlateGray;
            tbUsername.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            tbUsername.SolidBorderHoverColor = Color.Gray;
            tbUsername.SolidFillColor = Color.White;
            tbUsername.TabIndex = 3;
            tbUsername.TextPadding = new Padding(16, 0, 6, 0);
            tbUsername.ValidationErrorMessage = "Invalid input.";
            tbUsername.ValidationFunction = null;
            tbUsername.KeyDown += tbUsername_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(233, 240, 201);
            label2.Font = new Font("Inter", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(117, 164, 127);
            label2.Location = new Point(428, 395);
            label2.Name = "label2";
            label2.Size = new Size(142, 40);
            label2.TabIndex = 4;
            label2.Text = "Mật khẩu";
            // 
            // tbPassword
            // 
            tbPassword.AccessibleDescription = "A customizable text input field.";
            tbPassword.AccessibleName = "Text Box";
            tbPassword.AccessibleRole = AccessibleRole.Text;
            tbPassword.BackColor = Color.Transparent;
            tbPassword.BlinkCount = 3;
            tbPassword.BlinkShadow = false;
            tbPassword.BorderColor1 = Color.LightSlateGray;
            tbPassword.BorderColor2 = Color.LightSlateGray;
            tbPassword.BorderFocusColor1 = Color.FromArgb(77, 77, 255);
            tbPassword.BorderFocusColor2 = Color.FromArgb(77, 77, 255);
            tbPassword.CanShake = true;
            tbPassword.ContinuousBlink = false;
            tbPassword.CursorBlinkRate = 500;
            tbPassword.CursorColor = Color.Black;
            tbPassword.CursorHeight = 26;
            tbPassword.CursorOffset = 0;
            tbPassword.CursorStyle = SiticoneNetCoreUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            tbPassword.CursorWidth = 1;
            tbPassword.DisabledBackColor = Color.WhiteSmoke;
            tbPassword.DisabledBorderColor = Color.LightGray;
            tbPassword.DisabledTextColor = Color.Gray;
            tbPassword.EnableDropShadow = false;
            tbPassword.FillColor1 = Color.White;
            tbPassword.FillColor2 = Color.White;
            tbPassword.Font = new Font("Inter", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbPassword.ForeColor = Color.DimGray;
            tbPassword.HoverBorderColor1 = Color.Gray;
            tbPassword.HoverBorderColor2 = Color.Gray;
            tbPassword.IsEnabled = true;
            tbPassword.Location = new Point(437, 438);
            tbPassword.Name = "tbPassword";
            tbPassword.PlaceholderColor = Color.Gray;
            tbPassword.PlaceholderText = "Enter text here...";
            tbPassword.ReadOnlyBorderColor1 = Color.LightGray;
            tbPassword.ReadOnlyBorderColor2 = Color.LightGray;
            tbPassword.ReadOnlyFillColor1 = Color.WhiteSmoke;
            tbPassword.ReadOnlyFillColor2 = Color.WhiteSmoke;
            tbPassword.ReadOnlyPlaceholderColor = Color.DarkGray;
            tbPassword.SelectionBackColor = Color.FromArgb(77, 77, 255);
            tbPassword.ShadowAnimationDuration = 1;
            tbPassword.ShadowBlur = 10;
            tbPassword.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            tbPassword.ShowBorder = false;
            tbPassword.Size = new Size(537, 63);
            tbPassword.SolidBorderColor = Color.LightSlateGray;
            tbPassword.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            tbPassword.SolidBorderHoverColor = Color.Gray;
            tbPassword.SolidFillColor = Color.White;
            tbPassword.TabIndex = 5;
            tbPassword.TextPadding = new Padding(16, 0, 6, 0);
            tbPassword.UseSystemPasswordChar = true;
            tbPassword.ValidationErrorMessage = "Invalid input.";
            tbPassword.ValidationFunction = null;
            tbPassword.KeyDown += tbPassword_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(233, 240, 201);
            label3.Font = new Font("Inter", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(117, 164, 127);
            label3.Location = new Point(428, 525);
            label3.Name = "label3";
            label3.Size = new Size(274, 40);
            label3.TabIndex = 6;
            label3.Text = "Xác nhận mật khẩu";
            // 
            // tbPasswordConfirm
            // 
            tbPasswordConfirm.AccessibleDescription = "A customizable text input field.";
            tbPasswordConfirm.AccessibleName = "Text Box";
            tbPasswordConfirm.AccessibleRole = AccessibleRole.Text;
            tbPasswordConfirm.BackColor = Color.Transparent;
            tbPasswordConfirm.BlinkCount = 3;
            tbPasswordConfirm.BlinkShadow = false;
            tbPasswordConfirm.BorderColor1 = Color.LightSlateGray;
            tbPasswordConfirm.BorderColor2 = Color.LightSlateGray;
            tbPasswordConfirm.BorderFocusColor1 = Color.FromArgb(77, 77, 255);
            tbPasswordConfirm.BorderFocusColor2 = Color.FromArgb(77, 77, 255);
            tbPasswordConfirm.CanShake = true;
            tbPasswordConfirm.ContinuousBlink = false;
            tbPasswordConfirm.CursorBlinkRate = 500;
            tbPasswordConfirm.CursorColor = Color.Black;
            tbPasswordConfirm.CursorHeight = 26;
            tbPasswordConfirm.CursorOffset = 0;
            tbPasswordConfirm.CursorStyle = SiticoneNetCoreUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            tbPasswordConfirm.CursorWidth = 1;
            tbPasswordConfirm.DisabledBackColor = Color.WhiteSmoke;
            tbPasswordConfirm.DisabledBorderColor = Color.LightGray;
            tbPasswordConfirm.DisabledTextColor = Color.Gray;
            tbPasswordConfirm.EnableDropShadow = false;
            tbPasswordConfirm.FillColor1 = Color.White;
            tbPasswordConfirm.FillColor2 = Color.White;
            tbPasswordConfirm.Font = new Font("Inter", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbPasswordConfirm.ForeColor = Color.DimGray;
            tbPasswordConfirm.HoverBorderColor1 = Color.Gray;
            tbPasswordConfirm.HoverBorderColor2 = Color.Gray;
            tbPasswordConfirm.IsEnabled = true;
            tbPasswordConfirm.Location = new Point(437, 568);
            tbPasswordConfirm.Name = "tbPasswordConfirm";
            tbPasswordConfirm.PlaceholderColor = Color.Gray;
            tbPasswordConfirm.PlaceholderText = "Enter text here...";
            tbPasswordConfirm.ReadOnlyBorderColor1 = Color.LightGray;
            tbPasswordConfirm.ReadOnlyBorderColor2 = Color.LightGray;
            tbPasswordConfirm.ReadOnlyFillColor1 = Color.WhiteSmoke;
            tbPasswordConfirm.ReadOnlyFillColor2 = Color.WhiteSmoke;
            tbPasswordConfirm.ReadOnlyPlaceholderColor = Color.DarkGray;
            tbPasswordConfirm.SelectionBackColor = Color.FromArgb(77, 77, 255);
            tbPasswordConfirm.ShadowAnimationDuration = 1;
            tbPasswordConfirm.ShadowBlur = 10;
            tbPasswordConfirm.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            tbPasswordConfirm.ShowBorder = false;
            tbPasswordConfirm.Size = new Size(537, 63);
            tbPasswordConfirm.SolidBorderColor = Color.LightSlateGray;
            tbPasswordConfirm.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            tbPasswordConfirm.SolidBorderHoverColor = Color.Gray;
            tbPasswordConfirm.SolidFillColor = Color.White;
            tbPasswordConfirm.TabIndex = 7;
            tbPasswordConfirm.TextPadding = new Padding(16, 0, 6, 0);
            tbPasswordConfirm.UseSystemPasswordChar = true;
            tbPasswordConfirm.ValidationErrorMessage = "Invalid input.";
            tbPasswordConfirm.ValidationFunction = null;
            tbPasswordConfirm.KeyDown += tbPasswordConfirm_KeyDown;
            // 
            // btnSignUp
            // 
            btnSignUp.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnSignUp.AccessibleName = "Đăng ký";
            btnSignUp.AutoSizeBasedOnText = false;
            btnSignUp.BackColor = Color.Transparent;
            btnSignUp.BadgeBackColor = Color.Red;
            btnSignUp.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnSignUp.BadgeValue = 0;
            btnSignUp.BadgeValueForeColor = Color.White;
            btnSignUp.BorderColor = Color.FromArgb(117, 164, 127);
            btnSignUp.BorderWidth = 2;
            btnSignUp.ButtonBackColor = Color.White;
            btnSignUp.ButtonImage = null;
            btnSignUp.CanBeep = true;
            btnSignUp.CanGlow = false;
            btnSignUp.CanShake = true;
            btnSignUp.ContextMenuStripEx = null;
            btnSignUp.CornerRadiusBottomLeft = 0;
            btnSignUp.CornerRadiusBottomRight = 0;
            btnSignUp.CornerRadiusTopLeft = 0;
            btnSignUp.CornerRadiusTopRight = 0;
            btnSignUp.CustomCursor = Cursors.Default;
            btnSignUp.DisabledTextColor = Color.FromArgb(117, 164, 127);
            btnSignUp.EnableLongPress = false;
            btnSignUp.EnablePressAnimation = true;
            btnSignUp.EnableRippleEffect = true;
            btnSignUp.EnableShadow = false;
            btnSignUp.EnableTextWrapping = false;
            btnSignUp.Font = new Font("Inter", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSignUp.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnSignUp.GlowIntensity = 100;
            btnSignUp.GlowRadius = 20F;
            btnSignUp.GradientBackground = false;
            btnSignUp.GradientColor = Color.White;
            btnSignUp.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnSignUp.HintText = null;
            btnSignUp.HoverBackColor = Color.FromArgb(117, 164, 127);
            btnSignUp.HoverFontStyle = FontStyle.Regular;
            btnSignUp.HoverTextColor = Color.White;
            btnSignUp.HoverTransitionDuration = 250;
            btnSignUp.ImageAlign = ContentAlignment.MiddleLeft;
            btnSignUp.ImagePadding = 5;
            btnSignUp.ImageSize = new Size(16, 16);
            btnSignUp.IsRadial = false;
            btnSignUp.IsReadOnly = false;
            btnSignUp.IsToggleButton = false;
            btnSignUp.IsToggled = false;
            btnSignUp.Location = new Point(437, 703);
            btnSignUp.LongPressDurationMS = 1000;
            btnSignUp.Name = "btnSignUp";
            btnSignUp.NormalFontStyle = FontStyle.Regular;
            btnSignUp.ParticleColor = Color.FromArgb(200, 200, 200);
            btnSignUp.ParticleCount = 15;
            btnSignUp.PressAnimationScale = 0.97F;
            btnSignUp.PressedBackColor = Color.FromArgb(117, 164, 127);
            btnSignUp.PressedFontStyle = FontStyle.Regular;
            btnSignUp.PressTransitionDuration = 150;
            btnSignUp.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnSignUp.RippleColor = Color.FromArgb(255, 255, 255);
            btnSignUp.RippleOpacity = 0.3F;
            btnSignUp.RippleRadiusMultiplier = 0.6F;
            btnSignUp.ShadowBlur = 5;
            btnSignUp.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnSignUp.ShadowOffset = new Point(2, 2);
            btnSignUp.ShakeDuration = 500;
            btnSignUp.ShakeIntensity = 5;
            btnSignUp.Size = new Size(537, 47);
            btnSignUp.TabIndex = 8;
            btnSignUp.Text = "Đăng ký";
            btnSignUp.TextAlign = ContentAlignment.MiddleCenter;
            btnSignUp.TextColor = Color.FromArgb(117, 164, 127);
            btnSignUp.TooltipText = null;
            btnSignUp.UseAdvancedRendering = true;
            btnSignUp.UseParticles = false;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(233, 240, 201);
            label4.Font = new Font("Inter", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(582, 789);
            label4.Name = "label4";
            label4.Size = new Size(161, 22);
            label4.TabIndex = 9;
            label4.Text = "Bạn đã có tải khoản?";
            // 
            // siticoneButton2
            // 
            siticoneButton2.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            siticoneButton2.AccessibleName = "Đăng nhập";
            siticoneButton2.AutoSizeBasedOnText = false;
            siticoneButton2.BackColor = Color.Transparent;
            siticoneButton2.BadgeBackColor = Color.Red;
            siticoneButton2.BadgeFont = new Font("Inter", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            siticoneButton2.BadgeValue = 0;
            siticoneButton2.BadgeValueForeColor = Color.White;
            siticoneButton2.BorderColor = Color.FromArgb(117, 164, 127);
            siticoneButton2.BorderWidth = 2;
            siticoneButton2.ButtonBackColor = Color.White;
            siticoneButton2.ButtonImage = null;
            siticoneButton2.CanBeep = true;
            siticoneButton2.CanGlow = false;
            siticoneButton2.CanShake = true;
            siticoneButton2.ContextMenuStripEx = null;
            siticoneButton2.CornerRadiusBottomLeft = 0;
            siticoneButton2.CornerRadiusBottomRight = 0;
            siticoneButton2.CornerRadiusTopLeft = 0;
            siticoneButton2.CornerRadiusTopRight = 0;
            siticoneButton2.CustomCursor = Cursors.Default;
            siticoneButton2.DisabledTextColor = Color.FromArgb(117, 164, 127);
            siticoneButton2.EnableLongPress = false;
            siticoneButton2.EnablePressAnimation = true;
            siticoneButton2.EnableRippleEffect = true;
            siticoneButton2.EnableShadow = false;
            siticoneButton2.EnableTextWrapping = false;
            siticoneButton2.Font = new Font("Inter", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            siticoneButton2.ForeColor = Color.FromArgb(117, 164, 127);
            siticoneButton2.GlowColor = Color.FromArgb(100, 255, 255, 255);
            siticoneButton2.GlowIntensity = 100;
            siticoneButton2.GlowRadius = 20F;
            siticoneButton2.GradientBackground = false;
            siticoneButton2.GradientColor = Color.FromArgb(114, 168, 255);
            siticoneButton2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneButton2.HintText = null;
            siticoneButton2.HoverBackColor = Color.FromArgb(114, 168, 255);
            siticoneButton2.HoverFontStyle = FontStyle.Regular;
            siticoneButton2.HoverTextColor = Color.White;
            siticoneButton2.HoverTransitionDuration = 250;
            siticoneButton2.ImageAlign = ContentAlignment.MiddleLeft;
            siticoneButton2.ImagePadding = 5;
            siticoneButton2.ImageSize = new Size(16, 16);
            siticoneButton2.IsRadial = false;
            siticoneButton2.IsReadOnly = false;
            siticoneButton2.IsToggleButton = false;
            siticoneButton2.IsToggled = false;
            siticoneButton2.Location = new Point(763, 781);
            siticoneButton2.LongPressDurationMS = 1000;
            siticoneButton2.Name = "siticoneButton2";
            siticoneButton2.NormalFontStyle = FontStyle.Regular;
            siticoneButton2.ParticleColor = Color.FromArgb(200, 200, 200);
            siticoneButton2.ParticleCount = 15;
            siticoneButton2.PressAnimationScale = 0.97F;
            siticoneButton2.PressedBackColor = Color.FromArgb(74, 128, 235);
            siticoneButton2.PressedFontStyle = FontStyle.Regular;
            siticoneButton2.PressTransitionDuration = 150;
            siticoneButton2.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            siticoneButton2.RippleColor = Color.FromArgb(255, 255, 255);
            siticoneButton2.RippleOpacity = 0.3F;
            siticoneButton2.RippleRadiusMultiplier = 0.6F;
            siticoneButton2.ShadowBlur = 5;
            siticoneButton2.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            siticoneButton2.ShadowOffset = new Point(2, 2);
            siticoneButton2.ShakeDuration = 500;
            siticoneButton2.ShakeIntensity = 5;
            siticoneButton2.Size = new Size(87, 30);
            siticoneButton2.TabIndex = 10;
            siticoneButton2.Text = "Đăng nhập";
            siticoneButton2.TextAlign = ContentAlignment.MiddleCenter;
            siticoneButton2.TextColor = Color.FromArgb(117, 164, 127);
            siticoneButton2.TooltipText = null;
            siticoneButton2.UseAdvancedRendering = true;
            siticoneButton2.UseParticles = false;
            siticoneButton2.Click += siticoneButton2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Ellipse;
            pictureBox1.Location = new Point(-2, 664);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(299, 313);
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Decoration_1;
            pictureBox2.Location = new Point(1118, -2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(305, 228);
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.SmallLogo;
            pictureBox3.Location = new Point(12, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(90, 76);
            pictureBox3.TabIndex = 13;
            pictureBox3.TabStop = false;
            // 
            // siticoneCheckBox1
            // 
            siticoneCheckBox1.AccessibleName = "Show password";
            siticoneCheckBox1.AccessibleRole = AccessibleRole.CheckButton;
            siticoneCheckBox1.AllowIndeterminate = false;
            siticoneCheckBox1.BackColor = Color.FromArgb(233, 240, 201);
            siticoneCheckBox1.BorderColor = Color.Transparent;
            siticoneCheckBox1.BorderWidth = 2;
            siticoneCheckBox1.BottomLeftRadius = 3;
            siticoneCheckBox1.BottomRightRadius = 3;
            siticoneCheckBox1.CanBeep = true;
            siticoneCheckBox1.CanShake = true;
            siticoneCheckBox1.CheckBoxSize = 20;
            siticoneCheckBox1.Checked = false;
            siticoneCheckBox1.CheckedBackColor = Color.FromArgb(186, 205, 146);
            siticoneCheckBox1.CheckedBorderColor = Color.FromArgb(186, 205, 146);
            siticoneCheckBox1.CheckmarkColor = Color.White;
            siticoneCheckBox1.CheckState = SiticoneNetCoreUI.CheckState.Unchecked;
            siticoneCheckBox1.ContainerBackColor = Color.FromArgb(252, 255, 224);
            siticoneCheckBox1.ContainerBorderColor = Color.FromArgb(50, 0, 0, 0);
            siticoneCheckBox1.ContainerBorderWidth = 1;
            siticoneCheckBox1.ContainerBottomLeftRadius = 8;
            siticoneCheckBox1.ContainerBottomRightRadius = 8;
            siticoneCheckBox1.ContainerCheckedBorderColor = Color.Transparent;
            siticoneCheckBox1.ContainerCheckedColor = Color.FromArgb(252, 255, 224);
            siticoneCheckBox1.ContainerCheckedHoverColor = Color.FromArgb(25, 56, 128, 255);
            siticoneCheckBox1.ContainerCheckedPressedColor = Color.FromArgb(186, 205, 146);
            siticoneCheckBox1.ContainerHoverBackColor = Color.FromArgb(25, 0, 0, 0);
            siticoneCheckBox1.ContainerPadding = 8;
            siticoneCheckBox1.ContainerPressedBackColor = Color.FromArgb(30, 0, 0, 0);
            siticoneCheckBox1.ContainerTopLeftRadius = 8;
            siticoneCheckBox1.ContainerTopRightRadius = 8;
            siticoneCheckBox1.EnableRippleEffect = true;
            siticoneCheckBox1.FocusBorderWidth = 2;
            siticoneCheckBox1.FocusColor = Color.FromArgb(252, 255, 224);
            siticoneCheckBox1.Font = new Font("Segoe UI", 9F);
            siticoneCheckBox1.ForeColor = Color.FromArgb(117, 164, 127);
            siticoneCheckBox1.HoverBackColor = Color.Gainsboro;
            siticoneCheckBox1.IndeterminateBorderColor = Color.FromArgb(160, 160, 160);
            siticoneCheckBox1.IndeterminateColor = Color.FromArgb(180, 180, 180);
            siticoneCheckBox1.IsContained = false;
            siticoneCheckBox1.IsReadOnly = false;
            siticoneCheckBox1.Location = new Point(437, 653);
            siticoneCheckBox1.MinimumSize = new Size(178, 24);
            siticoneCheckBox1.Name = "siticoneCheckBox1";
            siticoneCheckBox1.PressedBackColor = Color.DarkGray;
            siticoneCheckBox1.ShowFocusCue = false;
            siticoneCheckBox1.Size = new Size(222, 30);
            siticoneCheckBox1.Style = SiticoneNetCoreUI.CheckBoxStyle.Classic;
            siticoneCheckBox1.SwitchCheckedTrackColor = Color.FromArgb(100, 56, 128, 255);
            siticoneCheckBox1.SwitchTrackColor = Color.FromArgb(200, 200, 200);
            siticoneCheckBox1.TabIndex = 14;
            siticoneCheckBox1.Text = "Show password";
            siticoneCheckBox1.TopLeftRadius = 3;
            siticoneCheckBox1.TopRightRadius = 3;
            siticoneCheckBox1.UncheckedBackColor = Color.FromArgb(250, 250, 250);
            siticoneCheckBox1.Click += siticoneCheckBox1_Click;
            // 
            // txtEmail
            // 
            txtEmail.AccessibleDescription = "A customizable text input field.";
            txtEmail.AccessibleName = "Text Box";
            txtEmail.AccessibleRole = AccessibleRole.Text;
            txtEmail.BackColor = Color.Transparent;
            txtEmail.BlinkCount = 3;
            txtEmail.BlinkShadow = false;
            txtEmail.BorderColor1 = Color.LightSlateGray;
            txtEmail.BorderColor2 = Color.LightSlateGray;
            txtEmail.BorderFocusColor1 = Color.FromArgb(77, 77, 255);
            txtEmail.BorderFocusColor2 = Color.FromArgb(77, 77, 255);
            txtEmail.CanShake = true;
            txtEmail.ContinuousBlink = false;
            txtEmail.CursorBlinkRate = 500;
            txtEmail.CursorColor = Color.Black;
            txtEmail.CursorHeight = 26;
            txtEmail.CursorOffset = 0;
            txtEmail.CursorStyle = SiticoneNetCoreUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            txtEmail.CursorWidth = 1;
            txtEmail.DisabledBackColor = Color.WhiteSmoke;
            txtEmail.DisabledBorderColor = Color.LightGray;
            txtEmail.DisabledTextColor = Color.Gray;
            txtEmail.EnableDropShadow = false;
            txtEmail.FillColor1 = Color.White;
            txtEmail.FillColor2 = Color.White;
            txtEmail.Font = new Font("Inter", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.ForeColor = Color.DimGray;
            txtEmail.HoverBorderColor1 = Color.Gray;
            txtEmail.HoverBorderColor2 = Color.Gray;
            txtEmail.IsEnabled = true;
            txtEmail.Location = new Point(437, 311);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderColor = Color.Gray;
            txtEmail.PlaceholderText = "Enter text here...";
            txtEmail.ReadOnlyBorderColor1 = Color.LightGray;
            txtEmail.ReadOnlyBorderColor2 = Color.LightGray;
            txtEmail.ReadOnlyFillColor1 = Color.WhiteSmoke;
            txtEmail.ReadOnlyFillColor2 = Color.WhiteSmoke;
            txtEmail.ReadOnlyPlaceholderColor = Color.DarkGray;
            txtEmail.SelectionBackColor = Color.FromArgb(77, 77, 255);
            txtEmail.ShadowAnimationDuration = 1;
            txtEmail.ShadowBlur = 10;
            txtEmail.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            txtEmail.ShowBorder = false;
            txtEmail.Size = new Size(537, 63);
            txtEmail.SolidBorderColor = Color.LightSlateGray;
            txtEmail.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            txtEmail.SolidBorderHoverColor = Color.Gray;
            txtEmail.SolidFillColor = Color.White;
            txtEmail.TabIndex = 16;
            txtEmail.TextPadding = new Padding(16, 0, 6, 0);
            txtEmail.ValidationErrorMessage = "Invalid input.";
            txtEmail.ValidationFunction = null;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(233, 240, 201);
            label5.Font = new Font("Inter", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(117, 164, 127);
            label5.Location = new Point(428, 268);
            label5.Name = "label5";
            label5.Size = new Size(92, 40);
            label5.TabIndex = 15;
            label5.Text = "Email";
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 255, 224);
            ClientSize = new Size(1422, 977);
            Controls.Add(txtEmail);
            Controls.Add(label5);
            Controls.Add(siticoneCheckBox1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(siticoneButton2);
            Controls.Add(label4);
            Controls.Add(btnSignUp);
            Controls.Add(tbPasswordConfirm);
            Controls.Add(label3);
            Controls.Add(tbPassword);
            Controls.Add(label2);
            Controls.Add(tbUsername);
            Controls.Add(label1);
            Controls.Add(email);
            Controls.Add(Rectangle);
            Name = "SignUp";
            Text = "SignUp";
            ((System.ComponentModel.ISupportInitialize)Rectangle).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Rectangle;
        private Label email;
        private Label label1;
        private SiticoneNetCoreUI.SiticoneTextBox tbUsername;
        private Label label2;
        private SiticoneNetCoreUI.SiticoneTextBox tbPassword;
        private Label label3;
        private SiticoneNetCoreUI.SiticoneTextBox tbPasswordConfirm;
        private SiticoneNetCoreUI.SiticoneButton btnSignUp;
        private Label label4;
        private SiticoneNetCoreUI.SiticoneButton siticoneButton2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private SiticoneNetCoreUI.SiticoneCheckBox siticoneCheckBox1;
        private SiticoneNetCoreUI.SiticoneTextBox txtEmail;
        private Label label5;
    }
}