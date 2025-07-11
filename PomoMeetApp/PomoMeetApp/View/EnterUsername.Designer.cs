namespace PomoMeetApp.View
{
    partial class EnterUsername
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
            tbEnter = new SiticoneNetCoreUI.SiticoneTextBox();
            pictureBox3 = new PictureBox();
            btnUpdate = new SiticoneNetCoreUI.SiticoneButton();
            ((System.ComponentModel.ISupportInitialize)Rectangle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // Rectangle
            // 
            Rectangle.Image = Properties.Resources.Rectangle;
            Rectangle.Location = new Point(117, 126);
            Rectangle.Name = "Rectangle";
            Rectangle.Size = new Size(671, 241);
            Rectangle.SizeMode = PictureBoxSizeMode.StretchImage;
            Rectangle.TabIndex = 2;
            Rectangle.TabStop = false;
            // 
            // email
            // 
            email.AutoSize = true;
            email.BackColor = Color.FromArgb(233, 240, 201);
            email.Font = new Font("Inter", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            email.ForeColor = Color.FromArgb(117, 164, 127);
            email.Location = new Point(180, 144);
            email.Name = "email";
            email.Size = new Size(219, 40);
            email.TabIndex = 5;
            email.Text = "Tên đăng nhập";
            // 
            // tbEnter
            // 
            tbEnter.AccessibleDescription = "A customizable text input field.";
            tbEnter.AccessibleName = "Text Box";
            tbEnter.AccessibleRole = AccessibleRole.Text;
            tbEnter.BackColor = Color.Transparent;
            tbEnter.BlinkCount = 3;
            tbEnter.BlinkShadow = false;
            tbEnter.BorderColor1 = Color.LightSlateGray;
            tbEnter.BorderColor2 = Color.LightSlateGray;
            tbEnter.BorderFocusColor1 = Color.FromArgb(77, 77, 255);
            tbEnter.BorderFocusColor2 = Color.FromArgb(77, 77, 255);
            tbEnter.CanShake = true;
            tbEnter.ContinuousBlink = false;
            tbEnter.CursorBlinkRate = 500;
            tbEnter.CursorColor = Color.Black;
            tbEnter.CursorHeight = 26;
            tbEnter.CursorOffset = 0;
            tbEnter.CursorStyle = SiticoneNetCoreUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            tbEnter.CursorWidth = 1;
            tbEnter.DisabledBackColor = Color.WhiteSmoke;
            tbEnter.DisabledBorderColor = Color.LightGray;
            tbEnter.DisabledTextColor = Color.Gray;
            tbEnter.EnableDropShadow = false;
            tbEnter.FillColor1 = Color.White;
            tbEnter.FillColor2 = Color.White;
            tbEnter.Font = new Font("Inter", 10.2F);
            tbEnter.ForeColor = Color.DimGray;
            tbEnter.HoverBorderColor1 = Color.Gray;
            tbEnter.HoverBorderColor2 = Color.Gray;
            tbEnter.IsEnabled = true;
            tbEnter.Location = new Point(180, 200);
            tbEnter.Name = "tbEnter";
            tbEnter.PlaceholderColor = Color.Gray;
            tbEnter.PlaceholderText = "Nhập vào đây";
            tbEnter.ReadOnlyBorderColor1 = Color.LightGray;
            tbEnter.ReadOnlyBorderColor2 = Color.LightGray;
            tbEnter.ReadOnlyFillColor1 = Color.WhiteSmoke;
            tbEnter.ReadOnlyFillColor2 = Color.WhiteSmoke;
            tbEnter.ReadOnlyPlaceholderColor = Color.DarkGray;
            tbEnter.SelectionBackColor = Color.FromArgb(77, 77, 255);
            tbEnter.ShadowAnimationDuration = 1;
            tbEnter.ShadowBlur = 10;
            tbEnter.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            tbEnter.ShowBorder = false;
            tbEnter.Size = new Size(537, 50);
            tbEnter.SolidBorderColor = Color.LightSlateGray;
            tbEnter.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            tbEnter.SolidBorderHoverColor = Color.Gray;
            tbEnter.SolidFillColor = Color.White;
            tbEnter.TabIndex = 7;
            tbEnter.TextPadding = new Padding(16, 0, 6, 0);
            tbEnter.ValidationErrorMessage = "Invalid input.";
            tbEnter.ValidationFunction = null;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.SmallLogo;
            pictureBox3.Location = new Point(12, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(90, 76);
            pictureBox3.TabIndex = 18;
            pictureBox3.TabStop = false;
            // 
            // btnUpdate
            // 
            btnUpdate.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnUpdate.AccessibleName = "Cập nhật";
            btnUpdate.AutoSizeBasedOnText = false;
            btnUpdate.BackColor = Color.Transparent;
            btnUpdate.BadgeBackColor = Color.Red;
            btnUpdate.BadgeFont = new Font("Inter", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.BadgeValue = 0;
            btnUpdate.BadgeValueForeColor = Color.White;
            btnUpdate.BorderColor = Color.FromArgb(117, 164, 127);
            btnUpdate.BorderWidth = 2;
            btnUpdate.ButtonBackColor = Color.White;
            btnUpdate.ButtonImage = null;
            btnUpdate.CanBeep = true;
            btnUpdate.CanGlow = false;
            btnUpdate.CanShake = true;
            btnUpdate.ContextMenuStripEx = null;
            btnUpdate.CornerRadiusBottomLeft = 0;
            btnUpdate.CornerRadiusBottomRight = 0;
            btnUpdate.CornerRadiusTopLeft = 0;
            btnUpdate.CornerRadiusTopRight = 0;
            btnUpdate.CustomCursor = Cursors.Default;
            btnUpdate.DisabledTextColor = Color.FromArgb(117, 164, 127);
            btnUpdate.EnableLongPress = false;
            btnUpdate.EnablePressAnimation = true;
            btnUpdate.EnableRippleEffect = true;
            btnUpdate.EnableShadow = false;
            btnUpdate.EnableTextWrapping = false;
            btnUpdate.Font = new Font("Inter", 12F, FontStyle.Bold);
            btnUpdate.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnUpdate.GlowIntensity = 100;
            btnUpdate.GlowRadius = 20F;
            btnUpdate.GradientBackground = false;
            btnUpdate.GradientColor = Color.White;
            btnUpdate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnUpdate.HintText = null;
            btnUpdate.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnUpdate.HoverFontStyle = FontStyle.Regular;
            btnUpdate.HoverTextColor = Color.White;
            btnUpdate.HoverTransitionDuration = 250;
            btnUpdate.ImageAlign = ContentAlignment.MiddleLeft;
            btnUpdate.ImagePadding = 5;
            btnUpdate.ImageSize = new Size(16, 16);
            btnUpdate.IsRadial = false;
            btnUpdate.IsReadOnly = false;
            btnUpdate.IsToggleButton = false;
            btnUpdate.IsToggled = false;
            btnUpdate.Location = new Point(180, 280);
            btnUpdate.LongPressDurationMS = 1000;
            btnUpdate.Name = "btnUpdate";
            btnUpdate.NormalFontStyle = FontStyle.Regular;
            btnUpdate.ParticleColor = Color.FromArgb(200, 200, 200);
            btnUpdate.ParticleCount = 15;
            btnUpdate.PressAnimationScale = 0.97F;
            btnUpdate.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnUpdate.PressedFontStyle = FontStyle.Regular;
            btnUpdate.PressTransitionDuration = 150;
            btnUpdate.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnUpdate.RippleColor = Color.FromArgb(255, 255, 255);
            btnUpdate.RippleOpacity = 0.3F;
            btnUpdate.RippleRadiusMultiplier = 0.6F;
            btnUpdate.ShadowBlur = 5;
            btnUpdate.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnUpdate.ShadowOffset = new Point(2, 2);
            btnUpdate.ShakeDuration = 500;
            btnUpdate.ShakeIntensity = 5;
            btnUpdate.Size = new Size(537, 47);
            btnUpdate.TabIndex = 20;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.TextAlign = ContentAlignment.MiddleCenter;
            btnUpdate.TextColor = Color.FromArgb(117, 164, 127);
            btnUpdate.TooltipText = null;
            btnUpdate.UseAdvancedRendering = true;
            btnUpdate.UseParticles = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // EnterUsername
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 255, 224);
            ClientSize = new Size(914, 442);
            Controls.Add(btnUpdate);
            Controls.Add(pictureBox3);
            Controls.Add(tbEnter);
            Controls.Add(email);
            Controls.Add(Rectangle);
            MaximumSize = new Size(932, 489);
            Name = "EnterUsername";
            Text = "EnterUsername";
            ((System.ComponentModel.ISupportInitialize)Rectangle).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Rectangle;
        private Label email;
        private SiticoneNetCoreUI.SiticoneTextBox tbEnter;
        private PictureBox pictureBox3;
        private SiticoneNetCoreUI.SiticoneButton btnUpdate;
    }
}