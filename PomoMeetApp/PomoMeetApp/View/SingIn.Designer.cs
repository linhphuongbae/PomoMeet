namespace PomoMeetApp.View
{
    partial class SingIn
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
            label1 = new Label();
            email = new Label();
            tbUsername = new SiticoneNetCoreUI.SiticoneTextBox();
            label2 = new Label();
            tbPassword = new SiticoneNetCoreUI.SiticoneTextBox();
            btnSignInGG = new SiticoneNetCoreUI.SiticoneButton();
            label4 = new Label();
            BackToRegs = new SiticoneNetCoreUI.SiticoneButton();
            linkLabel1 = new LinkLabel();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox1 = new PictureBox();
            btnLogIn = new SiticoneNetCoreUI.SiticoneButton();
            ((System.ComponentModel.ISupportInitialize)Rectangle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Rectangle
            // 
            Rectangle.Image = Properties.Resources.Rectangle;
            Rectangle.Location = new Point(389, 121);
            Rectangle.Name = "Rectangle";
            Rectangle.Size = new Size(645, 735);
            Rectangle.TabIndex = 1;
            Rectangle.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(233, 240, 201);
            label1.Font = new Font("Inter", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(117, 164, 127);
            label1.Location = new Point(614, 157);
            label1.Name = "label1";
            label1.Size = new Size(217, 53);
            label1.TabIndex = 3;
            label1.Text = "Đăng nhập";
            // 
            // email
            // 
            email.AutoSize = true;
            email.BackColor = Color.FromArgb(233, 240, 201);
            email.Font = new Font("Inter", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            email.ForeColor = Color.FromArgb(117, 164, 127);
            email.Location = new Point(428, 233);
            email.Name = "email";
            email.Size = new Size(157, 40);
            email.TabIndex = 4;
            email.Text = "Username";
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
            tbUsername.Location = new Point(438, 276);
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
            tbUsername.TabIndex = 6;
            tbUsername.TextPadding = new Padding(16, 0, 6, 0);
            tbUsername.ValidationErrorMessage = "Invalid input.";
            tbUsername.ValidationFunction = null;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(233, 240, 201);
            label2.Font = new Font("Inter", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(117, 164, 127);
            label2.Location = new Point(428, 377);
            label2.Name = "label2";
            label2.Size = new Size(142, 40);
            label2.TabIndex = 7;
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
            tbPassword.ImeMode = ImeMode.Katakana;
            tbPassword.IsEnabled = true;
            tbPassword.Location = new Point(437, 420);
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
            tbPassword.TabIndex = 8;
            tbPassword.TextPadding = new Padding(16, 0, 6, 0);
            tbPassword.UseSystemPasswordChar = true;
            tbPassword.ValidationErrorMessage = "Invalid input.";
            tbPassword.ValidationFunction = null;
            // 
            // btnSignInGG
            // 
            btnSignInGG.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnSignInGG.AccessibleName = "Sign In With Google";
            btnSignInGG.AutoSizeBasedOnText = false;
            btnSignInGG.BackColor = Color.Transparent;
            btnSignInGG.BadgeBackColor = Color.Red;
            btnSignInGG.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnSignInGG.BadgeValue = 0;
            btnSignInGG.BadgeValueForeColor = Color.White;
            btnSignInGG.BorderColor = Color.FromArgb(117, 164, 127);
            btnSignInGG.BorderWidth = 2;
            btnSignInGG.ButtonBackColor = Color.White;
            btnSignInGG.ButtonImage = Properties.Resources.Google;
            btnSignInGG.CanBeep = true;
            btnSignInGG.CanGlow = false;
            btnSignInGG.CanShake = true;
            btnSignInGG.ContextMenuStripEx = null;
            btnSignInGG.CornerRadiusBottomLeft = 0;
            btnSignInGG.CornerRadiusBottomRight = 0;
            btnSignInGG.CornerRadiusTopLeft = 0;
            btnSignInGG.CornerRadiusTopRight = 0;
            btnSignInGG.CustomCursor = Cursors.Default;
            btnSignInGG.DisabledTextColor = Color.Black;
            btnSignInGG.EnableLongPress = false;
            btnSignInGG.EnablePressAnimation = true;
            btnSignInGG.EnableRippleEffect = true;
            btnSignInGG.EnableShadow = false;
            btnSignInGG.EnableTextWrapping = false;
            btnSignInGG.Font = new Font("Inter", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSignInGG.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnSignInGG.GlowIntensity = 100;
            btnSignInGG.GlowRadius = 20F;
            btnSignInGG.GradientBackground = false;
            btnSignInGG.GradientColor = Color.White;
            btnSignInGG.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnSignInGG.HintText = null;
            btnSignInGG.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnSignInGG.HoverFontStyle = FontStyle.Regular;
            btnSignInGG.HoverTextColor = Color.White;
            btnSignInGG.HoverTransitionDuration = 250;
            btnSignInGG.ImageAlign = ContentAlignment.MiddleLeft;
            btnSignInGG.ImagePadding = 10;
            btnSignInGG.ImageSize = new Size(32, 32);
            btnSignInGG.IsRadial = false;
            btnSignInGG.IsReadOnly = false;
            btnSignInGG.IsToggleButton = false;
            btnSignInGG.IsToggled = false;
            btnSignInGG.Location = new Point(438, 682);
            btnSignInGG.LongPressDurationMS = 1000;
            btnSignInGG.Name = "btnSignInGG";
            btnSignInGG.NormalFontStyle = FontStyle.Regular;
            btnSignInGG.ParticleColor = Color.FromArgb(200, 200, 200);
            btnSignInGG.ParticleCount = 15;
            btnSignInGG.PressAnimationScale = 0.97F;
            btnSignInGG.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnSignInGG.PressedFontStyle = FontStyle.Regular;
            btnSignInGG.PressTransitionDuration = 150;
            btnSignInGG.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnSignInGG.RippleColor = Color.FromArgb(255, 255, 255);
            btnSignInGG.RippleOpacity = 0.3F;
            btnSignInGG.RippleRadiusMultiplier = 0.6F;
            btnSignInGG.ShadowBlur = 5;
            btnSignInGG.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnSignInGG.ShadowOffset = new Point(2, 2);
            btnSignInGG.ShakeDuration = 500;
            btnSignInGG.ShakeIntensity = 5;
            btnSignInGG.Size = new Size(537, 47);
            btnSignInGG.TabIndex = 10;
            btnSignInGG.Text = "Sign In With Google";
            btnSignInGG.TextAlign = ContentAlignment.MiddleCenter;
            btnSignInGG.TextColor = Color.Black;
            btnSignInGG.TooltipText = null;
            btnSignInGG.UseAdvancedRendering = true;
            btnSignInGG.UseParticles = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(233, 240, 201);
            label4.Font = new Font("Inter", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(582, 764);
            label4.Name = "label4";
            label4.Size = new Size(180, 22);
            label4.TabIndex = 11;
            label4.Text = "Bạn chưa có tải khoản?";
            // 
            // BackToRegs
            // 
            BackToRegs.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            BackToRegs.AccessibleName = "Đăng ký";
            BackToRegs.AutoSizeBasedOnText = false;
            BackToRegs.BackColor = Color.Transparent;
            BackToRegs.BadgeBackColor = Color.Red;
            BackToRegs.BadgeFont = new Font("Inter", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BackToRegs.BadgeValue = 0;
            BackToRegs.BadgeValueForeColor = Color.White;
            BackToRegs.BorderColor = Color.FromArgb(117, 164, 127);
            BackToRegs.BorderWidth = 2;
            BackToRegs.ButtonBackColor = Color.White;
            BackToRegs.ButtonImage = null;
            BackToRegs.CanBeep = true;
            BackToRegs.CanGlow = false;
            BackToRegs.CanShake = true;
            BackToRegs.ContextMenuStripEx = null;
            BackToRegs.CornerRadiusBottomLeft = 0;
            BackToRegs.CornerRadiusBottomRight = 0;
            BackToRegs.CornerRadiusTopLeft = 0;
            BackToRegs.CornerRadiusTopRight = 0;
            BackToRegs.CustomCursor = Cursors.Default;
            BackToRegs.DisabledTextColor = Color.FromArgb(117, 164, 127);
            BackToRegs.EnableLongPress = false;
            BackToRegs.EnablePressAnimation = true;
            BackToRegs.EnableRippleEffect = true;
            BackToRegs.EnableShadow = false;
            BackToRegs.EnableTextWrapping = false;
            BackToRegs.Font = new Font("Inter", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BackToRegs.ForeColor = Color.FromArgb(117, 164, 127);
            BackToRegs.GlowColor = Color.FromArgb(100, 255, 255, 255);
            BackToRegs.GlowIntensity = 100;
            BackToRegs.GlowRadius = 20F;
            BackToRegs.GradientBackground = false;
            BackToRegs.GradientColor = Color.FromArgb(114, 168, 255);
            BackToRegs.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            BackToRegs.HintText = null;
            BackToRegs.HoverBackColor = Color.FromArgb(114, 168, 255);
            BackToRegs.HoverFontStyle = FontStyle.Regular;
            BackToRegs.HoverTextColor = Color.White;
            BackToRegs.HoverTransitionDuration = 250;
            BackToRegs.ImageAlign = ContentAlignment.MiddleLeft;
            BackToRegs.ImagePadding = 5;
            BackToRegs.ImageSize = new Size(16, 16);
            BackToRegs.IsRadial = false;
            BackToRegs.IsReadOnly = false;
            BackToRegs.IsToggleButton = false;
            BackToRegs.IsToggled = false;
            BackToRegs.Location = new Point(768, 756);
            BackToRegs.LongPressDurationMS = 1000;
            BackToRegs.Name = "BackToRegs";
            BackToRegs.NormalFontStyle = FontStyle.Regular;
            BackToRegs.ParticleColor = Color.FromArgb(200, 200, 200);
            BackToRegs.ParticleCount = 15;
            BackToRegs.PressAnimationScale = 0.97F;
            BackToRegs.PressedBackColor = Color.FromArgb(74, 128, 235);
            BackToRegs.PressedFontStyle = FontStyle.Regular;
            BackToRegs.PressTransitionDuration = 150;
            BackToRegs.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            BackToRegs.RippleColor = Color.FromArgb(255, 255, 255);
            BackToRegs.RippleOpacity = 0.3F;
            BackToRegs.RippleRadiusMultiplier = 0.6F;
            BackToRegs.ShadowBlur = 5;
            BackToRegs.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            BackToRegs.ShadowOffset = new Point(2, 2);
            BackToRegs.ShakeDuration = 500;
            BackToRegs.ShakeIntensity = 5;
            BackToRegs.Size = new Size(87, 30);
            BackToRegs.TabIndex = 12;
            BackToRegs.Text = "Đăng ký";
            BackToRegs.TextAlign = ContentAlignment.MiddleCenter;
            BackToRegs.TextColor = Color.FromArgb(117, 164, 127);
            BackToRegs.TooltipText = null;
            BackToRegs.UseAdvancedRendering = true;
            BackToRegs.UseParticles = false;
            BackToRegs.Click += BackToRegs_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.FromArgb(117, 164, 127);
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = Color.FromArgb(233, 240, 201);
            linkLabel1.DisabledLinkColor = Color.FromArgb(117, 164, 127);
            linkLabel1.Font = new Font("Inter", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkLabel1.LinkColor = Color.FromArgb(117, 164, 127);
            linkLabel1.Location = new Point(828, 500);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(147, 24);
            linkLabel1.TabIndex = 15;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Quên mật khẩu?";
            linkLabel1.VisitedLinkColor = Color.FromArgb(117, 164, 127);
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Decoration_1;
            pictureBox2.Location = new Point(1118, -2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(305, 228);
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.SmallLogo;
            pictureBox3.Location = new Point(12, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(90, 76);
            pictureBox3.TabIndex = 17;
            pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Ellipse;
            pictureBox1.Location = new Point(-2, 664);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(299, 313);
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            // 
            // btnLogIn
            // 
            btnLogIn.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnLogIn.AccessibleName = "Đăng nhập";
            btnLogIn.AutoSizeBasedOnText = false;
            btnLogIn.BackColor = Color.Transparent;
            btnLogIn.BadgeBackColor = Color.Red;
            btnLogIn.BadgeFont = new Font("Inter", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogIn.BadgeValue = 0;
            btnLogIn.BadgeValueForeColor = Color.White;
            btnLogIn.BorderColor = Color.FromArgb(117, 164, 127);
            btnLogIn.BorderWidth = 2;
            btnLogIn.ButtonBackColor = Color.White;
            btnLogIn.ButtonImage = null;
            btnLogIn.CanBeep = true;
            btnLogIn.CanGlow = false;
            btnLogIn.CanShake = true;
            btnLogIn.ContextMenuStripEx = null;
            btnLogIn.CornerRadiusBottomLeft = 0;
            btnLogIn.CornerRadiusBottomRight = 0;
            btnLogIn.CornerRadiusTopLeft = 0;
            btnLogIn.CornerRadiusTopRight = 0;
            btnLogIn.CustomCursor = Cursors.Default;
            btnLogIn.DisabledTextColor = Color.FromArgb(117, 164, 127);
            btnLogIn.EnableLongPress = false;
            btnLogIn.EnablePressAnimation = true;
            btnLogIn.EnableRippleEffect = true;
            btnLogIn.EnableShadow = false;
            btnLogIn.EnableTextWrapping = false;
            btnLogIn.Font = new Font("Inter", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogIn.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnLogIn.GlowIntensity = 100;
            btnLogIn.GlowRadius = 20F;
            btnLogIn.GradientBackground = false;
            btnLogIn.GradientColor = Color.White;
            btnLogIn.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnLogIn.HintText = null;
            btnLogIn.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnLogIn.HoverFontStyle = FontStyle.Regular;
            btnLogIn.HoverTextColor = Color.White;
            btnLogIn.HoverTransitionDuration = 250;
            btnLogIn.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogIn.ImagePadding = 5;
            btnLogIn.ImageSize = new Size(16, 16);
            btnLogIn.IsRadial = false;
            btnLogIn.IsReadOnly = false;
            btnLogIn.IsToggleButton = false;
            btnLogIn.IsToggled = false;
            btnLogIn.Location = new Point(438, 602);
            btnLogIn.LongPressDurationMS = 1000;
            btnLogIn.Name = "btnLogIn";
            btnLogIn.NormalFontStyle = FontStyle.Regular;
            btnLogIn.ParticleColor = Color.FromArgb(200, 200, 200);
            btnLogIn.ParticleCount = 15;
            btnLogIn.PressAnimationScale = 0.97F;
            btnLogIn.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnLogIn.PressedFontStyle = FontStyle.Regular;
            btnLogIn.PressTransitionDuration = 150;
            btnLogIn.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnLogIn.RippleColor = Color.FromArgb(255, 255, 255);
            btnLogIn.RippleOpacity = 0.3F;
            btnLogIn.RippleRadiusMultiplier = 0.6F;
            btnLogIn.ShadowBlur = 5;
            btnLogIn.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnLogIn.ShadowOffset = new Point(2, 2);
            btnLogIn.ShakeDuration = 500;
            btnLogIn.ShakeIntensity = 5;
            btnLogIn.Size = new Size(537, 47);
            btnLogIn.TabIndex = 19;
            btnLogIn.Text = "Đăng nhập";
            btnLogIn.TextAlign = ContentAlignment.MiddleCenter;
            btnLogIn.TextColor = Color.FromArgb(117, 164, 127);
            btnLogIn.TooltipText = null;
            btnLogIn.UseAdvancedRendering = true;
            btnLogIn.UseParticles = false;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // SingIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 255, 224);
            ClientSize = new Size(1422, 977);
            Controls.Add(btnLogIn);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(linkLabel1);
            Controls.Add(BackToRegs);
            Controls.Add(label4);
            Controls.Add(btnSignInGG);
            Controls.Add(tbPassword);
            Controls.Add(label2);
            Controls.Add(tbUsername);
            Controls.Add(email);
            Controls.Add(label1);
            Controls.Add(Rectangle);
            Name = "SingIn";
            Text = "SingIn";
            ((System.ComponentModel.ISupportInitialize)Rectangle).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Rectangle;
        private Label label1;
        private Label email;
        private SiticoneNetCoreUI.SiticoneTextBox tbUsername;
        private Label label2;
        private SiticoneNetCoreUI.SiticoneTextBox tbPassword;
        private SiticoneNetCoreUI.SiticoneButton btnSignInGG;
        private Label label4;
        private SiticoneNetCoreUI.SiticoneButton BackToRegs;
        private LinkLabel linkLabel1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
        private SiticoneNetCoreUI.SiticoneButton btnLogIn;
    }
}