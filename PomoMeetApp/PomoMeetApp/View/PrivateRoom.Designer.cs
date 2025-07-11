namespace PomoMeetApp.View
{
    partial class PrivateRoom
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
            btn_TogglePassword = new Button();
            sbtn_JoinRoom = new SiticoneNetCoreUI.SiticoneButton();
            stb_Password = new SiticoneNetCoreUI.SiticoneTextBox();
            lb_Password = new Label();
            siticonePanel1 = new SiticoneNetCoreUI.SiticonePanel();
            label1 = new Label();
            siticonePanel1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_TogglePassword
            // 
            btn_TogglePassword.BackColor = Color.White;
            btn_TogglePassword.BackgroundImage = Properties.Resources.eye_close;
            btn_TogglePassword.FlatAppearance.BorderSize = 0;
            btn_TogglePassword.FlatStyle = FlatStyle.Flat;
            btn_TogglePassword.Location = new Point(691, 187);
            btn_TogglePassword.Name = "btn_TogglePassword";
            btn_TogglePassword.Size = new Size(27, 29);
            btn_TogglePassword.TabIndex = 18;
            btn_TogglePassword.UseVisualStyleBackColor = false;
            btn_TogglePassword.Visible = false;
            // 
            // sbtn_JoinRoom
            // 
            sbtn_JoinRoom.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            sbtn_JoinRoom.AccessibleName = "Tham gia";
            sbtn_JoinRoom.AutoSizeBasedOnText = false;
            sbtn_JoinRoom.BackColor = Color.Transparent;
            sbtn_JoinRoom.BadgeBackColor = Color.Red;
            sbtn_JoinRoom.BadgeFont = new Font("Inter", 8F, FontStyle.Bold);
            sbtn_JoinRoom.BadgeValue = 0;
            sbtn_JoinRoom.BadgeValueForeColor = Color.White;
            sbtn_JoinRoom.BorderColor = Color.Transparent;
            sbtn_JoinRoom.BorderWidth = 2;
            sbtn_JoinRoom.ButtonBackColor = Color.White;
            sbtn_JoinRoom.ButtonImage = null;
            sbtn_JoinRoom.CanBeep = true;
            sbtn_JoinRoom.CanGlow = false;
            sbtn_JoinRoom.CanShake = true;
            sbtn_JoinRoom.ContextMenuStripEx = null;
            sbtn_JoinRoom.CornerRadiusBottomLeft = 12;
            sbtn_JoinRoom.CornerRadiusBottomRight = 12;
            sbtn_JoinRoom.CornerRadiusTopLeft = 12;
            sbtn_JoinRoom.CornerRadiusTopRight = 12;
            sbtn_JoinRoom.CustomCursor = Cursors.Default;
            sbtn_JoinRoom.DisabledTextColor = Color.White;
            sbtn_JoinRoom.EnableLongPress = false;
            sbtn_JoinRoom.EnablePressAnimation = true;
            sbtn_JoinRoom.EnableRippleEffect = true;
            sbtn_JoinRoom.EnableShadow = false;
            sbtn_JoinRoom.EnableTextWrapping = false;
            sbtn_JoinRoom.Font = new Font("Inter ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sbtn_JoinRoom.GlowColor = Color.FromArgb(117, 164, 127);
            sbtn_JoinRoom.GlowIntensity = 100;
            sbtn_JoinRoom.GlowRadius = 20F;
            sbtn_JoinRoom.GradientBackground = true;
            sbtn_JoinRoom.GradientColor = Color.FromArgb(117, 164, 127);
            sbtn_JoinRoom.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            sbtn_JoinRoom.HintText = null;
            sbtn_JoinRoom.HoverBackColor = Color.Transparent;
            sbtn_JoinRoom.HoverFontStyle = FontStyle.Regular;
            sbtn_JoinRoom.HoverTextColor = Color.White;
            sbtn_JoinRoom.HoverTransitionDuration = 250;
            sbtn_JoinRoom.ImageAlign = ContentAlignment.MiddleRight;
            sbtn_JoinRoom.ImagePadding = 5;
            sbtn_JoinRoom.ImageSize = new Size(50, 50);
            sbtn_JoinRoom.IsRadial = false;
            sbtn_JoinRoom.IsReadOnly = false;
            sbtn_JoinRoom.IsToggleButton = false;
            sbtn_JoinRoom.IsToggled = false;
            sbtn_JoinRoom.Location = new Point(309, 255);
            sbtn_JoinRoom.LongPressDurationMS = 1000;
            sbtn_JoinRoom.Name = "sbtn_JoinRoom";
            sbtn_JoinRoom.NormalFontStyle = FontStyle.Regular;
            sbtn_JoinRoom.Padding = new Padding(20, 0, 0, 0);
            sbtn_JoinRoom.ParticleColor = Color.FromArgb(200, 200, 200);
            sbtn_JoinRoom.ParticleCount = 15;
            sbtn_JoinRoom.PressAnimationScale = 0.97F;
            sbtn_JoinRoom.PressedBackColor = Color.Transparent;
            sbtn_JoinRoom.PressedFontStyle = FontStyle.Regular;
            sbtn_JoinRoom.PressTransitionDuration = 150;
            sbtn_JoinRoom.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            sbtn_JoinRoom.RippleColor = Color.FromArgb(255, 255, 255);
            sbtn_JoinRoom.RippleOpacity = 0.3F;
            sbtn_JoinRoom.RippleRadiusMultiplier = 0.6F;
            sbtn_JoinRoom.ShadowBlur = 5;
            sbtn_JoinRoom.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            sbtn_JoinRoom.ShadowOffset = new Point(2, 2);
            sbtn_JoinRoom.ShakeDuration = 500;
            sbtn_JoinRoom.ShakeIntensity = 5;
            sbtn_JoinRoom.Size = new Size(180, 57);
            sbtn_JoinRoom.TabIndex = 17;
            sbtn_JoinRoom.Text = "Tham gia";
            sbtn_JoinRoom.TextAlign = ContentAlignment.MiddleCenter;
            sbtn_JoinRoom.TextColor = Color.White;
            sbtn_JoinRoom.TooltipText = null;
            sbtn_JoinRoom.UseAdvancedRendering = true;
            sbtn_JoinRoom.UseParticles = false;
            sbtn_JoinRoom.Click += sbtn_JoinRoom_Click;
            // 
            // stb_Password
            // 
            stb_Password.AccessibleDescription = "A customizable text input field.";
            stb_Password.AccessibleName = "Text Box";
            stb_Password.AccessibleRole = AccessibleRole.Text;
            stb_Password.BackColor = Color.Transparent;
            stb_Password.BlinkCount = 3;
            stb_Password.BlinkShadow = false;
            stb_Password.BorderColor1 = Color.LightSlateGray;
            stb_Password.BorderColor2 = Color.LightSlateGray;
            stb_Password.BorderFocusColor1 = Color.FromArgb(77, 77, 255);
            stb_Password.BorderFocusColor2 = Color.FromArgb(77, 77, 255);
            stb_Password.CanShake = true;
            stb_Password.ContinuousBlink = false;
            stb_Password.CursorBlinkRate = 500;
            stb_Password.CursorColor = Color.Black;
            stb_Password.CursorHeight = 26;
            stb_Password.CursorOffset = 0;
            stb_Password.CursorStyle = SiticoneNetCoreUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            stb_Password.CursorWidth = 1;
            stb_Password.DisabledBackColor = Color.WhiteSmoke;
            stb_Password.DisabledBorderColor = Color.LightGray;
            stb_Password.DisabledTextColor = Color.Gray;
            stb_Password.EnableDropShadow = false;
            stb_Password.FillColor1 = Color.White;
            stb_Password.FillColor2 = Color.White;
            stb_Password.Font = new Font("Inter", 10.2F);
            stb_Password.ForeColor = Color.DimGray;
            stb_Password.HoverBorderColor1 = Color.Gray;
            stb_Password.HoverBorderColor2 = Color.Gray;
            stb_Password.IsEnabled = true;
            stb_Password.Location = new Point(65, 178);
            stb_Password.Name = "stb_Password";
            stb_Password.PlaceholderColor = Color.Gray;
            stb_Password.PlaceholderText = "abc12345-1223345";
            stb_Password.ReadOnlyBorderColor1 = Color.LightGray;
            stb_Password.ReadOnlyBorderColor2 = Color.LightGray;
            stb_Password.ReadOnlyFillColor1 = Color.WhiteSmoke;
            stb_Password.ReadOnlyFillColor2 = Color.WhiteSmoke;
            stb_Password.ReadOnlyPlaceholderColor = Color.DarkGray;
            stb_Password.SelectionBackColor = Color.FromArgb(77, 77, 255);
            stb_Password.ShadowAnimationDuration = 1;
            stb_Password.ShadowBlur = 10;
            stb_Password.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            stb_Password.Size = new Size(665, 48);
            stb_Password.SolidBorderColor = Color.LightSlateGray;
            stb_Password.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            stb_Password.SolidBorderHoverColor = Color.Gray;
            stb_Password.SolidFillColor = Color.White;
            stb_Password.TabIndex = 16;
            stb_Password.TextPadding = new Padding(16, 0, 6, 0);
            stb_Password.UseSystemPasswordChar = true;
            stb_Password.ValidationErrorMessage = "Invalid input.";
            stb_Password.ValidationFunction = null;
            // 
            // lb_Password
            // 
            lb_Password.AutoSize = true;
            lb_Password.Font = new Font("Inter", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_Password.Location = new Point(65, 141);
            lb_Password.Name = "lb_Password";
            lb_Password.Size = new Size(159, 28);
            lb_Password.TabIndex = 15;
            lb_Password.Text = "Nhập mật khẩu";
            // 
            // siticonePanel1
            // 
            siticonePanel1.AcrylicTintColor = Color.Transparent;
            siticonePanel1.BackColor = Color.FromArgb(117, 164, 127);
            siticonePanel1.BorderAlignment = System.Drawing.Drawing2D.PenAlignment.Center;
            siticonePanel1.BorderDashPattern = null;
            siticonePanel1.BorderGradientEndColor = Color.Purple;
            siticonePanel1.BorderGradientStartColor = Color.Blue;
            siticonePanel1.BorderThickness = 2F;
            siticonePanel1.Controls.Add(label1);
            siticonePanel1.CornerRadiusBottomLeft = 0F;
            siticonePanel1.CornerRadiusBottomRight = 0F;
            siticonePanel1.CornerRadiusTopLeft = 10F;
            siticonePanel1.CornerRadiusTopRight = 10F;
            siticonePanel1.EnableAcrylicEffect = false;
            siticonePanel1.EnableMicaEffect = false;
            siticonePanel1.EnableRippleEffect = false;
            siticonePanel1.FillColor = Color.FromArgb(117, 164, 127);
            siticonePanel1.GradientColors = new Color[]
    {
    Color.White,
    Color.LightGray,
    Color.Gray
    };
            siticonePanel1.GradientPositions = new float[]
    {
    0F,
    0.5F,
    1F
    };
            siticonePanel1.Location = new Point(2, 2);
            siticonePanel1.Name = "siticonePanel1";
            siticonePanel1.PatternStyle = System.Drawing.Drawing2D.HatchStyle.Max;
            siticonePanel1.RippleAlpha = 50;
            siticonePanel1.RippleAlphaDecrement = 3;
            siticonePanel1.RippleColor = Color.FromArgb(50, 255, 255, 255);
            siticonePanel1.RippleMaxSize = 600F;
            siticonePanel1.RippleSpeed = 15F;
            siticonePanel1.ShowBorder = true;
            siticonePanel1.Size = new Size(797, 102);
            siticonePanel1.TabIndex = 12;
            siticonePanel1.TabStop = true;
            siticonePanel1.UseBorderGradient = false;
            siticonePanel1.UseMultiGradient = false;
            siticonePanel1.UsePatternTexture = false;
            siticonePanel1.UseRadialGradient = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Inter", 22.2F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(246, 28);
            label1.Name = "label1";
            label1.Size = new Size(313, 53);
            label1.TabIndex = 0;
            label1.Text = "Tham gia phòng";
            // 
            // PrivateRoom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 339);
            Controls.Add(btn_TogglePassword);
            Controls.Add(sbtn_JoinRoom);
            Controls.Add(stb_Password);
            Controls.Add(lb_Password);
            Controls.Add(siticonePanel1);
            MaximumSize = new Size(818, 386);
            Name = "PrivateRoom";
            Text = "PrivateRoom";
            siticonePanel1.ResumeLayout(false);
            siticonePanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_TogglePassword;
        private SiticoneNetCoreUI.SiticoneButton sbtn_JoinRoom;
        private SiticoneNetCoreUI.SiticoneTextBox stb_Password;
        private Label lb_Password;
        private SiticoneNetCoreUI.SiticonePanel siticonePanel1;
        private Label label1;
    }
}