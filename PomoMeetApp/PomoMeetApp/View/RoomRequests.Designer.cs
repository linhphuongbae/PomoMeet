namespace PomoMeetApp.View
{
    partial class RoomRequests
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            tbMamoi = new SiticoneNetCoreUI.SiticoneTextBox();
            btCopy = new SiticoneNetCoreUI.SiticoneCopyButton();
            siticonePanel1 = new SiticoneNetCoreUI.SiticonePanel();
            label3 = new Label();
            siticoneTextBox1 = new SiticoneNetCoreUI.SiticoneTextBox();
            siticoneButton1 = new SiticoneNetCoreUI.SiticoneButton();
            siticonePanel2 = new SiticoneNetCoreUI.SiticonePanel();
            btnSendInvitation = new SiticoneNetCoreUI.SiticoneButton();
            siticonePanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(117, 164, 127);
            label1.Font = new Font("Inter", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(209, 19);
            label1.Name = "label1";
            label1.Size = new Size(384, 53);
            label1.TabIndex = 2;
            label1.Text = "Mời bạn bè tham gia";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(117, 164, 127);
            label2.Font = new Font("Inter", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(246, 83);
            label2.Name = "label2";
            label2.Size = new Size(315, 24);
            label2.TabIndex = 3;
            label2.Text = "Chia sẻ mã phòng để bạn bè tham gia";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbMamoi
            // 
            tbMamoi.AccessibleDescription = "A customizable text input field.";
            tbMamoi.AccessibleName = "Text Box";
            tbMamoi.AccessibleRole = AccessibleRole.Text;
            tbMamoi.BackColor = Color.Transparent;
            tbMamoi.BackgroundImage = Properties.Resources.Rectangle_4;
            tbMamoi.BlinkCount = 3;
            tbMamoi.BlinkShadow = false;
            tbMamoi.BorderColor1 = Color.Transparent;
            tbMamoi.BorderColor2 = Color.LightSlateGray;
            tbMamoi.BorderFocusColor1 = Color.FromArgb(77, 77, 255);
            tbMamoi.BorderFocusColor2 = Color.FromArgb(77, 77, 255);
            tbMamoi.CanShake = true;
            tbMamoi.ContinuousBlink = false;
            tbMamoi.CornerRadiusBottomLeft = 15;
            tbMamoi.CornerRadiusBottomRight = 15;
            tbMamoi.CornerRadiusTopLeft = 15;
            tbMamoi.CornerRadiusTopRight = 15;
            tbMamoi.CursorBlinkRate = 500;
            tbMamoi.CursorColor = Color.Black;
            tbMamoi.CursorHeight = 26;
            tbMamoi.CursorOffset = 0;
            tbMamoi.CursorStyle = SiticoneNetCoreUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            tbMamoi.CursorWidth = 1;
            tbMamoi.DisabledBackColor = Color.Transparent;
            tbMamoi.DisabledBorderColor = Color.LightGray;
            tbMamoi.DisabledTextColor = Color.Gray;
            tbMamoi.EnableDropShadow = false;
            tbMamoi.FillColor1 = Color.Transparent;
            tbMamoi.FillColor2 = Color.Transparent;
            tbMamoi.Font = new Font("Inter", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbMamoi.ForeColor = Color.DimGray;
            tbMamoi.HoverBorderColor1 = Color.Transparent;
            tbMamoi.HoverBorderColor2 = Color.Transparent;
            tbMamoi.IsEnabled = true;
            tbMamoi.Location = new Point(255, 121);
            tbMamoi.Name = "tbMamoi";
            tbMamoi.PlaceholderColor = Color.Gray;
            tbMamoi.PlaceholderText = "ABC123";
            tbMamoi.ReadOnlyBorderColor1 = Color.LightGray;
            tbMamoi.ReadOnlyBorderColor2 = Color.LightGray;
            tbMamoi.ReadOnlyFillColor1 = Color.WhiteSmoke;
            tbMamoi.ReadOnlyFillColor2 = Color.WhiteSmoke;
            tbMamoi.ReadOnlyPlaceholderColor = Color.DarkGray;
            tbMamoi.SelectionBackColor = Color.DimGray;
            tbMamoi.ShadowAnimationDuration = 1;
            tbMamoi.ShadowBlur = 10;
            tbMamoi.ShadowColor = Color.FromArgb(64, 64, 64);
            tbMamoi.ShowBorder = false;
            tbMamoi.Size = new Size(145, 58);
            tbMamoi.SolidBorderColor = Color.Black;
            tbMamoi.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            tbMamoi.SolidBorderHoverColor = Color.Gray;
            tbMamoi.SolidFillColor = Color.FromArgb(214, 214, 214);
            tbMamoi.TabIndex = 4;
            tbMamoi.TextPadding = new Padding(16, 0, 6, 0);
            tbMamoi.ValidationErrorMessage = "Invalid input.";
            tbMamoi.ValidationFunction = null;
            // 
            // btCopy
            // 
            btCopy.AccessibilityDescription = "Button that copies text to clipboard";
            btCopy.AccessibilityHint = "Press Space or Enter to copy text";
            btCopy.AccessibilityName = "Copy Button";
            btCopy.BackgroundImage = Properties.Resources.Rectangle_3;
            btCopy.BorderColor = Color.Transparent;
            btCopy.BottomLeftRadius = 12;
            btCopy.BottomRightRadius = 12;
            btCopy.CheckmarkAnimationSpeed = 0.05F;
            btCopy.CheckmarkColor = Color.FromArgb(76, 175, 80);
            btCopy.CheckmarkDisplayDurationInSeconds = 4;
            btCopy.ColorTransitionSpeed = 0.15F;
            btCopy.ContextMenuCopyText = "Copy to Clipboard";
            btCopy.ContextMenuFont = new Font("Inter", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btCopy.EnableContextMenu = true;
            btCopy.Font = new Font("Inter", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btCopy.ForeColor = Color.White;
            btCopy.HoverFillColor = Color.Transparent;
            btCopy.Location = new Point(421, 122);
            btCopy.MakeRadial = false;
            btCopy.Name = "btCopy";
            btCopy.NormalFillColor = Color.Transparent;
            btCopy.NotificationBackColor = Color.FromArgb(250, 250, 250);
            btCopy.NotificationDuration = 3000;
            btCopy.NotificationText = "Text has been copied to clipboard";
            btCopy.NotificationTextColor = Color.FromArgb(50, 50, 50);
            btCopy.NotificationTextFont = new Font("Inter", 10F);
            btCopy.NotificationTitle = "Copy Completed";
            btCopy.NotificationTitleFont = new Font("Inter", 10F, FontStyle.Bold);
            btCopy.PressedFillColor = Color.Transparent;
            btCopy.RippleColor = Color.FromArgb(50, 255, 255, 255);
            btCopy.RippleExpandRate = 2F;
            btCopy.ShowFocusCue = false;
            btCopy.Size = new Size(117, 57);
            btCopy.TabIndex = 5;
            btCopy.TargetControl = null;
            btCopy.Text = "Sao chép";
            btCopy.TooltipText = "Click to copy";
            btCopy.TopLeftRadius = 12;
            btCopy.TopRightRadius = 12;
            // 
            // siticonePanel1
            // 
            siticonePanel1.AcrylicTintColor = Color.FromArgb(128, 255, 255, 255);
            siticonePanel1.BackColor = Color.Transparent;
            siticonePanel1.BorderAlignment = System.Drawing.Drawing2D.PenAlignment.Center;
            siticonePanel1.BorderDashPattern = null;
            siticonePanel1.BorderGradientEndColor = Color.Purple;
            siticonePanel1.BorderGradientStartColor = Color.Blue;
            siticonePanel1.BorderThickness = 2F;
            siticonePanel1.Controls.Add(btCopy);
            siticonePanel1.Controls.Add(tbMamoi);
            siticonePanel1.Controls.Add(label2);
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
            siticonePanel1.Location = new Point(0, -1);
            siticonePanel1.Name = "siticonePanel1";
            siticonePanel1.PatternStyle = System.Drawing.Drawing2D.HatchStyle.Max;
            siticonePanel1.RippleAlpha = 50;
            siticonePanel1.RippleAlphaDecrement = 3;
            siticonePanel1.RippleColor = Color.FromArgb(50, 255, 255, 255);
            siticonePanel1.RippleMaxSize = 600F;
            siticonePanel1.RippleSpeed = 15F;
            siticonePanel1.ShowBorder = true;
            siticonePanel1.Size = new Size(782, 221);
            siticonePanel1.TabIndex = 6;
            siticonePanel1.TabStop = true;
            siticonePanel1.UseBorderGradient = false;
            siticonePanel1.UseMultiGradient = false;
            siticonePanel1.UsePatternTexture = false;
            siticonePanel1.UseRadialGradient = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Inter", 12F, FontStyle.Bold);
            label3.Location = new Point(51, 257);
            label3.Name = "label3";
            label3.Size = new Size(205, 28);
            label3.TabIndex = 7;
            label3.Text = "Chọn bạn bè để mời";
            // 
            // siticoneTextBox1
            // 
            siticoneTextBox1.AccessibleDescription = "A customizable text input field.";
            siticoneTextBox1.AccessibleName = "Text Box";
            siticoneTextBox1.AccessibleRole = AccessibleRole.Text;
            siticoneTextBox1.BackColor = Color.Transparent;
            siticoneTextBox1.BlinkCount = 3;
            siticoneTextBox1.BlinkShadow = false;
            siticoneTextBox1.BorderColor1 = Color.LightSlateGray;
            siticoneTextBox1.BorderColor2 = Color.LightSlateGray;
            siticoneTextBox1.BorderFocusColor1 = Color.FromArgb(77, 77, 255);
            siticoneTextBox1.BorderFocusColor2 = Color.FromArgb(77, 77, 255);
            siticoneTextBox1.CanShake = true;
            siticoneTextBox1.ContinuousBlink = false;
            siticoneTextBox1.CursorBlinkRate = 500;
            siticoneTextBox1.CursorColor = Color.Black;
            siticoneTextBox1.CursorHeight = 26;
            siticoneTextBox1.CursorOffset = 0;
            siticoneTextBox1.CursorStyle = SiticoneNetCoreUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            siticoneTextBox1.CursorWidth = 1;
            siticoneTextBox1.DisabledBackColor = Color.WhiteSmoke;
            siticoneTextBox1.DisabledBorderColor = Color.LightGray;
            siticoneTextBox1.DisabledTextColor = Color.Gray;
            siticoneTextBox1.EnableDropShadow = false;
            siticoneTextBox1.FillColor1 = Color.White;
            siticoneTextBox1.FillColor2 = Color.White;
            siticoneTextBox1.Font = new Font("Inter", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            siticoneTextBox1.ForeColor = Color.DimGray;
            siticoneTextBox1.HoverBorderColor1 = Color.Gray;
            siticoneTextBox1.HoverBorderColor2 = Color.Gray;
            siticoneTextBox1.IsEnabled = true;
            siticoneTextBox1.Location = new Point(421, 249);
            siticoneTextBox1.Name = "siticoneTextBox1";
            siticoneTextBox1.PlaceholderColor = Color.Gray;
            siticoneTextBox1.PlaceholderText = "Tìm bạn bè";
            siticoneTextBox1.ReadOnlyBorderColor1 = Color.LightGray;
            siticoneTextBox1.ReadOnlyBorderColor2 = Color.LightGray;
            siticoneTextBox1.ReadOnlyFillColor1 = Color.WhiteSmoke;
            siticoneTextBox1.ReadOnlyFillColor2 = Color.WhiteSmoke;
            siticoneTextBox1.ReadOnlyPlaceholderColor = Color.DarkGray;
            siticoneTextBox1.SelectionBackColor = Color.FromArgb(77, 77, 255);
            siticoneTextBox1.ShadowAnimationDuration = 1;
            siticoneTextBox1.ShadowBlur = 10;
            siticoneTextBox1.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            siticoneTextBox1.Size = new Size(292, 43);
            siticoneTextBox1.SolidBorderColor = Color.LightSlateGray;
            siticoneTextBox1.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            siticoneTextBox1.SolidBorderHoverColor = Color.Gray;
            siticoneTextBox1.SolidFillColor = Color.White;
            siticoneTextBox1.TabIndex = 8;
            siticoneTextBox1.TextPadding = new Padding(16, 0, 6, 0);
            siticoneTextBox1.ValidationErrorMessage = "Invalid input.";
            siticoneTextBox1.ValidationFunction = null;
            // 
            // siticoneButton1
            // 
            siticoneButton1.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            siticoneButton1.AccessibleName = "";
            siticoneButton1.AutoSizeBasedOnText = false;
            siticoneButton1.BackColor = Color.Transparent;
            siticoneButton1.BackgroundImage = Properties.Resources.search;
            siticoneButton1.BadgeBackColor = Color.Red;
            siticoneButton1.BadgeFont = new Font("Inter", 8F, FontStyle.Bold);
            siticoneButton1.BadgeValue = 0;
            siticoneButton1.BadgeValueForeColor = Color.White;
            siticoneButton1.BorderColor = Color.Transparent;
            siticoneButton1.BorderWidth = 2;
            siticoneButton1.ButtonBackColor = Color.Transparent;
            siticoneButton1.ButtonImage = null;
            siticoneButton1.CanBeep = true;
            siticoneButton1.CanGlow = false;
            siticoneButton1.CanShake = true;
            siticoneButton1.ContextMenuStripEx = null;
            siticoneButton1.CornerRadiusBottomLeft = 0;
            siticoneButton1.CornerRadiusBottomRight = 0;
            siticoneButton1.CornerRadiusTopLeft = 0;
            siticoneButton1.CornerRadiusTopRight = 0;
            siticoneButton1.CustomCursor = Cursors.Default;
            siticoneButton1.DisabledTextColor = Color.FromArgb(150, 150, 150);
            siticoneButton1.EnableLongPress = false;
            siticoneButton1.EnablePressAnimation = true;
            siticoneButton1.EnableRippleEffect = true;
            siticoneButton1.EnableShadow = false;
            siticoneButton1.EnableTextWrapping = false;
            siticoneButton1.Font = new Font("Inter", 9F);
            siticoneButton1.GlowColor = Color.FromArgb(100, 255, 255, 255);
            siticoneButton1.GlowIntensity = 100;
            siticoneButton1.GlowRadius = 20F;
            siticoneButton1.GradientBackground = false;
            siticoneButton1.GradientColor = Color.FromArgb(114, 168, 255);
            siticoneButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneButton1.HintText = null;
            siticoneButton1.HoverBackColor = Color.FromArgb(114, 168, 255);
            siticoneButton1.HoverFontStyle = FontStyle.Regular;
            siticoneButton1.HoverTextColor = Color.White;
            siticoneButton1.HoverTransitionDuration = 250;
            siticoneButton1.ImageAlign = ContentAlignment.TopRight;
            siticoneButton1.ImagePadding = 5;
            siticoneButton1.ImageSize = new Size(16, 16);
            siticoneButton1.IsRadial = false;
            siticoneButton1.IsReadOnly = false;
            siticoneButton1.IsToggleButton = false;
            siticoneButton1.IsToggled = false;
            siticoneButton1.Location = new Point(678, 257);
            siticoneButton1.LongPressDurationMS = 1000;
            siticoneButton1.Name = "siticoneButton1";
            siticoneButton1.NormalFontStyle = FontStyle.Regular;
            siticoneButton1.ParticleColor = Color.FromArgb(200, 200, 200);
            siticoneButton1.ParticleCount = 15;
            siticoneButton1.PressAnimationScale = 0.97F;
            siticoneButton1.PressedBackColor = Color.Transparent;
            siticoneButton1.PressedFontStyle = FontStyle.Regular;
            siticoneButton1.PressTransitionDuration = 150;
            siticoneButton1.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            siticoneButton1.RippleColor = Color.FromArgb(255, 255, 255);
            siticoneButton1.RippleOpacity = 0.3F;
            siticoneButton1.RippleRadiusMultiplier = 0.6F;
            siticoneButton1.ShadowBlur = 5;
            siticoneButton1.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            siticoneButton1.ShadowOffset = new Point(2, 2);
            siticoneButton1.ShakeDuration = 500;
            siticoneButton1.ShakeIntensity = 5;
            siticoneButton1.Size = new Size(24, 24);
            siticoneButton1.TabIndex = 9;
            siticoneButton1.TextAlign = ContentAlignment.MiddleCenter;
            siticoneButton1.TextColor = Color.White;
            siticoneButton1.TooltipText = null;
            siticoneButton1.UseAdvancedRendering = true;
            siticoneButton1.UseParticles = false;
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
            siticonePanel2.CornerRadiusBottomLeft = 10F;
            siticonePanel2.CornerRadiusBottomRight = 10F;
            siticonePanel2.CornerRadiusTopLeft = 10F;
            siticonePanel2.CornerRadiusTopRight = 10F;
            siticonePanel2.EnableAcrylicEffect = false;
            siticonePanel2.EnableMicaEffect = false;
            siticonePanel2.EnableRippleEffect = false;
            siticonePanel2.FillColor = Color.White;
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
            siticonePanel2.Location = new Point(51, 314);
            siticonePanel2.Name = "siticonePanel2";
            siticonePanel2.PatternStyle = System.Drawing.Drawing2D.HatchStyle.Max;
            siticonePanel2.RippleAlpha = 50;
            siticonePanel2.RippleAlphaDecrement = 3;
            siticonePanel2.RippleColor = Color.FromArgb(50, 255, 255, 255);
            siticonePanel2.RippleMaxSize = 600F;
            siticonePanel2.RippleSpeed = 15F;
            siticonePanel2.ShowBorder = true;
            siticonePanel2.Size = new Size(662, 298);
            siticonePanel2.TabIndex = 10;
            siticonePanel2.TabStop = true;
            siticonePanel2.UseBorderGradient = false;
            siticonePanel2.UseMultiGradient = false;
            siticonePanel2.UsePatternTexture = false;
            siticonePanel2.UseRadialGradient = false;
            // 
            // btnSendInvitation
            // 
            btnSendInvitation.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnSendInvitation.AccessibleName = "Gửi lời mời và tạo phòng";
            btnSendInvitation.AutoSizeBasedOnText = false;
            btnSendInvitation.BackColor = Color.Transparent;
            btnSendInvitation.BadgeBackColor = Color.Red;
            btnSendInvitation.BadgeFont = new Font("Inter", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSendInvitation.BadgeValue = 0;
            btnSendInvitation.BadgeValueForeColor = Color.White;
            btnSendInvitation.BorderColor = Color.Transparent;
            btnSendInvitation.BorderWidth = 2;
            btnSendInvitation.ButtonBackColor = Color.FromArgb(117, 164, 127);
            btnSendInvitation.ButtonImage = null;
            btnSendInvitation.CanBeep = true;
            btnSendInvitation.CanGlow = false;
            btnSendInvitation.CanShake = true;
            btnSendInvitation.ContextMenuStripEx = null;
            btnSendInvitation.CornerRadiusBottomLeft = 12;
            btnSendInvitation.CornerRadiusBottomRight = 12;
            btnSendInvitation.CornerRadiusTopLeft = 12;
            btnSendInvitation.CornerRadiusTopRight = 12;
            btnSendInvitation.CustomCursor = Cursors.Default;
            btnSendInvitation.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnSendInvitation.EnableLongPress = false;
            btnSendInvitation.EnablePressAnimation = true;
            btnSendInvitation.EnableRippleEffect = true;
            btnSendInvitation.EnableShadow = false;
            btnSendInvitation.EnableTextWrapping = false;
            btnSendInvitation.Font = new Font("Inter ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSendInvitation.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnSendInvitation.GlowIntensity = 100;
            btnSendInvitation.GlowRadius = 20F;
            btnSendInvitation.GradientBackground = false;
            btnSendInvitation.GradientColor = Color.FromArgb(117, 164, 127);
            btnSendInvitation.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnSendInvitation.HintText = null;
            btnSendInvitation.HoverBackColor = Color.FromArgb(117, 164, 127);
            btnSendInvitation.HoverFontStyle = FontStyle.Regular;
            btnSendInvitation.HoverTextColor = Color.White;
            btnSendInvitation.HoverTransitionDuration = 250;
            btnSendInvitation.ImageAlign = ContentAlignment.MiddleLeft;
            btnSendInvitation.ImagePadding = 5;
            btnSendInvitation.ImageSize = new Size(16, 16);
            btnSendInvitation.IsRadial = false;
            btnSendInvitation.IsReadOnly = false;
            btnSendInvitation.IsToggleButton = false;
            btnSendInvitation.IsToggled = false;
            btnSendInvitation.Location = new Point(51, 639);
            btnSendInvitation.LongPressDurationMS = 1000;
            btnSendInvitation.Name = "btnSendInvitation";
            btnSendInvitation.NormalFontStyle = FontStyle.Regular;
            btnSendInvitation.ParticleColor = Color.FromArgb(200, 200, 200);
            btnSendInvitation.ParticleCount = 15;
            btnSendInvitation.PressAnimationScale = 0.97F;
            btnSendInvitation.PressedBackColor = Color.FromArgb(117, 164, 127);
            btnSendInvitation.PressedFontStyle = FontStyle.Regular;
            btnSendInvitation.PressTransitionDuration = 150;
            btnSendInvitation.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnSendInvitation.RippleColor = Color.FromArgb(255, 255, 255);
            btnSendInvitation.RippleOpacity = 0.3F;
            btnSendInvitation.RippleRadiusMultiplier = 0.6F;
            btnSendInvitation.ShadowBlur = 5;
            btnSendInvitation.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnSendInvitation.ShadowOffset = new Point(2, 2);
            btnSendInvitation.ShakeDuration = 500;
            btnSendInvitation.ShakeIntensity = 5;
            btnSendInvitation.Size = new Size(662, 45);
            btnSendInvitation.TabIndex = 11;
            btnSendInvitation.Text = "Gửi lời mời và tạo phòng";
            btnSendInvitation.TextAlign = ContentAlignment.MiddleCenter;
            btnSendInvitation.TextColor = Color.White;
            btnSendInvitation.TooltipText = null;
            btnSendInvitation.UseAdvancedRendering = true;
            btnSendInvitation.UseParticles = false;
            btnSendInvitation.Click += btnSendInvitation_Click;
            // 
            // RoomRequests
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(782, 706);
            Controls.Add(btnSendInvitation);
            Controls.Add(siticoneButton1);
            Controls.Add(siticoneTextBox1);
            Controls.Add(label3);
            Controls.Add(siticonePanel1);
            Controls.Add(siticonePanel2);
            MaximumSize = new Size(800, 753);
            Name = "RoomRequests";
            Text = "RoomRequests";
            siticonePanel1.ResumeLayout(false);
            siticonePanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private SiticoneNetCoreUI.SiticoneTextBox tbMamoi;
        private SiticoneNetCoreUI.SiticoneCopyButton btCopy;
        private SiticoneNetCoreUI.SiticonePanel siticonePanel1;
        private Label label3;
        private SiticoneNetCoreUI.SiticoneTextBox siticoneTextBox1;
        private SiticoneNetCoreUI.SiticoneButton siticoneButton1;
        private SiticoneNetCoreUI.SiticonePanel siticonePanel2;
        private SiticoneNetCoreUI.SiticoneButton btnSendInvitation;
    }
}