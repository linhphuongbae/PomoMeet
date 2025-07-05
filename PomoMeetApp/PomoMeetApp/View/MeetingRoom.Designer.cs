namespace PomoMeetApp.View
{
    partial class MeetingRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeetingRoom));
            SiticoneNetCoreUI.SiticoneFlowPanel.LayoutState layoutState1 = new SiticoneNetCoreUI.SiticoneFlowPanel.LayoutState();
            ProgressBarMusic = new SiticoneNetCoreUI.SiticoneHProgressBar();
            btn_Reset = new SiticoneNetCoreUI.SiticoneButton();
            btn_pomodoro = new SiticoneNetCoreUI.SiticoneButton();
            btn_Start = new SiticoneNetCoreUI.SiticoneButton();
            lb_time_counter = new SiticoneNetCoreUI.SiticoneLabel();
            panel1 = new Panel();
            avatar_btn = new SiticoneNetCoreUI.SiticoneImageButton();
            panel3 = new Panel();
            siticoneImageButton8 = new SiticoneNetCoreUI.SiticoneImageButton();
            lblMembersNumber = new Label();
            panel6 = new Panel();
            btnRoomID = new SiticoneNetCoreUI.SiticoneButton();
            lb_participant = new SiticoneNetCoreUI.SiticoneLabel();
            participants_panel = new TableLayoutPanel();
            tb_FindParticipants = new SiticoneNetCoreUI.SiticoneTextBox();
            listViewParticipants = new ListView();
            colAvatar = new ColumnHeader();
            colName = new ColumnHeader();
            colMic = new ColumnHeader();
            colCamera = new ColumnHeader();
            imageListAvatar = new ImageList(components);
            Avatar = new ColumnHeader();
            Ten = new ColumnHeader();
            Mic = new ColumnHeader();
            Camera = new ColumnHeader();
            panel7 = new Panel();
            siticoneLabel1 = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneImageButton9 = new SiticoneNetCoreUI.SiticoneImageButton();
            siticoneLabel2 = new SiticoneNetCoreUI.SiticoneLabel();
            sbtn_ChangeHost = new SiticoneNetCoreUI.SiticoneButton();
            sbtn_CancelCall = new SiticoneNetCoreUI.SiticoneButton();
            siticonePanel1 = new SiticoneNetCoreUI.SiticonePanel();
            btn_Speaker = new SiticoneNetCoreUI.SiticoneButton();
            btn_Camera = new SiticoneNetCoreUI.SiticoneButton();
            btn_Mic = new SiticoneNetCoreUI.SiticoneButton();
            userProfilePanel1 = new UserProfilePanel();
            siticoneImageButton1 = new SiticoneNetCoreUI.SiticoneImageButton();
            panel2 = new Panel();
            tbMessages = new SiticoneNetCoreUI.SiticoneTextBox();
            tbDisplayMsg = new RichTextBox();
            btn_Break = new SiticoneNetCoreUI.SiticoneButton();
            lb_CurrentTime = new Label();
            label1 = new Label();
            lb_TotalTime = new Label();
            pn_Background = new Panel();
            panel4 = new Panel();
            pictureBox1 = new PictureBox();
            btnSendMessages = new SiticoneNetCoreUI.SiticoneButton();
            sideBar2 = new SideBar();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            participants_panel.SuspendLayout();
            panel7.SuspendLayout();
            siticonePanel1.SuspendLayout();
            panel2.SuspendLayout();
            pn_Background.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // ProgressBarMusic
            // 
            ProgressBarMusic.AccessibleDescription = "This control shows the value of the horizontal progress bar.";
            ProgressBarMusic.AccessibleName = "Advanced and modern horizontal progress bar control";
            ProgressBarMusic.AccessibleRole = AccessibleRole.ProgressBar;
            ProgressBarMusic.AnimationDurationMs = 300D;
            ProgressBarMusic.AnimationTimerInterval = 15;
            ProgressBarMusic.AutoLabelColor = false;
            ProgressBarMusic.BackColor = Color.Transparent;
            ProgressBarMusic.BackgroundBarColor = Color.White;
            ProgressBarMusic.BorderColor = Color.FromArgb(117, 164, 127);
            ProgressBarMusic.CanBeep = true;
            ProgressBarMusic.CanShake = true;
            ProgressBarMusic.CornerRadiusBottomLeft = 10;
            ProgressBarMusic.CornerRadiusBottomRight = 10;
            ProgressBarMusic.CornerRadiusTopLeft = 10;
            ProgressBarMusic.CornerRadiusTopRight = 10;
            ProgressBarMusic.CustomLabel = "";
            ProgressBarMusic.EnableValueDragging = false;
            ProgressBarMusic.ErrorColor = Color.Red;
            ProgressBarMusic.GradientEndColor = Color.FromArgb(117, 164, 127);
            ProgressBarMusic.GradientStartColor = Color.FromArgb(252, 255, 224);
            ProgressBarMusic.Indeterminate = false;
            ProgressBarMusic.IndeterminateBarColor = Color.FromArgb(117, 164, 127);
            ProgressBarMusic.IsReadonly = false;
            ProgressBarMusic.LabelColor = Color.Black;
            ProgressBarMusic.LabelFont = new Font("Inter", 10F, FontStyle.Bold);
            ProgressBarMusic.Location = new Point(59, 307);
            ProgressBarMusic.MakeRadial = true;
            ProgressBarMusic.Maximum = 100;
            ProgressBarMusic.Minimum = 0;
            ProgressBarMusic.MinimumSize = new Size(50, 20);
            ProgressBarMusic.Name = "ProgressBarMusic";
            ProgressBarMusic.ReadonlyBorderColor = Color.ForestGreen;
            ProgressBarMusic.ReadonlyFillColor1 = Color.ForestGreen;
            ProgressBarMusic.ReadonlyFillColor2 = Color.DarkGreen;
            ProgressBarMusic.ReadonlyForeColor = Color.White;
            ProgressBarMusic.ShowFocusCue = false;
            ProgressBarMusic.ShowPercentage = false;
            ProgressBarMusic.Size = new Size(437, 20);
            ProgressBarMusic.SuccessColor = Color.Green;
            ProgressBarMusic.TabIndex = 6;
            ProgressBarMusic.Text = "siticonehProgressBar1";
            ProgressBarMusic.Value = 72;
            ProgressBarMusic.ValueOrientation = SiticoneNetCoreUI.Helpers.ProgressBar.ProgressBarOrientation.Horizontal;
            ProgressBarMusic.WarningColor = Color.Orange;
            // 
            // btn_Reset
            // 
            btn_Reset.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btn_Reset.AccessibleName = "Reset";
            btn_Reset.AutoSizeBasedOnText = false;
            btn_Reset.BackColor = Color.Transparent;
            btn_Reset.BadgeBackColor = Color.DarkSeaGreen;
            btn_Reset.BadgeFont = new Font("Inter", 8F, FontStyle.Bold);
            btn_Reset.BadgeValue = 0;
            btn_Reset.BadgeValueForeColor = Color.White;
            btn_Reset.BorderColor = Color.DarkSeaGreen;
            btn_Reset.BorderWidth = 2;
            btn_Reset.ButtonBackColor = Color.DarkSeaGreen;
            btn_Reset.ButtonImage = null;
            btn_Reset.CanBeep = true;
            btn_Reset.CanGlow = false;
            btn_Reset.CanShake = true;
            btn_Reset.ContextMenuStripEx = null;
            btn_Reset.CornerRadiusBottomLeft = 0;
            btn_Reset.CornerRadiusBottomRight = 0;
            btn_Reset.CornerRadiusTopLeft = 0;
            btn_Reset.CornerRadiusTopRight = 0;
            btn_Reset.CustomCursor = Cursors.Default;
            btn_Reset.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btn_Reset.EnableLongPress = false;
            btn_Reset.EnablePressAnimation = true;
            btn_Reset.EnableRippleEffect = true;
            btn_Reset.EnableShadow = false;
            btn_Reset.EnableTextWrapping = false;
            btn_Reset.Font = new Font("Inter", 15F);
            btn_Reset.GlowColor = Color.FromArgb(0, 64, 0);
            btn_Reset.GlowIntensity = 100;
            btn_Reset.GlowRadius = 20F;
            btn_Reset.GradientBackground = false;
            btn_Reset.GradientColor = Color.FromArgb(114, 168, 255);
            btn_Reset.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btn_Reset.HintText = null;
            btn_Reset.HoverBackColor = Color.DarkSeaGreen;
            btn_Reset.HoverFontStyle = FontStyle.Regular;
            btn_Reset.HoverTextColor = Color.White;
            btn_Reset.HoverTransitionDuration = 250;
            btn_Reset.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Reset.ImagePadding = 5;
            btn_Reset.ImageSize = new Size(16, 16);
            btn_Reset.IsRadial = false;
            btn_Reset.IsReadOnly = false;
            btn_Reset.IsToggleButton = false;
            btn_Reset.IsToggled = false;
            btn_Reset.Location = new Point(380, 252);
            btn_Reset.LongPressDurationMS = 1000;
            btn_Reset.Name = "btn_Reset";
            btn_Reset.NormalFontStyle = FontStyle.Regular;
            btn_Reset.ParticleColor = Color.FromArgb(200, 200, 200);
            btn_Reset.ParticleCount = 15;
            btn_Reset.PressAnimationScale = 0.97F;
            btn_Reset.PressedBackColor = Color.ForestGreen;
            btn_Reset.PressedFontStyle = FontStyle.Regular;
            btn_Reset.PressTransitionDuration = 150;
            btn_Reset.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btn_Reset.RippleColor = Color.FromArgb(255, 255, 255);
            btn_Reset.RippleOpacity = 0.3F;
            btn_Reset.RippleRadiusMultiplier = 0.6F;
            btn_Reset.ShadowBlur = 5;
            btn_Reset.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btn_Reset.ShadowOffset = new Point(2, 2);
            btn_Reset.ShakeDuration = 500;
            btn_Reset.ShakeIntensity = 5;
            btn_Reset.Size = new Size(149, 37);
            btn_Reset.TabIndex = 5;
            btn_Reset.Text = "Reset";
            btn_Reset.TextAlign = ContentAlignment.MiddleCenter;
            btn_Reset.TextColor = Color.Black;
            btn_Reset.TooltipText = null;
            btn_Reset.UseAdvancedRendering = true;
            btn_Reset.UseParticles = false;
            btn_Reset.Click += btn_Reset_Click;
            // 
            // btn_pomodoro
            // 
            btn_pomodoro.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btn_pomodoro.AccessibleName = "Pomodoro";
            btn_pomodoro.AutoSizeBasedOnText = false;
            btn_pomodoro.BackColor = Color.Transparent;
            btn_pomodoro.BadgeBackColor = Color.DarkSeaGreen;
            btn_pomodoro.BadgeFont = new Font("Inter", 8F, FontStyle.Bold);
            btn_pomodoro.BadgeValue = 0;
            btn_pomodoro.BadgeValueForeColor = Color.White;
            btn_pomodoro.BorderColor = Color.DarkSeaGreen;
            btn_pomodoro.BorderWidth = 2;
            btn_pomodoro.ButtonBackColor = Color.DarkSeaGreen;
            btn_pomodoro.ButtonImage = null;
            btn_pomodoro.CanBeep = true;
            btn_pomodoro.CanGlow = false;
            btn_pomodoro.CanShake = true;
            btn_pomodoro.ContextMenuStripEx = null;
            btn_pomodoro.CornerRadiusBottomLeft = 0;
            btn_pomodoro.CornerRadiusBottomRight = 0;
            btn_pomodoro.CornerRadiusTopLeft = 0;
            btn_pomodoro.CornerRadiusTopRight = 0;
            btn_pomodoro.CustomCursor = Cursors.Default;
            btn_pomodoro.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btn_pomodoro.EnableLongPress = false;
            btn_pomodoro.EnablePressAnimation = true;
            btn_pomodoro.EnableRippleEffect = true;
            btn_pomodoro.EnableShadow = false;
            btn_pomodoro.EnableTextWrapping = false;
            btn_pomodoro.Font = new Font("Inter", 10F);
            btn_pomodoro.ForeColor = SystemColors.ActiveCaptionText;
            btn_pomodoro.GlowColor = Color.FromArgb(0, 64, 0);
            btn_pomodoro.GlowIntensity = 100;
            btn_pomodoro.GlowRadius = 20F;
            btn_pomodoro.GradientBackground = false;
            btn_pomodoro.GradientColor = Color.FromArgb(114, 168, 255);
            btn_pomodoro.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btn_pomodoro.HintText = null;
            btn_pomodoro.HoverBackColor = Color.DarkSeaGreen;
            btn_pomodoro.HoverFontStyle = FontStyle.Regular;
            btn_pomodoro.HoverTextColor = Color.White;
            btn_pomodoro.HoverTransitionDuration = 250;
            btn_pomodoro.ImageAlign = ContentAlignment.MiddleLeft;
            btn_pomodoro.ImagePadding = 5;
            btn_pomodoro.ImageSize = new Size(16, 16);
            btn_pomodoro.IsRadial = false;
            btn_pomodoro.IsReadOnly = false;
            btn_pomodoro.IsToggleButton = false;
            btn_pomodoro.IsToggled = false;
            btn_pomodoro.Location = new Point(173, 24);
            btn_pomodoro.LongPressDurationMS = 1000;
            btn_pomodoro.Name = "btn_pomodoro";
            btn_pomodoro.NormalFontStyle = FontStyle.Regular;
            btn_pomodoro.ParticleColor = Color.FromArgb(200, 200, 200);
            btn_pomodoro.ParticleCount = 15;
            btn_pomodoro.PressAnimationScale = 0.97F;
            btn_pomodoro.PressedBackColor = Color.ForestGreen;
            btn_pomodoro.PressedFontStyle = FontStyle.Regular;
            btn_pomodoro.PressTransitionDuration = 150;
            btn_pomodoro.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btn_pomodoro.RippleColor = Color.FromArgb(255, 255, 255);
            btn_pomodoro.RippleOpacity = 0.3F;
            btn_pomodoro.RippleRadiusMultiplier = 0.6F;
            btn_pomodoro.ShadowBlur = 5;
            btn_pomodoro.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btn_pomodoro.ShadowOffset = new Point(2, 2);
            btn_pomodoro.ShakeDuration = 500;
            btn_pomodoro.ShakeIntensity = 5;
            btn_pomodoro.Size = new Size(92, 32);
            btn_pomodoro.TabIndex = 3;
            btn_pomodoro.Text = "Pomodoro";
            btn_pomodoro.TextAlign = ContentAlignment.MiddleCenter;
            btn_pomodoro.TextColor = Color.Black;
            btn_pomodoro.TooltipText = null;
            btn_pomodoro.UseAdvancedRendering = true;
            btn_pomodoro.UseParticles = false;
            btn_pomodoro.Click += btn_pomodoro_Click;
            // 
            // btn_Start
            // 
            btn_Start.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btn_Start.AccessibleName = "Start";
            btn_Start.AutoSizeBasedOnText = false;
            btn_Start.BackColor = Color.Transparent;
            btn_Start.BadgeBackColor = Color.DarkSeaGreen;
            btn_Start.BadgeFont = new Font("Inter", 8F, FontStyle.Bold);
            btn_Start.BadgeValue = 0;
            btn_Start.BadgeValueForeColor = Color.White;
            btn_Start.BorderColor = Color.DarkSeaGreen;
            btn_Start.BorderWidth = 2;
            btn_Start.ButtonBackColor = Color.DarkSeaGreen;
            btn_Start.ButtonImage = null;
            btn_Start.CanBeep = true;
            btn_Start.CanGlow = false;
            btn_Start.CanShake = true;
            btn_Start.ContextMenuStripEx = null;
            btn_Start.CornerRadiusBottomLeft = 0;
            btn_Start.CornerRadiusBottomRight = 0;
            btn_Start.CornerRadiusTopLeft = 0;
            btn_Start.CornerRadiusTopRight = 0;
            btn_Start.CustomCursor = Cursors.Default;
            btn_Start.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btn_Start.EnableLongPress = false;
            btn_Start.EnablePressAnimation = true;
            btn_Start.EnableRippleEffect = true;
            btn_Start.EnableShadow = false;
            btn_Start.EnableTextWrapping = false;
            btn_Start.Font = new Font("Inter", 15F);
            btn_Start.GlowColor = Color.FromArgb(0, 64, 0);
            btn_Start.GlowIntensity = 100;
            btn_Start.GlowRadius = 20F;
            btn_Start.GradientBackground = false;
            btn_Start.GradientColor = Color.FromArgb(114, 168, 255);
            btn_Start.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btn_Start.HintText = null;
            btn_Start.HoverBackColor = Color.DarkSeaGreen;
            btn_Start.HoverFontStyle = FontStyle.Regular;
            btn_Start.HoverTextColor = Color.White;
            btn_Start.HoverTransitionDuration = 250;
            btn_Start.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Start.ImagePadding = 5;
            btn_Start.ImageSize = new Size(16, 16);
            btn_Start.IsRadial = false;
            btn_Start.IsReadOnly = false;
            btn_Start.IsToggleButton = false;
            btn_Start.IsToggled = false;
            btn_Start.Location = new Point(116, 209);
            btn_Start.LongPressDurationMS = 1000;
            btn_Start.Name = "btn_Start";
            btn_Start.NormalFontStyle = FontStyle.Regular;
            btn_Start.ParticleColor = Color.FromArgb(200, 200, 200);
            btn_Start.ParticleCount = 15;
            btn_Start.PressAnimationScale = 0.97F;
            btn_Start.PressedBackColor = Color.ForestGreen;
            btn_Start.PressedFontStyle = FontStyle.Regular;
            btn_Start.PressTransitionDuration = 150;
            btn_Start.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btn_Start.RippleColor = Color.FromArgb(255, 255, 255);
            btn_Start.RippleOpacity = 0.3F;
            btn_Start.RippleRadiusMultiplier = 0.6F;
            btn_Start.ShadowBlur = 5;
            btn_Start.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btn_Start.ShadowOffset = new Point(2, 2);
            btn_Start.ShakeDuration = 500;
            btn_Start.ShakeIntensity = 5;
            btn_Start.Size = new Size(149, 37);
            btn_Start.TabIndex = 1;
            btn_Start.Text = "Start";
            btn_Start.TextAlign = ContentAlignment.MiddleCenter;
            btn_Start.TextColor = Color.Black;
            btn_Start.TooltipText = null;
            btn_Start.UseAdvancedRendering = true;
            btn_Start.UseParticles = false;
            btn_Start.Click += btn_Start_Click;
            // 
            // lb_time_counter
            // 
            lb_time_counter.AutoSize = true;
            lb_time_counter.BackColor = Color.Transparent;
            lb_time_counter.Font = new Font("Inter", 33F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_time_counter.Location = new Point(196, 93);
            lb_time_counter.Name = "lb_time_counter";
            lb_time_counter.Size = new Size(195, 79);
            lb_time_counter.TabIndex = 0;
            lb_time_counter.Text = "25:00";
            lb_time_counter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(117, 164, 127);
            panel1.Controls.Add(avatar_btn);
            panel1.Location = new Point(313, 617);
            panel1.Name = "panel1";
            panel1.Size = new Size(230, 151);
            panel1.TabIndex = 2;
            // 
            // avatar_btn
            // 
            avatar_btn.AnimationSpeed = 0.15F;
            avatar_btn.BackColor = Color.Transparent;
            avatar_btn.BackgroundFillColor = Color.Transparent;
            avatar_btn.BadgeAnimationEnabled = true;
            avatar_btn.BadgeAnimationSpeed = 0.15F;
            avatar_btn.BadgeColor = Color.Red;
            avatar_btn.BadgeFont = new Font("Inter", 8F, FontStyle.Bold);
            avatar_btn.BadgePosition = SiticoneNetCoreUI.BadgePosition.TopRight;
            avatar_btn.BadgeTextColor = Color.White;
            avatar_btn.BadgeValue = 0;
            avatar_btn.BorderColor = Color.SeaGreen;
            avatar_btn.BorderThickness = 2;
            avatar_btn.CanBeep = true;
            avatar_btn.CanShake = true;
            avatar_btn.CornerRadiusBottomLeft = 44.5F;
            avatar_btn.CornerRadiusBottomRight = 44.5F;
            avatar_btn.CornerRadiusTopLeft = 44.5F;
            avatar_btn.CornerRadiusTopRight = 44.5F;
            avatar_btn.ImageDown = null;
            avatar_btn.ImageHover = null;
            avatar_btn.ImageNormal = (Image)resources.GetObject("avatar_btn.ImageNormal");
            avatar_btn.ImageSizing = SiticoneNetCoreUI.ImageSizingMode.Stretch;
            avatar_btn.IsReadOnly = false;
            avatar_btn.Location = new Point(69, 21);
            avatar_btn.MakeRadial = true;
            avatar_btn.Name = "avatar_btn";
            avatar_btn.PlaceholderImage = null;
            avatar_btn.RippleColor = Color.FromArgb(50, 0, 0, 0);
            avatar_btn.RippleEnabled = true;
            avatar_btn.Size = new Size(92, 99);
            avatar_btn.SpringEffectEnabled = true;
            avatar_btn.TabIndex = 0;
            avatar_btn.Text = "siticoneImageButton1";
            avatar_btn.TrackSystemTheme = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(117, 164, 127);
            panel3.Controls.Add(siticoneImageButton8);
            panel3.Controls.Add(lblMembersNumber);
            panel3.Location = new Point(844, 618);
            panel3.Name = "panel3";
            panel3.Size = new Size(230, 151);
            panel3.TabIndex = 4;
            // 
            // siticoneImageButton8
            // 
            siticoneImageButton8.AnimationSpeed = 0.15F;
            siticoneImageButton8.BackColor = Color.Transparent;
            siticoneImageButton8.BackgroundFillColor = Color.White;
            siticoneImageButton8.BadgeAnimationEnabled = true;
            siticoneImageButton8.BadgeAnimationSpeed = 0.15F;
            siticoneImageButton8.BadgeColor = Color.Red;
            siticoneImageButton8.BadgeFont = new Font("Inter", 8F, FontStyle.Bold);
            siticoneImageButton8.BadgePosition = SiticoneNetCoreUI.BadgePosition.TopRight;
            siticoneImageButton8.BadgeTextColor = Color.White;
            siticoneImageButton8.BadgeValue = 0;
            siticoneImageButton8.BorderColor = Color.Transparent;
            siticoneImageButton8.BorderThickness = 2;
            siticoneImageButton8.CanBeep = true;
            siticoneImageButton8.CanShake = true;
            siticoneImageButton8.CornerRadiusBottomLeft = 33.5F;
            siticoneImageButton8.CornerRadiusBottomRight = 33.5F;
            siticoneImageButton8.CornerRadiusTopLeft = 33.5F;
            siticoneImageButton8.CornerRadiusTopRight = 33.5F;
            siticoneImageButton8.ImageDown = null;
            siticoneImageButton8.ImageHover = null;
            siticoneImageButton8.ImageNormal = null;
            siticoneImageButton8.ImageSizing = SiticoneNetCoreUI.ImageSizingMode.Original;
            siticoneImageButton8.IsReadOnly = false;
            siticoneImageButton8.Location = new Point(83, 44);
            siticoneImageButton8.MakeRadial = true;
            siticoneImageButton8.Name = "siticoneImageButton8";
            siticoneImageButton8.PlaceholderImage = null;
            siticoneImageButton8.RippleColor = Color.FromArgb(50, 0, 0, 0);
            siticoneImageButton8.RippleEnabled = true;
            siticoneImageButton8.Size = new Size(70, 75);
            siticoneImageButton8.SpringEffectEnabled = true;
            siticoneImageButton8.TabIndex = 13;
            siticoneImageButton8.Text = "siticoneImageButton8";
            siticoneImageButton8.TrackSystemTheme = false;
            // 
            // lblMembersNumber
            // 
            lblMembersNumber.AutoSize = true;
            lblMembersNumber.BackColor = Color.Transparent;
            lblMembersNumber.Font = new Font("Inter", 9.6F);
            lblMembersNumber.Location = new Point(147, 30);
            lblMembersNumber.Name = "lblMembersNumber";
            lblMembersNumber.Size = new Size(21, 23);
            lblMembersNumber.TabIndex = 14;
            lblMembersNumber.Text = "+";
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(117, 164, 127);
            panel6.Controls.Add(btnRoomID);
            panel6.Controls.Add(lb_participant);
            panel6.Location = new Point(3, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(264, 46);
            panel6.TabIndex = 0;
            layoutState1.Location = new Point(3, 3);
            layoutState1.Size = new Size(302, 61);
            layoutState1.Visible = true;
            panel6.Tag = layoutState1;
            // 
            // btnRoomID
            // 
            btnRoomID.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnRoomID.AccessibleName = "";
            btnRoomID.AutoSizeBasedOnText = false;
            btnRoomID.BackColor = Color.Transparent;
            btnRoomID.BackgroundImage = Properties.Resources.group_add;
            btnRoomID.BadgeBackColor = Color.Red;
            btnRoomID.BadgeFont = new Font("Inter", 8F, FontStyle.Bold);
            btnRoomID.BadgeValue = 0;
            btnRoomID.BadgeValueForeColor = Color.Transparent;
            btnRoomID.BorderColor = Color.Transparent;
            btnRoomID.BorderWidth = 2;
            btnRoomID.ButtonBackColor = Color.Transparent;
            btnRoomID.ButtonImage = null;
            btnRoomID.CanBeep = true;
            btnRoomID.CanGlow = false;
            btnRoomID.CanShake = true;
            btnRoomID.ContextMenuStripEx = null;
            btnRoomID.CornerRadiusBottomLeft = 0;
            btnRoomID.CornerRadiusBottomRight = 0;
            btnRoomID.CornerRadiusTopLeft = 0;
            btnRoomID.CornerRadiusTopRight = 0;
            btnRoomID.CustomCursor = Cursors.Default;
            btnRoomID.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnRoomID.EnableLongPress = false;
            btnRoomID.EnablePressAnimation = true;
            btnRoomID.EnableRippleEffect = true;
            btnRoomID.EnableShadow = false;
            btnRoomID.EnableTextWrapping = false;
            btnRoomID.Font = new Font("Inter", 9F);
            btnRoomID.ForeColor = Color.Transparent;
            btnRoomID.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnRoomID.GlowIntensity = 100;
            btnRoomID.GlowRadius = 20F;
            btnRoomID.GradientBackground = false;
            btnRoomID.GradientColor = Color.FromArgb(114, 168, 255);
            btnRoomID.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnRoomID.HintText = null;
            btnRoomID.HoverBackColor = Color.Transparent;
            btnRoomID.HoverFontStyle = FontStyle.Regular;
            btnRoomID.HoverTextColor = Color.White;
            btnRoomID.HoverTransitionDuration = 250;
            btnRoomID.ImageAlign = ContentAlignment.MiddleLeft;
            btnRoomID.ImagePadding = 5;
            btnRoomID.ImageSize = new Size(16, 16);
            btnRoomID.IsRadial = false;
            btnRoomID.IsReadOnly = false;
            btnRoomID.IsToggleButton = false;
            btnRoomID.IsToggled = false;
            btnRoomID.Location = new Point(216, 0);
            btnRoomID.LongPressDurationMS = 1000;
            btnRoomID.Name = "btnRoomID";
            btnRoomID.NormalFontStyle = FontStyle.Regular;
            btnRoomID.ParticleColor = Color.FromArgb(200, 200, 200);
            btnRoomID.ParticleCount = 15;
            btnRoomID.PressAnimationScale = 0.97F;
            btnRoomID.PressedBackColor = Color.Transparent;
            btnRoomID.PressedFontStyle = FontStyle.Regular;
            btnRoomID.PressTransitionDuration = 150;
            btnRoomID.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnRoomID.RippleColor = Color.FromArgb(255, 255, 255);
            btnRoomID.RippleOpacity = 0.3F;
            btnRoomID.RippleRadiusMultiplier = 0.6F;
            btnRoomID.ShadowBlur = 5;
            btnRoomID.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnRoomID.ShadowOffset = new Point(2, 2);
            btnRoomID.ShakeDuration = 500;
            btnRoomID.ShakeIntensity = 5;
            btnRoomID.Size = new Size(45, 40);
            btnRoomID.TabIndex = 52;
            btnRoomID.TextAlign = ContentAlignment.MiddleCenter;
            btnRoomID.TextColor = Color.White;
            btnRoomID.TooltipText = null;
            btnRoomID.UseAdvancedRendering = true;
            btnRoomID.UseParticles = false;
            btnRoomID.Click += btnRoomID_Click_1;
            // 
            // lb_participant
            // 
            lb_participant.BackColor = Color.Transparent;
            lb_participant.Font = new Font("Inter", 11F, FontStyle.Bold);
            lb_participant.Location = new Point(0, 9);
            lb_participant.Name = "lb_participant";
            lb_participant.Size = new Size(145, 28);
            lb_participant.TabIndex = 0;
            lb_participant.Text = "Participants";
            lb_participant.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // participants_panel
            // 
            participants_panel.BackColor = Color.White;
            participants_panel.ColumnCount = 1;
            participants_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            participants_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            participants_panel.Controls.Add(panel6, 0, 0);
            participants_panel.Controls.Add(tb_FindParticipants, 0, 1);
            participants_panel.Controls.Add(listViewParticipants, 0, 2);
            participants_panel.Location = new Point(1121, 100);
            participants_panel.Name = "participants_panel";
            participants_panel.RowCount = 3;
            participants_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 57.77778F));
            participants_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 42.22222F));
            participants_panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 249F));
            participants_panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 19F));
            participants_panel.Size = new Size(270, 340);
            participants_panel.TabIndex = 14;
            // 
            // tb_FindParticipants
            // 
            tb_FindParticipants.AccessibleDescription = "A customizable text input field.";
            tb_FindParticipants.AccessibleName = "Text Box";
            tb_FindParticipants.AccessibleRole = AccessibleRole.Text;
            tb_FindParticipants.BackColor = Color.Transparent;
            tb_FindParticipants.BlinkCount = 3;
            tb_FindParticipants.BlinkShadow = false;
            tb_FindParticipants.BorderColor1 = Color.LightSlateGray;
            tb_FindParticipants.BorderColor2 = Color.LightSlateGray;
            tb_FindParticipants.BorderFocusColor1 = Color.FromArgb(77, 77, 255);
            tb_FindParticipants.BorderFocusColor2 = Color.FromArgb(77, 77, 255);
            tb_FindParticipants.CanShake = true;
            tb_FindParticipants.ContinuousBlink = false;
            tb_FindParticipants.CursorBlinkRate = 500;
            tb_FindParticipants.CursorColor = Color.Black;
            tb_FindParticipants.CursorHeight = 26;
            tb_FindParticipants.CursorOffset = 0;
            tb_FindParticipants.CursorStyle = SiticoneNetCoreUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            tb_FindParticipants.CursorWidth = 1;
            tb_FindParticipants.DisabledBackColor = Color.WhiteSmoke;
            tb_FindParticipants.DisabledBorderColor = Color.LightGray;
            tb_FindParticipants.DisabledTextColor = Color.Gray;
            tb_FindParticipants.EnableDropShadow = false;
            tb_FindParticipants.FillColor1 = Color.White;
            tb_FindParticipants.FillColor2 = Color.White;
            tb_FindParticipants.Font = new Font("Inter", 9.5F);
            tb_FindParticipants.ForeColor = Color.DimGray;
            tb_FindParticipants.HoverBorderColor1 = Color.Gray;
            tb_FindParticipants.HoverBorderColor2 = Color.Gray;
            tb_FindParticipants.IsEnabled = true;
            tb_FindParticipants.Location = new Point(3, 55);
            tb_FindParticipants.Name = "tb_FindParticipants";
            tb_FindParticipants.PlaceholderColor = Color.Gray;
            tb_FindParticipants.PlaceholderText = "Search participants";
            tb_FindParticipants.ReadOnlyBorderColor1 = Color.LightGray;
            tb_FindParticipants.ReadOnlyBorderColor2 = Color.LightGray;
            tb_FindParticipants.ReadOnlyFillColor1 = Color.WhiteSmoke;
            tb_FindParticipants.ReadOnlyFillColor2 = Color.WhiteSmoke;
            tb_FindParticipants.ReadOnlyPlaceholderColor = Color.DarkGray;
            tb_FindParticipants.SelectionBackColor = Color.FromArgb(77, 77, 255);
            tb_FindParticipants.ShadowAnimationDuration = 1;
            tb_FindParticipants.ShadowBlur = 10;
            tb_FindParticipants.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            tb_FindParticipants.Size = new Size(264, 30);
            tb_FindParticipants.SolidBorderColor = Color.LightSlateGray;
            tb_FindParticipants.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            tb_FindParticipants.SolidBorderHoverColor = Color.Gray;
            tb_FindParticipants.SolidFillColor = Color.White;
            tb_FindParticipants.TabIndex = 15;
            tb_FindParticipants.TextPadding = new Padding(16, 0, 6, 0);
            tb_FindParticipants.ValidationErrorMessage = "Invalid input.";
            tb_FindParticipants.ValidationFunction = null;
            // 
            // listViewParticipants
            // 
            listViewParticipants.BackColor = Color.FromArgb(212, 228, 195);
            listViewParticipants.BorderStyle = BorderStyle.None;
            listViewParticipants.Columns.AddRange(new ColumnHeader[] { colAvatar, colName, colMic, colCamera });
            listViewParticipants.FullRowSelect = true;
            listViewParticipants.Location = new Point(3, 93);
            listViewParticipants.Name = "listViewParticipants";
            listViewParticipants.OwnerDraw = true;
            listViewParticipants.Size = new Size(264, 244);
            listViewParticipants.SmallImageList = imageListAvatar;
            listViewParticipants.TabIndex = 15;
            listViewParticipants.UseCompatibleStateImageBehavior = false;
            listViewParticipants.View = System.Windows.Forms.View.Details;
            // 
            // colAvatar
            // 
            colAvatar.Text = "Avatar";
            colAvatar.Width = 40;
            // 
            // colName
            // 
            colName.Text = "Tên";
            colName.Width = 144;
            // 
            // colMic
            // 
            colMic.Text = "Mic";
            colMic.Width = 40;
            // 
            // colCamera
            // 
            colCamera.Text = "Camera";
            colCamera.Width = 40;
            // 
            // imageListAvatar
            // 
            imageListAvatar.ColorDepth = ColorDepth.Depth32Bit;
            imageListAvatar.ImageStream = (ImageListStreamer)resources.GetObject("imageListAvatar.ImageStream");
            imageListAvatar.TransparentColor = Color.Transparent;
            imageListAvatar.Images.SetKeyName(0, "avatar1");
            imageListAvatar.Images.SetKeyName(1, "avatar2");
            imageListAvatar.Images.SetKeyName(2, "avatar3");
            imageListAvatar.Images.SetKeyName(3, "avatar4");
            imageListAvatar.Images.SetKeyName(4, "mic_on");
            imageListAvatar.Images.SetKeyName(5, "cam_off");
            imageListAvatar.Images.SetKeyName(6, "cam_on");
            imageListAvatar.Images.SetKeyName(7, "mic_off");
            // 
            // Ten
            // 
            Ten.Width = 150;
            // 
            // Mic
            // 
            Mic.Width = 40;
            // 
            // Camera
            // 
            Camera.Width = 50;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(117, 164, 127);
            panel7.Controls.Add(siticoneLabel1);
            panel7.Location = new Point(1108, 461);
            panel7.Name = "panel7";
            panel7.Size = new Size(283, 51);
            panel7.TabIndex = 0;
            // 
            // siticoneLabel1
            // 
            siticoneLabel1.BackColor = Color.Transparent;
            siticoneLabel1.Font = new Font("Inter", 11F, FontStyle.Bold);
            siticoneLabel1.Location = new Point(3, 10);
            siticoneLabel1.Name = "siticoneLabel1";
            siticoneLabel1.Size = new Size(68, 28);
            siticoneLabel1.TabIndex = 11;
            siticoneLabel1.Text = "Chat";
            siticoneLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // siticoneImageButton9
            // 
            siticoneImageButton9.AnimationSpeed = 0.15F;
            siticoneImageButton9.BackColor = Color.Transparent;
            siticoneImageButton9.BackgroundFillColor = Color.Transparent;
            siticoneImageButton9.BadgeAnimationEnabled = true;
            siticoneImageButton9.BadgeAnimationSpeed = 0.15F;
            siticoneImageButton9.BadgeColor = Color.Red;
            siticoneImageButton9.BadgeFont = new Font("Inter", 8F, FontStyle.Bold);
            siticoneImageButton9.BadgePosition = SiticoneNetCoreUI.BadgePosition.TopRight;
            siticoneImageButton9.BadgeTextColor = Color.White;
            siticoneImageButton9.BadgeValue = 0;
            siticoneImageButton9.BorderColor = Color.Transparent;
            siticoneImageButton9.BorderThickness = 2;
            siticoneImageButton9.CanBeep = true;
            siticoneImageButton9.CanShake = true;
            siticoneImageButton9.CornerRadiusBottomLeft = 16.5F;
            siticoneImageButton9.CornerRadiusBottomRight = 16.5F;
            siticoneImageButton9.CornerRadiusTopLeft = 16.5F;
            siticoneImageButton9.CornerRadiusTopRight = 16.5F;
            siticoneImageButton9.ImageDown = null;
            siticoneImageButton9.ImageHover = null;
            siticoneImageButton9.ImageNormal = null;
            siticoneImageButton9.ImageSizing = SiticoneNetCoreUI.ImageSizingMode.Original;
            siticoneImageButton9.IsReadOnly = false;
            siticoneImageButton9.Location = new Point(222, 11);
            siticoneImageButton9.MakeRadial = true;
            siticoneImageButton9.Name = "siticoneImageButton9";
            siticoneImageButton9.PlaceholderImage = null;
            siticoneImageButton9.RippleColor = Color.FromArgb(50, 0, 0, 0);
            siticoneImageButton9.RippleEnabled = true;
            siticoneImageButton9.Size = new Size(36, 38);
            siticoneImageButton9.SpringEffectEnabled = true;
            siticoneImageButton9.TabIndex = 14;
            siticoneImageButton9.Text = "siticoneImageButton8";
            siticoneImageButton9.TrackSystemTheme = false;
            // 
            // siticoneLabel2
            // 
            siticoneLabel2.BackColor = Color.Transparent;
            siticoneLabel2.Font = new Font("Inter", 11F, FontStyle.Bold);
            siticoneLabel2.Location = new Point(0, 11);
            siticoneLabel2.Name = "siticoneLabel2";
            siticoneLabel2.Size = new Size(92, 28);
            siticoneLabel2.TabIndex = 0;
            siticoneLabel2.Text = "Chat";
            siticoneLabel2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // sbtn_ChangeHost
            // 
            sbtn_ChangeHost.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            sbtn_ChangeHost.AccessibleName = "";
            sbtn_ChangeHost.AutoSizeBasedOnText = false;
            sbtn_ChangeHost.BackColor = Color.Transparent;
            sbtn_ChangeHost.BackgroundImage = Properties.Resources.change_host1;
            sbtn_ChangeHost.BadgeBackColor = Color.Transparent;
            sbtn_ChangeHost.BadgeFont = new Font("Inter", 8F, FontStyle.Bold);
            sbtn_ChangeHost.BadgeValue = 0;
            sbtn_ChangeHost.BadgeValueForeColor = Color.White;
            sbtn_ChangeHost.BorderColor = Color.Transparent;
            sbtn_ChangeHost.BorderWidth = 2;
            sbtn_ChangeHost.ButtonBackColor = Color.Transparent;
            sbtn_ChangeHost.ButtonImage = null;
            sbtn_ChangeHost.CanBeep = true;
            sbtn_ChangeHost.CanGlow = false;
            sbtn_ChangeHost.CanShake = true;
            sbtn_ChangeHost.ContextMenuStripEx = null;
            sbtn_ChangeHost.CornerRadiusBottomLeft = 10;
            sbtn_ChangeHost.CornerRadiusBottomRight = 10;
            sbtn_ChangeHost.CornerRadiusTopLeft = 10;
            sbtn_ChangeHost.CornerRadiusTopRight = 10;
            sbtn_ChangeHost.CustomCursor = Cursors.Default;
            sbtn_ChangeHost.DisabledTextColor = Color.FromArgb(150, 150, 150);
            sbtn_ChangeHost.EnableLongPress = false;
            sbtn_ChangeHost.EnablePressAnimation = true;
            sbtn_ChangeHost.EnableRippleEffect = true;
            sbtn_ChangeHost.EnableShadow = false;
            sbtn_ChangeHost.EnableTextWrapping = false;
            sbtn_ChangeHost.Font = new Font("Inter", 9F);
            sbtn_ChangeHost.GlowColor = Color.FromArgb(100, 255, 255, 255);
            sbtn_ChangeHost.GlowIntensity = 100;
            sbtn_ChangeHost.GlowRadius = 20F;
            sbtn_ChangeHost.GradientBackground = false;
            sbtn_ChangeHost.GradientColor = Color.Transparent;
            sbtn_ChangeHost.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            sbtn_ChangeHost.HintText = null;
            sbtn_ChangeHost.HoverBackColor = Color.Transparent;
            sbtn_ChangeHost.HoverFontStyle = FontStyle.Regular;
            sbtn_ChangeHost.HoverTextColor = Color.White;
            sbtn_ChangeHost.HoverTransitionDuration = 250;
            sbtn_ChangeHost.ImageAlign = ContentAlignment.MiddleLeft;
            sbtn_ChangeHost.ImagePadding = 5;
            sbtn_ChangeHost.ImageSize = new Size(16, 16);
            sbtn_ChangeHost.IsRadial = false;
            sbtn_ChangeHost.IsReadOnly = false;
            sbtn_ChangeHost.IsToggleButton = false;
            sbtn_ChangeHost.IsToggled = false;
            sbtn_ChangeHost.Location = new Point(366, 822);
            sbtn_ChangeHost.LongPressDurationMS = 1000;
            sbtn_ChangeHost.Name = "sbtn_ChangeHost";
            sbtn_ChangeHost.NormalFontStyle = FontStyle.Regular;
            sbtn_ChangeHost.ParticleColor = Color.FromArgb(200, 200, 200);
            sbtn_ChangeHost.ParticleCount = 15;
            sbtn_ChangeHost.PressAnimationScale = 0.97F;
            sbtn_ChangeHost.PressedBackColor = Color.Transparent;
            sbtn_ChangeHost.PressedFontStyle = FontStyle.Regular;
            sbtn_ChangeHost.PressTransitionDuration = 150;
            sbtn_ChangeHost.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            sbtn_ChangeHost.RippleColor = Color.FromArgb(255, 255, 255);
            sbtn_ChangeHost.RippleOpacity = 0.3F;
            sbtn_ChangeHost.RippleRadiusMultiplier = 0.6F;
            sbtn_ChangeHost.ShadowBlur = 5;
            sbtn_ChangeHost.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            sbtn_ChangeHost.ShadowOffset = new Point(2, 2);
            sbtn_ChangeHost.ShakeDuration = 500;
            sbtn_ChangeHost.ShakeIntensity = 5;
            sbtn_ChangeHost.Size = new Size(72, 53);
            sbtn_ChangeHost.TabIndex = 33;
            sbtn_ChangeHost.TextAlign = ContentAlignment.MiddleCenter;
            sbtn_ChangeHost.TextColor = Color.White;
            sbtn_ChangeHost.TooltipText = null;
            sbtn_ChangeHost.UseAdvancedRendering = true;
            sbtn_ChangeHost.UseParticles = false;
            sbtn_ChangeHost.Click += sbtn_ChangeHost_Click;
            // 
            // sbtn_CancelCall
            // 
            sbtn_CancelCall.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            sbtn_CancelCall.AccessibleName = "";
            sbtn_CancelCall.AutoSizeBasedOnText = false;
            sbtn_CancelCall.BackColor = Color.Transparent;
            sbtn_CancelCall.BackgroundImage = Properties.Resources.cancel_end;
            sbtn_CancelCall.BadgeBackColor = Color.Transparent;
            sbtn_CancelCall.BadgeFont = new Font("Inter", 8F, FontStyle.Bold);
            sbtn_CancelCall.BadgeValue = 0;
            sbtn_CancelCall.BadgeValueForeColor = Color.White;
            sbtn_CancelCall.BorderColor = Color.Transparent;
            sbtn_CancelCall.BorderWidth = 2;
            sbtn_CancelCall.ButtonBackColor = Color.Transparent;
            sbtn_CancelCall.ButtonImage = null;
            sbtn_CancelCall.CanBeep = true;
            sbtn_CancelCall.CanGlow = false;
            sbtn_CancelCall.CanShake = true;
            sbtn_CancelCall.ContextMenuStripEx = null;
            sbtn_CancelCall.CornerRadiusBottomLeft = 10;
            sbtn_CancelCall.CornerRadiusBottomRight = 10;
            sbtn_CancelCall.CornerRadiusTopLeft = 10;
            sbtn_CancelCall.CornerRadiusTopRight = 10;
            sbtn_CancelCall.CustomCursor = Cursors.Default;
            sbtn_CancelCall.DisabledTextColor = Color.FromArgb(150, 150, 150);
            sbtn_CancelCall.EnableLongPress = false;
            sbtn_CancelCall.EnablePressAnimation = true;
            sbtn_CancelCall.EnableRippleEffect = true;
            sbtn_CancelCall.EnableShadow = false;
            sbtn_CancelCall.EnableTextWrapping = false;
            sbtn_CancelCall.Font = new Font("Inter", 9F);
            sbtn_CancelCall.GlowColor = Color.FromArgb(100, 255, 255, 255);
            sbtn_CancelCall.GlowIntensity = 100;
            sbtn_CancelCall.GlowRadius = 20F;
            sbtn_CancelCall.GradientBackground = false;
            sbtn_CancelCall.GradientColor = Color.Transparent;
            sbtn_CancelCall.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            sbtn_CancelCall.HintText = null;
            sbtn_CancelCall.HoverBackColor = Color.Transparent;
            sbtn_CancelCall.HoverFontStyle = FontStyle.Regular;
            sbtn_CancelCall.HoverTextColor = Color.White;
            sbtn_CancelCall.HoverTransitionDuration = 250;
            sbtn_CancelCall.ImageAlign = ContentAlignment.MiddleLeft;
            sbtn_CancelCall.ImagePadding = 5;
            sbtn_CancelCall.ImageSize = new Size(16, 16);
            sbtn_CancelCall.IsRadial = false;
            sbtn_CancelCall.IsReadOnly = false;
            sbtn_CancelCall.IsToggleButton = false;
            sbtn_CancelCall.IsToggled = false;
            sbtn_CancelCall.Location = new Point(949, 822);
            sbtn_CancelCall.LongPressDurationMS = 1000;
            sbtn_CancelCall.Name = "sbtn_CancelCall";
            sbtn_CancelCall.NormalFontStyle = FontStyle.Regular;
            sbtn_CancelCall.ParticleColor = Color.FromArgb(200, 200, 200);
            sbtn_CancelCall.ParticleCount = 15;
            sbtn_CancelCall.PressAnimationScale = 0.97F;
            sbtn_CancelCall.PressedBackColor = Color.Transparent;
            sbtn_CancelCall.PressedFontStyle = FontStyle.Regular;
            sbtn_CancelCall.PressTransitionDuration = 150;
            sbtn_CancelCall.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            sbtn_CancelCall.RippleColor = Color.FromArgb(255, 255, 255);
            sbtn_CancelCall.RippleOpacity = 0.3F;
            sbtn_CancelCall.RippleRadiusMultiplier = 0.6F;
            sbtn_CancelCall.ShadowBlur = 5;
            sbtn_CancelCall.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            sbtn_CancelCall.ShadowOffset = new Point(2, 2);
            sbtn_CancelCall.ShakeDuration = 500;
            sbtn_CancelCall.ShakeIntensity = 5;
            sbtn_CancelCall.Size = new Size(72, 53);
            sbtn_CancelCall.TabIndex = 34;
            sbtn_CancelCall.TextAlign = ContentAlignment.MiddleCenter;
            sbtn_CancelCall.TextColor = Color.White;
            sbtn_CancelCall.TooltipText = null;
            sbtn_CancelCall.UseAdvancedRendering = true;
            sbtn_CancelCall.UseParticles = false;
            sbtn_CancelCall.Click += sbtn_CancelCall_Click;
            // 
            // siticonePanel1
            // 
            siticonePanel1.AcrylicTintColor = Color.Transparent;
            siticonePanel1.BackColor = Color.Transparent;
            siticonePanel1.BackgroundImage = Properties.Resources.panel;
            siticonePanel1.BackgroundImageLayout = ImageLayout.None;
            siticonePanel1.BorderAlignment = System.Drawing.Drawing2D.PenAlignment.Center;
            siticonePanel1.BorderDashPattern = null;
            siticonePanel1.BorderGradientEndColor = Color.Purple;
            siticonePanel1.BorderGradientStartColor = Color.Blue;
            siticonePanel1.BorderThickness = 2F;
            siticonePanel1.Controls.Add(btn_Speaker);
            siticonePanel1.Controls.Add(btn_Camera);
            siticonePanel1.Controls.Add(btn_Mic);
            siticonePanel1.CornerRadiusBottomLeft = 10F;
            siticonePanel1.CornerRadiusBottomRight = 10F;
            siticonePanel1.CornerRadiusTopLeft = 10F;
            siticonePanel1.CornerRadiusTopRight = 10F;
            siticonePanel1.EnableAcrylicEffect = false;
            siticonePanel1.EnableMicaEffect = false;
            siticonePanel1.EnableRippleEffect = false;
            siticonePanel1.FillColor = Color.Transparent;
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
            siticonePanel1.Location = new Point(480, 822);
            siticonePanel1.Name = "siticonePanel1";
            siticonePanel1.PatternStyle = System.Drawing.Drawing2D.HatchStyle.Max;
            siticonePanel1.RippleAlpha = 50;
            siticonePanel1.RippleAlphaDecrement = 3;
            siticonePanel1.RippleColor = Color.FromArgb(50, 255, 255, 255);
            siticonePanel1.RippleMaxSize = 600F;
            siticonePanel1.RippleSpeed = 15F;
            siticonePanel1.ShowBorder = false;
            siticonePanel1.Size = new Size(416, 58);
            siticonePanel1.TabIndex = 35;
            siticonePanel1.TabStop = true;
            siticonePanel1.UseBorderGradient = false;
            siticonePanel1.UseMultiGradient = false;
            siticonePanel1.UsePatternTexture = false;
            siticonePanel1.UseRadialGradient = false;
            // 
            // btn_Speaker
            // 
            btn_Speaker.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btn_Speaker.AccessibleName = "";
            btn_Speaker.AutoSizeBasedOnText = false;
            btn_Speaker.BackColor = Color.Transparent;
            btn_Speaker.BackgroundImage = Properties.Resources.icon_sound_on;
            btn_Speaker.BadgeBackColor = Color.Red;
            btn_Speaker.BadgeFont = new Font("Inter", 8F, FontStyle.Bold);
            btn_Speaker.BadgeValue = 0;
            btn_Speaker.BadgeValueForeColor = Color.White;
            btn_Speaker.BorderColor = Color.Transparent;
            btn_Speaker.BorderWidth = 2;
            btn_Speaker.ButtonBackColor = Color.Transparent;
            btn_Speaker.ButtonImage = null;
            btn_Speaker.CanBeep = true;
            btn_Speaker.CanGlow = false;
            btn_Speaker.CanShake = true;
            btn_Speaker.ContextMenuStripEx = null;
            btn_Speaker.CornerRadiusBottomLeft = 0;
            btn_Speaker.CornerRadiusBottomRight = 0;
            btn_Speaker.CornerRadiusTopLeft = 0;
            btn_Speaker.CornerRadiusTopRight = 0;
            btn_Speaker.CustomCursor = Cursors.Default;
            btn_Speaker.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btn_Speaker.EnableLongPress = false;
            btn_Speaker.EnablePressAnimation = true;
            btn_Speaker.EnableRippleEffect = true;
            btn_Speaker.EnableShadow = false;
            btn_Speaker.EnableTextWrapping = false;
            btn_Speaker.Font = new Font("Inter", 9F);
            btn_Speaker.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btn_Speaker.GlowIntensity = 100;
            btn_Speaker.GlowRadius = 20F;
            btn_Speaker.GradientBackground = false;
            btn_Speaker.GradientColor = Color.Transparent;
            btn_Speaker.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btn_Speaker.HintText = null;
            btn_Speaker.HoverBackColor = Color.Transparent;
            btn_Speaker.HoverFontStyle = FontStyle.Regular;
            btn_Speaker.HoverTextColor = Color.White;
            btn_Speaker.HoverTransitionDuration = 250;
            btn_Speaker.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Speaker.ImagePadding = 5;
            btn_Speaker.ImageSize = new Size(16, 16);
            btn_Speaker.IsRadial = false;
            btn_Speaker.IsReadOnly = false;
            btn_Speaker.IsToggleButton = false;
            btn_Speaker.IsToggled = false;
            btn_Speaker.Location = new Point(350, 14);
            btn_Speaker.LongPressDurationMS = 1000;
            btn_Speaker.Name = "btn_Speaker";
            btn_Speaker.NormalFontStyle = FontStyle.Regular;
            btn_Speaker.ParticleColor = Color.FromArgb(200, 200, 200);
            btn_Speaker.ParticleCount = 15;
            btn_Speaker.PressAnimationScale = 0.97F;
            btn_Speaker.PressedBackColor = Color.Transparent;
            btn_Speaker.PressedFontStyle = FontStyle.Regular;
            btn_Speaker.PressTransitionDuration = 150;
            btn_Speaker.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btn_Speaker.RippleColor = Color.FromArgb(255, 255, 255);
            btn_Speaker.RippleOpacity = 0.3F;
            btn_Speaker.RippleRadiusMultiplier = 0.6F;
            btn_Speaker.ShadowBlur = 5;
            btn_Speaker.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btn_Speaker.ShadowOffset = new Point(2, 2);
            btn_Speaker.ShakeDuration = 500;
            btn_Speaker.ShakeIntensity = 5;
            btn_Speaker.Size = new Size(32, 30);
            btn_Speaker.TabIndex = 2;
            btn_Speaker.TextAlign = ContentAlignment.MiddleCenter;
            btn_Speaker.TextColor = Color.White;
            btn_Speaker.TooltipText = null;
            btn_Speaker.UseAdvancedRendering = true;
            btn_Speaker.UseParticles = false;
            btn_Speaker.Click += btn_Speaker_Click;
            // 
            // btn_Camera
            // 
            btn_Camera.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btn_Camera.AccessibleName = "";
            btn_Camera.AutoSizeBasedOnText = false;
            btn_Camera.BackColor = Color.Transparent;
            btn_Camera.BackgroundImage = Properties.Resources.videocam;
            btn_Camera.BadgeBackColor = Color.Red;
            btn_Camera.BadgeFont = new Font("Inter", 8F, FontStyle.Bold);
            btn_Camera.BadgeValue = 0;
            btn_Camera.BadgeValueForeColor = Color.White;
            btn_Camera.BorderColor = Color.Transparent;
            btn_Camera.BorderWidth = 2;
            btn_Camera.ButtonBackColor = Color.Transparent;
            btn_Camera.ButtonImage = null;
            btn_Camera.CanBeep = true;
            btn_Camera.CanGlow = false;
            btn_Camera.CanShake = true;
            btn_Camera.ContextMenuStripEx = null;
            btn_Camera.CornerRadiusBottomLeft = 0;
            btn_Camera.CornerRadiusBottomRight = 0;
            btn_Camera.CornerRadiusTopLeft = 0;
            btn_Camera.CornerRadiusTopRight = 0;
            btn_Camera.CustomCursor = Cursors.Default;
            btn_Camera.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btn_Camera.EnableLongPress = false;
            btn_Camera.EnablePressAnimation = true;
            btn_Camera.EnableRippleEffect = true;
            btn_Camera.EnableShadow = false;
            btn_Camera.EnableTextWrapping = false;
            btn_Camera.Font = new Font("Inter", 9F);
            btn_Camera.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btn_Camera.GlowIntensity = 100;
            btn_Camera.GlowRadius = 20F;
            btn_Camera.GradientBackground = false;
            btn_Camera.GradientColor = Color.Transparent;
            btn_Camera.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btn_Camera.HintText = null;
            btn_Camera.HoverBackColor = Color.Transparent;
            btn_Camera.HoverFontStyle = FontStyle.Regular;
            btn_Camera.HoverTextColor = Color.White;
            btn_Camera.HoverTransitionDuration = 250;
            btn_Camera.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Camera.ImagePadding = 5;
            btn_Camera.ImageSize = new Size(16, 16);
            btn_Camera.IsRadial = false;
            btn_Camera.IsReadOnly = false;
            btn_Camera.IsToggleButton = false;
            btn_Camera.IsToggled = false;
            btn_Camera.Location = new Point(193, 10);
            btn_Camera.LongPressDurationMS = 1000;
            btn_Camera.Name = "btn_Camera";
            btn_Camera.NormalFontStyle = FontStyle.Regular;
            btn_Camera.ParticleColor = Color.FromArgb(200, 200, 200);
            btn_Camera.ParticleCount = 15;
            btn_Camera.PressAnimationScale = 0.97F;
            btn_Camera.PressedBackColor = Color.Transparent;
            btn_Camera.PressedFontStyle = FontStyle.Regular;
            btn_Camera.PressTransitionDuration = 150;
            btn_Camera.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btn_Camera.RippleColor = Color.FromArgb(255, 255, 255);
            btn_Camera.RippleOpacity = 0.3F;
            btn_Camera.RippleRadiusMultiplier = 0.6F;
            btn_Camera.ShadowBlur = 5;
            btn_Camera.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btn_Camera.ShadowOffset = new Point(2, 2);
            btn_Camera.ShakeDuration = 500;
            btn_Camera.ShakeIntensity = 5;
            btn_Camera.Size = new Size(40, 40);
            btn_Camera.TabIndex = 1;
            btn_Camera.TextAlign = ContentAlignment.MiddleCenter;
            btn_Camera.TextColor = Color.White;
            btn_Camera.TooltipText = null;
            btn_Camera.UseAdvancedRendering = true;
            btn_Camera.UseParticles = false;
            btn_Camera.Click += btn_Camera_Click;
            // 
            // btn_Mic
            // 
            btn_Mic.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btn_Mic.AccessibleName = "";
            btn_Mic.AutoSizeBasedOnText = false;
            btn_Mic.BackColor = Color.Transparent;
            btn_Mic.BackgroundImage = Properties.Resources.videomic_off;
            btn_Mic.BadgeBackColor = Color.Red;
            btn_Mic.BadgeFont = new Font("Inter", 8F, FontStyle.Bold);
            btn_Mic.BadgeValue = 0;
            btn_Mic.BadgeValueForeColor = Color.White;
            btn_Mic.BorderColor = Color.Transparent;
            btn_Mic.BorderWidth = 2;
            btn_Mic.ButtonBackColor = Color.Transparent;
            btn_Mic.ButtonImage = null;
            btn_Mic.CanBeep = true;
            btn_Mic.CanGlow = false;
            btn_Mic.CanShake = true;
            btn_Mic.ContextMenuStripEx = null;
            btn_Mic.CornerRadiusBottomLeft = 0;
            btn_Mic.CornerRadiusBottomRight = 0;
            btn_Mic.CornerRadiusTopLeft = 0;
            btn_Mic.CornerRadiusTopRight = 0;
            btn_Mic.CustomCursor = Cursors.Default;
            btn_Mic.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btn_Mic.EnableLongPress = false;
            btn_Mic.EnablePressAnimation = true;
            btn_Mic.EnableRippleEffect = true;
            btn_Mic.EnableShadow = false;
            btn_Mic.EnableTextWrapping = false;
            btn_Mic.Font = new Font("Inter", 9F);
            btn_Mic.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btn_Mic.GlowIntensity = 100;
            btn_Mic.GlowRadius = 20F;
            btn_Mic.GradientBackground = false;
            btn_Mic.GradientColor = Color.Transparent;
            btn_Mic.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btn_Mic.HintText = null;
            btn_Mic.HoverBackColor = Color.Transparent;
            btn_Mic.HoverFontStyle = FontStyle.Regular;
            btn_Mic.HoverTextColor = Color.White;
            btn_Mic.HoverTransitionDuration = 250;
            btn_Mic.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Mic.ImagePadding = 5;
            btn_Mic.ImageSize = new Size(16, 16);
            btn_Mic.IsRadial = false;
            btn_Mic.IsReadOnly = false;
            btn_Mic.IsToggleButton = false;
            btn_Mic.IsToggled = false;
            btn_Mic.Location = new Point(47, 10);
            btn_Mic.LongPressDurationMS = 1000;
            btn_Mic.Name = "btn_Mic";
            btn_Mic.NormalFontStyle = FontStyle.Regular;
            btn_Mic.ParticleColor = Color.FromArgb(200, 200, 200);
            btn_Mic.ParticleCount = 15;
            btn_Mic.PressAnimationScale = 0.97F;
            btn_Mic.PressedBackColor = Color.Transparent;
            btn_Mic.PressedFontStyle = FontStyle.Regular;
            btn_Mic.PressTransitionDuration = 150;
            btn_Mic.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btn_Mic.RippleColor = Color.FromArgb(255, 255, 255);
            btn_Mic.RippleOpacity = 0.3F;
            btn_Mic.RippleRadiusMultiplier = 0.6F;
            btn_Mic.ShadowBlur = 5;
            btn_Mic.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btn_Mic.ShadowOffset = new Point(2, 2);
            btn_Mic.ShakeDuration = 500;
            btn_Mic.ShakeIntensity = 5;
            btn_Mic.Size = new Size(40, 40);
            btn_Mic.TabIndex = 0;
            btn_Mic.TextAlign = ContentAlignment.MiddleCenter;
            btn_Mic.TextColor = Color.White;
            btn_Mic.TooltipText = null;
            btn_Mic.UseAdvancedRendering = true;
            btn_Mic.UseParticles = false;
            btn_Mic.Click += btn_Mic_Click;
            // 
            // userProfilePanel1
            // 
            userProfilePanel1.BackColor = Color.Transparent;
            userProfilePanel1.Location = new Point(1118, 12);
            userProfilePanel1.Name = "userProfilePanel1";
            userProfilePanel1.Size = new Size(312, 75);
            userProfilePanel1.TabIndex = 36;
            // 
            // siticoneImageButton1
            // 
            siticoneImageButton1.AnimationSpeed = 0.15F;
            siticoneImageButton1.BackColor = Color.Transparent;
            siticoneImageButton1.BackgroundFillColor = Color.Transparent;
            siticoneImageButton1.BadgeAnimationEnabled = true;
            siticoneImageButton1.BadgeAnimationSpeed = 0.15F;
            siticoneImageButton1.BadgeColor = Color.Red;
            siticoneImageButton1.BadgeFont = new Font("Inter", 8F, FontStyle.Bold);
            siticoneImageButton1.BadgePosition = SiticoneNetCoreUI.BadgePosition.TopRight;
            siticoneImageButton1.BadgeTextColor = Color.White;
            siticoneImageButton1.BadgeValue = 0;
            siticoneImageButton1.BorderColor = Color.SeaGreen;
            siticoneImageButton1.BorderThickness = 2;
            siticoneImageButton1.CanBeep = true;
            siticoneImageButton1.CanShake = true;
            siticoneImageButton1.CornerRadiusBottomLeft = 44.5F;
            siticoneImageButton1.CornerRadiusBottomRight = 44.5F;
            siticoneImageButton1.CornerRadiusTopLeft = 44.5F;
            siticoneImageButton1.CornerRadiusTopRight = 44.5F;
            siticoneImageButton1.ImageDown = null;
            siticoneImageButton1.ImageHover = null;
            siticoneImageButton1.ImageNormal = (Image)resources.GetObject("siticoneImageButton1.ImageNormal");
            siticoneImageButton1.ImageSizing = SiticoneNetCoreUI.ImageSizingMode.Stretch;
            siticoneImageButton1.IsReadOnly = false;
            siticoneImageButton1.Location = new Point(71, 31);
            siticoneImageButton1.MakeRadial = true;
            siticoneImageButton1.Name = "siticoneImageButton1";
            siticoneImageButton1.PlaceholderImage = null;
            siticoneImageButton1.RippleColor = Color.FromArgb(50, 0, 0, 0);
            siticoneImageButton1.RippleEnabled = true;
            siticoneImageButton1.Size = new Size(92, 99);
            siticoneImageButton1.SpringEffectEnabled = true;
            siticoneImageButton1.TabIndex = 0;
            siticoneImageButton1.Text = "siticoneImageButton1";
            siticoneImageButton1.TrackSystemTheme = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(117, 164, 127);
            panel2.Controls.Add(siticoneImageButton1);
            panel2.Location = new Point(578, 617);
            panel2.Name = "panel2";
            panel2.Size = new Size(230, 151);
            panel2.TabIndex = 4;
            // 
            // tbMessages
            // 
            tbMessages.AccessibleDescription = "A customizable text input field.";
            tbMessages.AccessibleName = "Text Box";
            tbMessages.AccessibleRole = AccessibleRole.Text;
            tbMessages.BackColor = Color.Transparent;
            tbMessages.BlinkCount = 3;
            tbMessages.BlinkShadow = false;
            tbMessages.BorderColor1 = Color.LightSlateGray;
            tbMessages.BorderColor2 = Color.LightSlateGray;
            tbMessages.BorderFocusColor1 = Color.FromArgb(77, 77, 255);
            tbMessages.BorderFocusColor2 = Color.FromArgb(77, 77, 255);
            tbMessages.CanShake = true;
            tbMessages.ContinuousBlink = false;
            tbMessages.CursorBlinkRate = 500;
            tbMessages.CursorColor = Color.Black;
            tbMessages.CursorHeight = 26;
            tbMessages.CursorOffset = 0;
            tbMessages.CursorStyle = SiticoneNetCoreUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            tbMessages.CursorWidth = 1;
            tbMessages.DisabledBackColor = Color.WhiteSmoke;
            tbMessages.DisabledBorderColor = Color.LightGray;
            tbMessages.DisabledTextColor = Color.Gray;
            tbMessages.EnableDropShadow = false;
            tbMessages.FillColor1 = Color.FromArgb(212, 228, 195);
            tbMessages.FillColor2 = Color.FromArgb(212, 228, 195);
            tbMessages.Font = new Font("Inter", 9.5F);
            tbMessages.ForeColor = Color.DimGray;
            tbMessages.HoverBorderColor1 = Color.Gray;
            tbMessages.HoverBorderColor2 = Color.Gray;
            tbMessages.IsEnabled = true;
            tbMessages.Location = new Point(1124, 850);
            tbMessages.Name = "tbMessages";
            tbMessages.PlaceholderColor = Color.Gray;
            tbMessages.PlaceholderText = "Nhập tin nhắn...";
            tbMessages.ReadOnlyBorderColor1 = Color.LightGray;
            tbMessages.ReadOnlyBorderColor2 = Color.LightGray;
            tbMessages.ReadOnlyFillColor1 = Color.WhiteSmoke;
            tbMessages.ReadOnlyFillColor2 = Color.WhiteSmoke;
            tbMessages.ReadOnlyPlaceholderColor = Color.DarkGray;
            tbMessages.SelectionBackColor = Color.FromArgb(77, 77, 255);
            tbMessages.ShadowAnimationDuration = 1;
            tbMessages.ShadowBlur = 10;
            tbMessages.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            tbMessages.Size = new Size(245, 43);
            tbMessages.SolidBorderColor = Color.LightSlateGray;
            tbMessages.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            tbMessages.SolidBorderHoverColor = Color.Gray;
            tbMessages.SolidFillColor = Color.White;
            tbMessages.TabIndex = 39;
            tbMessages.TextPadding = new Padding(16, 0, 6, 0);
            tbMessages.ValidationErrorMessage = "Invalid input.";
            tbMessages.ValidationFunction = null;
            // 
            // tbDisplayMsg
            // 
            tbDisplayMsg.BackColor = Color.FromArgb(212, 228, 195);
            tbDisplayMsg.Location = new Point(1108, 518);
            tbDisplayMsg.Name = "tbDisplayMsg";
            tbDisplayMsg.ReadOnly = true;
            tbDisplayMsg.ScrollBars = RichTextBoxScrollBars.Vertical;
            tbDisplayMsg.Size = new Size(284, 400);
            tbDisplayMsg.TabIndex = 40;
            tbDisplayMsg.TabStop = false;
            tbDisplayMsg.Text = "";
            // 
            // btn_Break
            // 
            btn_Break.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btn_Break.AccessibleName = "Break";
            btn_Break.AutoSizeBasedOnText = false;
            btn_Break.BackColor = Color.Transparent;
            btn_Break.BadgeBackColor = Color.DarkSeaGreen;
            btn_Break.BadgeFont = new Font("Inter", 8F, FontStyle.Bold);
            btn_Break.BadgeValue = 0;
            btn_Break.BadgeValueForeColor = Color.White;
            btn_Break.BorderColor = Color.DarkSeaGreen;
            btn_Break.BorderWidth = 2;
            btn_Break.ButtonBackColor = Color.DarkSeaGreen;
            btn_Break.ButtonImage = null;
            btn_Break.CanBeep = true;
            btn_Break.CanGlow = false;
            btn_Break.CanShake = true;
            btn_Break.ContextMenuStripEx = null;
            btn_Break.CornerRadiusBottomLeft = 0;
            btn_Break.CornerRadiusBottomRight = 0;
            btn_Break.CornerRadiusTopLeft = 0;
            btn_Break.CornerRadiusTopRight = 0;
            btn_Break.CustomCursor = Cursors.Default;
            btn_Break.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btn_Break.EnableLongPress = false;
            btn_Break.EnablePressAnimation = true;
            btn_Break.EnableRippleEffect = true;
            btn_Break.EnableShadow = false;
            btn_Break.EnableTextWrapping = false;
            btn_Break.Font = new Font("Inter", 10F);
            btn_Break.ForeColor = SystemColors.ActiveCaptionText;
            btn_Break.GlowColor = Color.FromArgb(0, 64, 0);
            btn_Break.GlowIntensity = 100;
            btn_Break.GlowRadius = 20F;
            btn_Break.GradientBackground = false;
            btn_Break.GradientColor = Color.FromArgb(114, 168, 255);
            btn_Break.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btn_Break.HintText = null;
            btn_Break.HoverBackColor = Color.DarkSeaGreen;
            btn_Break.HoverFontStyle = FontStyle.Regular;
            btn_Break.HoverTextColor = Color.White;
            btn_Break.HoverTransitionDuration = 250;
            btn_Break.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Break.ImagePadding = 5;
            btn_Break.ImageSize = new Size(16, 16);
            btn_Break.IsRadial = false;
            btn_Break.IsReadOnly = false;
            btn_Break.IsToggleButton = false;
            btn_Break.IsToggled = false;
            btn_Break.Location = new Point(311, 24);
            btn_Break.LongPressDurationMS = 1000;
            btn_Break.Name = "btn_Break";
            btn_Break.NormalFontStyle = FontStyle.Regular;
            btn_Break.ParticleColor = Color.FromArgb(200, 200, 200);
            btn_Break.ParticleCount = 15;
            btn_Break.PressAnimationScale = 0.97F;
            btn_Break.PressedBackColor = Color.ForestGreen;
            btn_Break.PressedFontStyle = FontStyle.Regular;
            btn_Break.PressTransitionDuration = 150;
            btn_Break.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btn_Break.RippleColor = Color.FromArgb(255, 255, 255);
            btn_Break.RippleOpacity = 0.3F;
            btn_Break.RippleRadiusMultiplier = 0.6F;
            btn_Break.ShadowBlur = 5;
            btn_Break.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btn_Break.ShadowOffset = new Point(2, 2);
            btn_Break.ShakeDuration = 500;
            btn_Break.ShakeIntensity = 5;
            btn_Break.Size = new Size(92, 32);
            btn_Break.TabIndex = 41;
            btn_Break.Text = "Break";
            btn_Break.TextAlign = ContentAlignment.MiddleCenter;
            btn_Break.TextColor = Color.Black;
            btn_Break.TooltipText = null;
            btn_Break.UseAdvancedRendering = true;
            btn_Break.UseParticles = false;
            btn_Break.Click += btn_Break_Click;
            // 
            // lb_CurrentTime
            // 
            lb_CurrentTime.AutoSize = true;
            lb_CurrentTime.Location = new Point(512, 307);
            lb_CurrentTime.Name = "lb_CurrentTime";
            lb_CurrentTime.Size = new Size(13, 20);
            lb_CurrentTime.TabIndex = 43;
            lb_CurrentTime.Text = " ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(554, 307);
            label1.Name = "label1";
            label1.Size = new Size(15, 20);
            label1.TabIndex = 44;
            label1.Text = "/";
            // 
            // lb_TotalTime
            // 
            lb_TotalTime.AutoSize = true;
            lb_TotalTime.Location = new Point(575, 307);
            lb_TotalTime.Name = "lb_TotalTime";
            lb_TotalTime.Size = new Size(13, 20);
            lb_TotalTime.TabIndex = 45;
            lb_TotalTime.Text = " ";
            // 
            // pn_Background
            // 
            pn_Background.AutoSize = true;
            pn_Background.BackColor = Color.Transparent;
            pn_Background.BackgroundImage = Properties.Resources.studyBackground1;
            pn_Background.BackgroundImageLayout = ImageLayout.Stretch;
            pn_Background.Controls.Add(btn_Reset);
            pn_Background.Controls.Add(panel4);
            pn_Background.Location = new Point(351, 100);
            pn_Background.Name = "pn_Background";
            pn_Background.Size = new Size(723, 451);
            pn_Background.TabIndex = 48;
            // 
            // panel4
            // 
            panel4.BackgroundImage = Properties.Resources.transparent;
            panel4.Controls.Add(btn_Break);
            panel4.Controls.Add(btn_pomodoro);
            panel4.Controls.Add(lb_TotalTime);
            panel4.Controls.Add(lb_CurrentTime);
            panel4.Controls.Add(ProgressBarMusic);
            panel4.Controls.Add(btn_Start);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(lb_time_counter);
            panel4.Location = new Point(69, 43);
            panel4.Name = "panel4";
            panel4.Size = new Size(622, 354);
            panel4.TabIndex = 46;
            panel4.Paint += panel4_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 62);
            pictureBox1.TabIndex = 46;
            pictureBox1.TabStop = false;
            // 
            // btnSendMessages
            // 
            btnSendMessages.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnSendMessages.AccessibleName = "";
            btnSendMessages.AutoSizeBasedOnText = false;
            btnSendMessages.BackColor = Color.Transparent;
            btnSendMessages.BadgeBackColor = Color.Red;
            btnSendMessages.BadgeFont = new Font("Inter", 8F, FontStyle.Bold);
            btnSendMessages.BadgeValue = 0;
            btnSendMessages.BadgeValueForeColor = Color.White;
            btnSendMessages.BorderColor = Color.LightSlateGray;
            btnSendMessages.BorderWidth = 2;
            btnSendMessages.ButtonBackColor = Color.White;
            btnSendMessages.ButtonImage = Properties.Resources.Send;
            btnSendMessages.CanBeep = true;
            btnSendMessages.CanGlow = false;
            btnSendMessages.CanShake = true;
            btnSendMessages.ContextMenuStripEx = null;
            btnSendMessages.CornerRadiusBottomLeft = 0;
            btnSendMessages.CornerRadiusBottomRight = 0;
            btnSendMessages.CornerRadiusTopLeft = 0;
            btnSendMessages.CornerRadiusTopRight = 0;
            btnSendMessages.CustomCursor = Cursors.Default;
            btnSendMessages.DisabledTextColor = Color.FromArgb(150, 150, 150);
            btnSendMessages.EnableLongPress = false;
            btnSendMessages.EnablePressAnimation = true;
            btnSendMessages.EnableRippleEffect = true;
            btnSendMessages.EnableShadow = false;
            btnSendMessages.EnableTextWrapping = false;
            btnSendMessages.Font = new Font("Inter", 9F);
            btnSendMessages.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnSendMessages.GlowIntensity = 100;
            btnSendMessages.GlowRadius = 20F;
            btnSendMessages.GradientBackground = false;
            btnSendMessages.GradientColor = Color.FromArgb(114, 168, 255);
            btnSendMessages.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnSendMessages.HintText = null;
            btnSendMessages.HoverBackColor = Color.FromArgb(114, 168, 255);
            btnSendMessages.HoverFontStyle = FontStyle.Regular;
            btnSendMessages.HoverTextColor = Color.White;
            btnSendMessages.HoverTransitionDuration = 250;
            btnSendMessages.ImageAlign = ContentAlignment.MiddleLeft;
            btnSendMessages.ImagePadding = 5;
            btnSendMessages.ImageSize = new Size(16, 16);
            btnSendMessages.IsRadial = false;
            btnSendMessages.IsReadOnly = false;
            btnSendMessages.IsToggleButton = false;
            btnSendMessages.IsToggled = false;
            btnSendMessages.Location = new Point(1336, 850);
            btnSendMessages.LongPressDurationMS = 1000;
            btnSendMessages.Name = "btnSendMessages";
            btnSendMessages.NormalFontStyle = FontStyle.Regular;
            btnSendMessages.ParticleColor = Color.FromArgb(200, 200, 200);
            btnSendMessages.ParticleCount = 15;
            btnSendMessages.PressAnimationScale = 0.97F;
            btnSendMessages.PressedBackColor = Color.FromArgb(74, 128, 235);
            btnSendMessages.PressedFontStyle = FontStyle.Regular;
            btnSendMessages.PressTransitionDuration = 150;
            btnSendMessages.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnSendMessages.RippleColor = Color.FromArgb(255, 255, 255);
            btnSendMessages.RippleOpacity = 0.3F;
            btnSendMessages.RippleRadiusMultiplier = 0.6F;
            btnSendMessages.ShadowBlur = 5;
            btnSendMessages.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnSendMessages.ShadowOffset = new Point(2, 2);
            btnSendMessages.ShakeDuration = 500;
            btnSendMessages.ShakeIntensity = 5;
            btnSendMessages.Size = new Size(33, 43);
            btnSendMessages.TabIndex = 49;
            btnSendMessages.TextAlign = ContentAlignment.MiddleCenter;
            btnSendMessages.TextColor = Color.White;
            btnSendMessages.TooltipText = null;
            btnSendMessages.UseAdvancedRendering = true;
            btnSendMessages.UseParticles = false;
            btnSendMessages.Click += btnSendMessages_Click;
            // 
            // sideBar2
            // 
            sideBar2.Location = new Point(0, 0);
            sideBar2.Name = "sideBar2";
            sideBar2.Size = new Size(345, 1250);
            sideBar2.TabIndex = 50;
            // 
            // MeetingRoom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 255, 224);
            ClientSize = new Size(1422, 977);
            Controls.Add(sideBar2);
            Controls.Add(btnSendMessages);
            Controls.Add(pictureBox1);
            Controls.Add(tbMessages);
            Controls.Add(panel7);
            Controls.Add(userProfilePanel1);
            Controls.Add(siticonePanel1);
            Controls.Add(sbtn_CancelCall);
            Controls.Add(sbtn_ChangeHost);
            Controls.Add(participants_panel);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pn_Background);
            Controls.Add(tbDisplayMsg);
            Name = "MeetingRoom";
            Text = "Meeting Room";
            Load += MeetingRoom_Load;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel6.ResumeLayout(false);
            participants_panel.ResumeLayout(false);
            panel7.ResumeLayout(false);
            siticonePanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            pn_Background.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private SiticoneNetCoreUI.SiticoneButton btn_Start;
        private SiticoneNetCoreUI.SiticoneLabel lb_time_counter;
        private SiticoneNetCoreUI.SiticoneButton btn_pomodoro;
        private Panel panel1;
        private SiticoneNetCoreUI.SiticoneImageButton avatar_btn;
        private Panel panel3;
        private Label lblMembersNumber;
        private SiticoneNetCoreUI.SiticoneImageButton siticoneImageButton8;
        private Panel panel6;
        private SiticoneNetCoreUI.SiticoneLabel lb_participant;
        private TableLayoutPanel participants_panel;
        private SiticoneNetCoreUI.SiticoneTextBox tb_FindParticipants;
        private ListView listViewParticipants;
        private ImageList imageListAvatar;
        private ColumnHeader Avatar;
        private ColumnHeader Ten;
        private ColumnHeader Mic;
        private ColumnHeader Camera;
        private ColumnHeader colAvatar;
        private ColumnHeader colName;
        private ColumnHeader colMic;
        private ColumnHeader colCamera;
        private Panel panel7;
        private SiticoneNetCoreUI.SiticoneImageButton siticoneImageButton9;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel2;
        private UserProfilePanel userProfilePanel1;
        private SideBar sideBar1;
        private SiticoneNetCoreUI.SiticoneButton sbtn_ChangeHost;
        private SiticoneNetCoreUI.SiticoneButton sbtn_CancelCall;
        private SiticoneNetCoreUI.SiticonePanel siticonePanel1;
        private SiticoneNetCoreUI.SiticoneButton btn_Mic;
        private SiticoneNetCoreUI.SiticoneButton btn_Speaker;
        private SiticoneNetCoreUI.SiticoneButton btn_Camera;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel1;
        private SiticoneNetCoreUI.SiticoneImageButton siticoneImageButton1;
        private Panel panel2;
        private SiticoneNetCoreUI.SiticoneTextBox tbMessages;
        private RichTextBox tbDisplayMsg;
        private SiticoneNetCoreUI.SiticoneButton btn_Reset;
        private SiticoneNetCoreUI.SiticoneHProgressBar ProgressBarMusic;
        private SiticoneNetCoreUI.SiticoneButton btn_Break;
        private Label lb_CurrentTime;
        private Label label1;
        private Label lb_TotalTime;
        private Panel pn_Background;
        private Panel panel4;
        private PictureBox pictureBox1;
        private SiticoneNetCoreUI.SiticoneButton btnSendMessages;
        private SideBar sideBar2;
        private SiticoneNetCoreUI.SiticoneButton btnRoomID;
    }
}