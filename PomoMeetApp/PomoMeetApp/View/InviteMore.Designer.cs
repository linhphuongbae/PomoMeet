namespace PomoMeetApp.View
{
    partial class InviteMore
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
            siticonePanel3 = new SiticoneNetCoreUI.SiticonePanel();
            btCopy = new SiticoneNetCoreUI.SiticoneCopyButton();
            tbMamoi = new SiticoneNetCoreUI.SiticoneTextBox();
            label2 = new Label();
            label1 = new Label();
            siticonePanel3.SuspendLayout();
            SuspendLayout();
            // 
            // siticonePanel3
            // 
            siticonePanel3.AcrylicTintColor = Color.FromArgb(128, 255, 255, 255);
            siticonePanel3.BackColor = Color.Transparent;
            siticonePanel3.BorderAlignment = System.Drawing.Drawing2D.PenAlignment.Center;
            siticonePanel3.BorderDashPattern = null;
            siticonePanel3.BorderGradientEndColor = Color.Purple;
            siticonePanel3.BorderGradientStartColor = Color.Blue;
            siticonePanel3.BorderThickness = 2F;
            siticonePanel3.Controls.Add(btCopy);
            siticonePanel3.Controls.Add(tbMamoi);
            siticonePanel3.Controls.Add(label2);
            siticonePanel3.Controls.Add(label1);
            siticonePanel3.CornerRadiusBottomLeft = 0F;
            siticonePanel3.CornerRadiusBottomRight = 0F;
            siticonePanel3.CornerRadiusTopLeft = 10F;
            siticonePanel3.CornerRadiusTopRight = 10F;
            siticonePanel3.EnableAcrylicEffect = false;
            siticonePanel3.EnableMicaEffect = false;
            siticonePanel3.EnableRippleEffect = false;
            siticonePanel3.FillColor = Color.FromArgb(117, 164, 127);
            siticonePanel3.GradientColors = new Color[]
    {
    Color.White,
    Color.LightGray,
    Color.Gray
    };
            siticonePanel3.GradientPositions = new float[]
    {
    0F,
    0.5F,
    1F
    };
            siticonePanel3.Location = new Point(-1, -7);
            siticonePanel3.Name = "siticonePanel3";
            siticonePanel3.PatternStyle = System.Drawing.Drawing2D.HatchStyle.Max;
            siticonePanel3.RippleAlpha = 50;
            siticonePanel3.RippleAlphaDecrement = 3;
            siticonePanel3.RippleColor = Color.FromArgb(50, 255, 255, 255);
            siticonePanel3.RippleMaxSize = 600F;
            siticonePanel3.RippleSpeed = 15F;
            siticonePanel3.ShowBorder = true;
            siticonePanel3.Size = new Size(529, 233);
            siticonePanel3.TabIndex = 8;
            siticonePanel3.TabStop = true;
            siticonePanel3.UseBorderGradient = false;
            siticonePanel3.UseMultiGradient = false;
            siticonePanel3.UsePatternTexture = false;
            siticonePanel3.UseRadialGradient = false;
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
            btCopy.Font = new Font("Inter", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btCopy.ForeColor = Color.White;
            btCopy.HoverFillColor = Color.Transparent;
            btCopy.Location = new Point(272, 133);
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
            btCopy.TargetControl = tbMamoi;
            btCopy.Text = "Sao chép";
            btCopy.TooltipText = "Click to copy";
            btCopy.TopLeftRadius = 12;
            btCopy.TopRightRadius = 12;
            btCopy.Click += btCopy_Click;
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
            tbMamoi.Location = new Point(106, 132);
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
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(117, 164, 127);
            label2.Font = new Font("Inter", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(97, 94);
            label2.Name = "label2";
            label2.Size = new Size(315, 24);
            label2.TabIndex = 3;
            label2.Text = "Chia sẻ mã phòng để bạn bè tham gia";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(117, 164, 127);
            label1.Font = new Font("Inter", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(60, 30);
            label1.Name = "label1";
            label1.Size = new Size(384, 53);
            label1.TabIndex = 2;
            label1.Text = "Mời bạn bè tham gia";
            // 
            // InviteMore
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(518, 224);
            Controls.Add(siticonePanel3);
            Name = "InviteMore";
            Text = "InviteMore";
            siticonePanel3.ResumeLayout(false);
            siticonePanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SiticoneNetCoreUI.SiticonePanel siticonePanel3;
        private SiticoneNetCoreUI.SiticoneCopyButton btCopy;
        private SiticoneNetCoreUI.SiticoneTextBox tbMamoi;
        private Label label2;
        private Label label1;
    }
}