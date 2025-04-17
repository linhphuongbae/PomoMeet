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
            siticoneLabel3 = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneLabel4 = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneLabel5 = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneTextBox1 = new SiticoneNetCoreUI.SiticoneTextBox();
            siticoneTextBox2 = new SiticoneNetCoreUI.SiticoneTextBox();
            siticoneTextBox3 = new SiticoneNetCoreUI.SiticoneTextBox();
            siticoneTextBox4 = new SiticoneNetCoreUI.SiticoneTextBox();
            siticoneTextBox5 = new SiticoneNetCoreUI.SiticoneTextBox();
            siticoneTextArea1 = new SiticoneNetCoreUI.SiticoneTextArea();
            siticoneLabel6 = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneLabel7 = new SiticoneNetCoreUI.SiticoneLabel();
            siticoneLabel8 = new SiticoneNetCoreUI.SiticoneLabel();
            bindingSource1 = new BindingSource(components);
            siticoneLabel9 = new SiticoneNetCoreUI.SiticoneLabel();
            editAvatarButton = new PictureBox();
            siticoneButton1 = new SiticoneNetCoreUI.SiticoneButton();
            userProfilePanel1 = new UserProfilePanel();
            sideBar1 = new SideBar();
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
            pictureBox_avatar.Location = new Point(645, 135);
            pictureBox_avatar.Name = "pictureBox_avatar";
            pictureBox_avatar.Size = new Size(141, 156);
            pictureBox_avatar.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_avatar.TabIndex = 6;
            pictureBox_avatar.TabStop = false;
            // 
            // siticoneLabel1
            // 
            siticoneLabel1.BackColor = Color.Transparent;
            siticoneLabel1.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            siticoneLabel1.ForeColor = Color.DarkSeaGreen;
            siticoneLabel1.Location = new Point(339, 221);
            siticoneLabel1.Name = "siticoneLabel1";
            siticoneLabel1.Size = new Size(142, 43);
            siticoneLabel1.TabIndex = 7;
            siticoneLabel1.Text = "Username";
            // 
            // siticoneLabel2
            // 
            siticoneLabel2.BackColor = Color.Transparent;
            siticoneLabel2.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            siticoneLabel2.ForeColor = Color.DarkSeaGreen;
            siticoneLabel2.Location = new Point(339, 340);
            siticoneLabel2.Name = "siticoneLabel2";
            siticoneLabel2.Size = new Size(88, 44);
            siticoneLabel2.TabIndex = 8;
            siticoneLabel2.Text = "Email";
            // 
            // siticoneLabel3
            // 
            siticoneLabel3.BackColor = Color.Transparent;
            siticoneLabel3.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            siticoneLabel3.ForeColor = Color.DarkSeaGreen;
            siticoneLabel3.Location = new Point(339, 467);
            siticoneLabel3.Name = "siticoneLabel3";
            siticoneLabel3.Size = new Size(142, 37);
            siticoneLabel3.TabIndex = 9;
            siticoneLabel3.Text = "Password";
            // 
            // siticoneLabel4
            // 
            siticoneLabel4.BackColor = Color.Transparent;
            siticoneLabel4.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            siticoneLabel4.ForeColor = Color.DarkSeaGreen;
            siticoneLabel4.Location = new Point(339, 578);
            siticoneLabel4.Name = "siticoneLabel4";
            siticoneLabel4.Size = new Size(197, 47);
            siticoneLabel4.TabIndex = 10;
            siticoneLabel4.Text = "New password";
            // 
            // siticoneLabel5
            // 
            siticoneLabel5.BackColor = Color.Transparent;
            siticoneLabel5.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            siticoneLabel5.ForeColor = Color.DarkSeaGreen;
            siticoneLabel5.Location = new Point(339, 704);
            siticoneLabel5.Name = "siticoneLabel5";
            siticoneLabel5.Size = new Size(142, 36);
            siticoneLabel5.TabIndex = 11;
            siticoneLabel5.Text = "Confirm password";
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
            siticoneTextBox1.Font = new Font("Segoe UI", 15F);
            siticoneTextBox1.ForeColor = Color.DimGray;
            siticoneTextBox1.HoverBorderColor1 = Color.Gray;
            siticoneTextBox1.HoverBorderColor2 = Color.Gray;
            siticoneTextBox1.IsEnabled = true;
            siticoneTextBox1.Location = new Point(339, 267);
            siticoneTextBox1.Name = "siticoneTextBox1";
            siticoneTextBox1.PlaceholderColor = Color.Gray;
            siticoneTextBox1.PlaceholderText = "Enter text here...";
            siticoneTextBox1.ReadOnlyBorderColor1 = Color.LightGray;
            siticoneTextBox1.ReadOnlyBorderColor2 = Color.LightGray;
            siticoneTextBox1.ReadOnlyFillColor1 = Color.WhiteSmoke;
            siticoneTextBox1.ReadOnlyFillColor2 = Color.WhiteSmoke;
            siticoneTextBox1.ReadOnlyPlaceholderColor = Color.DarkGray;
            siticoneTextBox1.SelectionBackColor = Color.FromArgb(77, 77, 255);
            siticoneTextBox1.ShadowAnimationDuration = 1;
            siticoneTextBox1.ShadowBlur = 10;
            siticoneTextBox1.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            siticoneTextBox1.Size = new Size(255, 47);
            siticoneTextBox1.SolidBorderColor = Color.LightSlateGray;
            siticoneTextBox1.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            siticoneTextBox1.SolidBorderHoverColor = Color.Gray;
            siticoneTextBox1.SolidFillColor = Color.White;
            siticoneTextBox1.TabIndex = 12;
            siticoneTextBox1.Text = "Your username";
            siticoneTextBox1.TextPadding = new Padding(8, 0, 6, 0);
            siticoneTextBox1.ValidationErrorMessage = "Invalid input.";
            siticoneTextBox1.ValidationFunction = null;
            // 
            // siticoneTextBox2
            // 
            siticoneTextBox2.AccessibleDescription = "A customizable text input field.";
            siticoneTextBox2.AccessibleName = "Text Box";
            siticoneTextBox2.AccessibleRole = AccessibleRole.Text;
            siticoneTextBox2.BackColor = Color.Transparent;
            siticoneTextBox2.BlinkCount = 3;
            siticoneTextBox2.BlinkShadow = false;
            siticoneTextBox2.BorderColor1 = Color.LightSlateGray;
            siticoneTextBox2.BorderColor2 = Color.LightSlateGray;
            siticoneTextBox2.BorderFocusColor1 = Color.FromArgb(77, 77, 255);
            siticoneTextBox2.BorderFocusColor2 = Color.FromArgb(77, 77, 255);
            siticoneTextBox2.CanShake = true;
            siticoneTextBox2.ContinuousBlink = false;
            siticoneTextBox2.CursorBlinkRate = 500;
            siticoneTextBox2.CursorColor = Color.Black;
            siticoneTextBox2.CursorHeight = 26;
            siticoneTextBox2.CursorOffset = 0;
            siticoneTextBox2.CursorStyle = SiticoneNetCoreUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            siticoneTextBox2.CursorWidth = 1;
            siticoneTextBox2.DisabledBackColor = Color.WhiteSmoke;
            siticoneTextBox2.DisabledBorderColor = Color.LightGray;
            siticoneTextBox2.DisabledTextColor = Color.Gray;
            siticoneTextBox2.EnableDropShadow = false;
            siticoneTextBox2.FillColor1 = Color.White;
            siticoneTextBox2.FillColor2 = Color.White;
            siticoneTextBox2.Font = new Font("Segoe UI", 15F);
            siticoneTextBox2.ForeColor = Color.DimGray;
            siticoneTextBox2.HoverBorderColor1 = Color.Gray;
            siticoneTextBox2.HoverBorderColor2 = Color.Gray;
            siticoneTextBox2.IsEnabled = true;
            siticoneTextBox2.Location = new Point(339, 387);
            siticoneTextBox2.Name = "siticoneTextBox2";
            siticoneTextBox2.PlaceholderColor = Color.Gray;
            siticoneTextBox2.PlaceholderText = "Enter text here...";
            siticoneTextBox2.ReadOnlyBorderColor1 = Color.LightGray;
            siticoneTextBox2.ReadOnlyBorderColor2 = Color.LightGray;
            siticoneTextBox2.ReadOnlyFillColor1 = Color.WhiteSmoke;
            siticoneTextBox2.ReadOnlyFillColor2 = Color.WhiteSmoke;
            siticoneTextBox2.ReadOnlyPlaceholderColor = Color.DarkGray;
            siticoneTextBox2.SelectionBackColor = Color.FromArgb(77, 77, 255);
            siticoneTextBox2.ShadowAnimationDuration = 1;
            siticoneTextBox2.ShadowBlur = 10;
            siticoneTextBox2.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            siticoneTextBox2.Size = new Size(255, 47);
            siticoneTextBox2.SolidBorderColor = Color.LightSlateGray;
            siticoneTextBox2.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            siticoneTextBox2.SolidBorderHoverColor = Color.Gray;
            siticoneTextBox2.SolidFillColor = Color.White;
            siticoneTextBox2.TabIndex = 17;
            siticoneTextBox2.Text = "Your email";
            siticoneTextBox2.TextPadding = new Padding(8, 0, 6, 0);
            siticoneTextBox2.ValidationErrorMessage = "Invalid input.";
            siticoneTextBox2.ValidationFunction = null;
            // 
            // siticoneTextBox3
            // 
            siticoneTextBox3.AccessibleDescription = "A customizable text input field.";
            siticoneTextBox3.AccessibleName = "Text Box";
            siticoneTextBox3.AccessibleRole = AccessibleRole.Text;
            siticoneTextBox3.BackColor = Color.Transparent;
            siticoneTextBox3.BlinkCount = 3;
            siticoneTextBox3.BlinkShadow = false;
            siticoneTextBox3.BorderColor1 = Color.LightSlateGray;
            siticoneTextBox3.BorderColor2 = Color.LightSlateGray;
            siticoneTextBox3.BorderFocusColor1 = Color.FromArgb(77, 77, 255);
            siticoneTextBox3.BorderFocusColor2 = Color.FromArgb(77, 77, 255);
            siticoneTextBox3.CanShake = true;
            siticoneTextBox3.ContinuousBlink = false;
            siticoneTextBox3.CursorBlinkRate = 500;
            siticoneTextBox3.CursorColor = Color.Black;
            siticoneTextBox3.CursorHeight = 26;
            siticoneTextBox3.CursorOffset = 0;
            siticoneTextBox3.CursorStyle = SiticoneNetCoreUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            siticoneTextBox3.CursorWidth = 1;
            siticoneTextBox3.DisabledBackColor = Color.WhiteSmoke;
            siticoneTextBox3.DisabledBorderColor = Color.LightGray;
            siticoneTextBox3.DisabledTextColor = Color.Gray;
            siticoneTextBox3.EnableDropShadow = false;
            siticoneTextBox3.FillColor1 = Color.White;
            siticoneTextBox3.FillColor2 = Color.White;
            siticoneTextBox3.Font = new Font("Segoe UI", 15F);
            siticoneTextBox3.ForeColor = Color.DimGray;
            siticoneTextBox3.HoverBorderColor1 = Color.Gray;
            siticoneTextBox3.HoverBorderColor2 = Color.Gray;
            siticoneTextBox3.IsEnabled = true;
            siticoneTextBox3.Location = new Point(339, 507);
            siticoneTextBox3.Name = "siticoneTextBox3";
            siticoneTextBox3.PlaceholderColor = Color.Gray;
            siticoneTextBox3.PlaceholderText = "Enter text here...";
            siticoneTextBox3.ReadOnlyBorderColor1 = Color.LightGray;
            siticoneTextBox3.ReadOnlyBorderColor2 = Color.LightGray;
            siticoneTextBox3.ReadOnlyFillColor1 = Color.WhiteSmoke;
            siticoneTextBox3.ReadOnlyFillColor2 = Color.WhiteSmoke;
            siticoneTextBox3.ReadOnlyPlaceholderColor = Color.DarkGray;
            siticoneTextBox3.SelectionBackColor = Color.FromArgb(77, 77, 255);
            siticoneTextBox3.ShadowAnimationDuration = 1;
            siticoneTextBox3.ShadowBlur = 10;
            siticoneTextBox3.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            siticoneTextBox3.Size = new Size(255, 47);
            siticoneTextBox3.SolidBorderColor = Color.LightSlateGray;
            siticoneTextBox3.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            siticoneTextBox3.SolidBorderHoverColor = Color.Gray;
            siticoneTextBox3.SolidFillColor = Color.White;
            siticoneTextBox3.TabIndex = 18;
            siticoneTextBox3.Text = "*********";
            siticoneTextBox3.TextPadding = new Padding(8, 0, 6, 0);
            siticoneTextBox3.ValidationErrorMessage = "Invalid input.";
            siticoneTextBox3.ValidationFunction = null;
            // 
            // siticoneTextBox4
            // 
            siticoneTextBox4.AccessibleDescription = "A customizable text input field.";
            siticoneTextBox4.AccessibleName = "Text Box";
            siticoneTextBox4.AccessibleRole = AccessibleRole.Text;
            siticoneTextBox4.BackColor = Color.Transparent;
            siticoneTextBox4.BlinkCount = 3;
            siticoneTextBox4.BlinkShadow = false;
            siticoneTextBox4.BorderColor1 = Color.LightSlateGray;
            siticoneTextBox4.BorderColor2 = Color.LightSlateGray;
            siticoneTextBox4.BorderFocusColor1 = Color.FromArgb(77, 77, 255);
            siticoneTextBox4.BorderFocusColor2 = Color.FromArgb(77, 77, 255);
            siticoneTextBox4.CanShake = true;
            siticoneTextBox4.ContinuousBlink = false;
            siticoneTextBox4.CursorBlinkRate = 500;
            siticoneTextBox4.CursorColor = Color.Black;
            siticoneTextBox4.CursorHeight = 26;
            siticoneTextBox4.CursorOffset = 0;
            siticoneTextBox4.CursorStyle = SiticoneNetCoreUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            siticoneTextBox4.CursorWidth = 1;
            siticoneTextBox4.DisabledBackColor = Color.WhiteSmoke;
            siticoneTextBox4.DisabledBorderColor = Color.LightGray;
            siticoneTextBox4.DisabledTextColor = Color.Gray;
            siticoneTextBox4.EnableDropShadow = false;
            siticoneTextBox4.FillColor1 = Color.White;
            siticoneTextBox4.FillColor2 = Color.White;
            siticoneTextBox4.Font = new Font("Segoe UI", 15F);
            siticoneTextBox4.ForeColor = Color.DimGray;
            siticoneTextBox4.HoverBorderColor1 = Color.Gray;
            siticoneTextBox4.HoverBorderColor2 = Color.Gray;
            siticoneTextBox4.IsEnabled = true;
            siticoneTextBox4.Location = new Point(339, 628);
            siticoneTextBox4.Name = "siticoneTextBox4";
            siticoneTextBox4.PlaceholderColor = Color.Gray;
            siticoneTextBox4.PlaceholderText = "Enter text here...";
            siticoneTextBox4.ReadOnlyBorderColor1 = Color.LightGray;
            siticoneTextBox4.ReadOnlyBorderColor2 = Color.LightGray;
            siticoneTextBox4.ReadOnlyFillColor1 = Color.WhiteSmoke;
            siticoneTextBox4.ReadOnlyFillColor2 = Color.WhiteSmoke;
            siticoneTextBox4.ReadOnlyPlaceholderColor = Color.DarkGray;
            siticoneTextBox4.SelectionBackColor = Color.FromArgb(77, 77, 255);
            siticoneTextBox4.ShadowAnimationDuration = 1;
            siticoneTextBox4.ShadowBlur = 10;
            siticoneTextBox4.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            siticoneTextBox4.Size = new Size(255, 47);
            siticoneTextBox4.SolidBorderColor = Color.LightSlateGray;
            siticoneTextBox4.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            siticoneTextBox4.SolidBorderHoverColor = Color.Gray;
            siticoneTextBox4.SolidFillColor = Color.White;
            siticoneTextBox4.TabIndex = 19;
            siticoneTextBox4.Text = "*********";
            siticoneTextBox4.TextPadding = new Padding(8, 0, 6, 0);
            siticoneTextBox4.ValidationErrorMessage = "Invalid input.";
            siticoneTextBox4.ValidationFunction = null;
            // 
            // siticoneTextBox5
            // 
            siticoneTextBox5.AccessibleDescription = "A customizable text input field.";
            siticoneTextBox5.AccessibleName = "Text Box";
            siticoneTextBox5.AccessibleRole = AccessibleRole.Text;
            siticoneTextBox5.BackColor = Color.Transparent;
            siticoneTextBox5.BlinkCount = 3;
            siticoneTextBox5.BlinkShadow = false;
            siticoneTextBox5.BorderColor1 = Color.LightSlateGray;
            siticoneTextBox5.BorderColor2 = Color.LightSlateGray;
            siticoneTextBox5.BorderFocusColor1 = Color.FromArgb(77, 77, 255);
            siticoneTextBox5.BorderFocusColor2 = Color.FromArgb(77, 77, 255);
            siticoneTextBox5.CanShake = true;
            siticoneTextBox5.ContinuousBlink = false;
            siticoneTextBox5.CursorBlinkRate = 500;
            siticoneTextBox5.CursorColor = Color.Black;
            siticoneTextBox5.CursorHeight = 26;
            siticoneTextBox5.CursorOffset = 0;
            siticoneTextBox5.CursorStyle = SiticoneNetCoreUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            siticoneTextBox5.CursorWidth = 1;
            siticoneTextBox5.DisabledBackColor = Color.WhiteSmoke;
            siticoneTextBox5.DisabledBorderColor = Color.LightGray;
            siticoneTextBox5.DisabledTextColor = Color.Gray;
            siticoneTextBox5.EnableDropShadow = false;
            siticoneTextBox5.FillColor1 = Color.White;
            siticoneTextBox5.FillColor2 = Color.White;
            siticoneTextBox5.Font = new Font("Segoe UI", 15F);
            siticoneTextBox5.ForeColor = Color.DimGray;
            siticoneTextBox5.HoverBorderColor1 = Color.Gray;
            siticoneTextBox5.HoverBorderColor2 = Color.Gray;
            siticoneTextBox5.IsEnabled = true;
            siticoneTextBox5.Location = new Point(339, 743);
            siticoneTextBox5.Name = "siticoneTextBox5";
            siticoneTextBox5.PlaceholderColor = Color.Gray;
            siticoneTextBox5.PlaceholderText = "Enter text here...";
            siticoneTextBox5.ReadOnlyBorderColor1 = Color.LightGray;
            siticoneTextBox5.ReadOnlyBorderColor2 = Color.LightGray;
            siticoneTextBox5.ReadOnlyFillColor1 = Color.WhiteSmoke;
            siticoneTextBox5.ReadOnlyFillColor2 = Color.WhiteSmoke;
            siticoneTextBox5.ReadOnlyPlaceholderColor = Color.DarkGray;
            siticoneTextBox5.SelectionBackColor = Color.FromArgb(77, 77, 255);
            siticoneTextBox5.ShadowAnimationDuration = 1;
            siticoneTextBox5.ShadowBlur = 10;
            siticoneTextBox5.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            siticoneTextBox5.Size = new Size(255, 47);
            siticoneTextBox5.SolidBorderColor = Color.LightSlateGray;
            siticoneTextBox5.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            siticoneTextBox5.SolidBorderHoverColor = Color.Gray;
            siticoneTextBox5.SolidFillColor = Color.White;
            siticoneTextBox5.TabIndex = 20;
            siticoneTextBox5.Text = "*********";
            siticoneTextBox5.TextPadding = new Padding(8, 0, 6, 0);
            siticoneTextBox5.ValidationErrorMessage = "Invalid input.";
            siticoneTextBox5.ValidationFunction = null;
            // 
            // siticoneTextArea1
            // 
            siticoneTextArea1.BorderStyle = BorderStyle.None;
            siticoneTextArea1.Font = new Font("Century Gothic", 17F);
            siticoneTextArea1.Location = new Point(645, 350);
            siticoneTextArea1.Margin = new Padding(4, 5, 4, 5);
            siticoneTextArea1.MinimumSize = new Size(89, 95);
            siticoneTextArea1.Multiline = true;
            siticoneTextArea1.Name = "siticoneTextArea1";
            siticoneTextArea1.PlaceholderText = "Write something here...";
            siticoneTextArea1.ScrollBars = ScrollBars.Vertical;
            siticoneTextArea1.Size = new Size(565, 439);
            siticoneTextArea1.TabIndex = 21;
            // 
            // siticoneLabel6
            // 
            siticoneLabel6.BackColor = Color.Transparent;
            siticoneLabel6.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            siticoneLabel6.ForeColor = Color.DarkSeaGreen;
            siticoneLabel6.Location = new Point(645, 301);
            siticoneLabel6.Name = "siticoneLabel6";
            siticoneLabel6.Size = new Size(154, 45);
            siticoneLabel6.TabIndex = 22;
            siticoneLabel6.Text = "About me";
            // 
            // siticoneLabel7
            // 
            siticoneLabel7.BackColor = Color.Transparent;
            siticoneLabel7.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            siticoneLabel7.ForeColor = Color.DarkSeaGreen;
            siticoneLabel7.Location = new Point(295, 141);
            siticoneLabel7.Name = "siticoneLabel7";
            siticoneLabel7.Size = new Size(323, 64);
            siticoneLabel7.TabIndex = 24;
            siticoneLabel7.Text = "Your Profile";
            siticoneLabel7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // siticoneLabel8
            // 
            siticoneLabel8.BackColor = Color.Transparent;
            siticoneLabel8.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            siticoneLabel8.ForeColor = Color.DarkSeaGreen;
            siticoneLabel8.Location = new Point(791, 135);
            siticoneLabel8.Name = "siticoneLabel8";
            siticoneLabel8.Size = new Size(248, 53);
            siticoneLabel8.TabIndex = 26;
            siticoneLabel8.Text = "Username";
            siticoneLabel8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // siticoneLabel9
            // 
            siticoneLabel9.BackColor = Color.Transparent;
            siticoneLabel9.Font = new Font("Segoe UI", 15F);
            siticoneLabel9.ForeColor = Color.LimeGreen;
            siticoneLabel9.Location = new Point(813, 189);
            siticoneLabel9.Name = "siticoneLabel9";
            siticoneLabel9.Size = new Size(111, 28);
            siticoneLabel9.TabIndex = 27;
            siticoneLabel9.Text = "Online";
            // 
            // editAvatarButton
            // 
            editAvatarButton.BackColor = Color.Transparent;
            editAvatarButton.Cursor = Cursors.Hand;
            editAvatarButton.Image = (Image)resources.GetObject("editAvatarButton.Image");
            editAvatarButton.InitialImage = (Image)resources.GetObject("editAvatarButton.InitialImage");
            editAvatarButton.Location = new Point(791, 269);
            editAvatarButton.Name = "editAvatarButton";
            editAvatarButton.Size = new Size(21, 23);
            editAvatarButton.SizeMode = PictureBoxSizeMode.Zoom;
            editAvatarButton.TabIndex = 28;
            editAvatarButton.TabStop = false;
            // 
            // siticoneButton1
            // 
            siticoneButton1.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            siticoneButton1.AccessibleName = "Save Changes";
            siticoneButton1.AutoSizeBasedOnText = false;
            siticoneButton1.BackColor = Color.Transparent;
            siticoneButton1.BadgeBackColor = Color.Red;
            siticoneButton1.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            siticoneButton1.BadgeValue = 0;
            siticoneButton1.BadgeValueForeColor = Color.White;
            siticoneButton1.BorderColor = Color.DarkSeaGreen;
            siticoneButton1.BorderWidth = 2;
            siticoneButton1.ButtonBackColor = Color.DarkSeaGreen;
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
            siticoneButton1.Font = new Font("Segoe UI", 9F);
            siticoneButton1.GlowColor = Color.FromArgb(100, 255, 255, 255);
            siticoneButton1.GlowIntensity = 100;
            siticoneButton1.GlowRadius = 20F;
            siticoneButton1.GradientBackground = false;
            siticoneButton1.GradientColor = Color.FromArgb(114, 168, 255);
            siticoneButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            siticoneButton1.HintText = null;
            siticoneButton1.HoverBackColor = Color.DarkSeaGreen;
            siticoneButton1.HoverFontStyle = FontStyle.Regular;
            siticoneButton1.HoverTextColor = Color.White;
            siticoneButton1.HoverTransitionDuration = 250;
            siticoneButton1.ImageAlign = ContentAlignment.MiddleLeft;
            siticoneButton1.ImagePadding = 5;
            siticoneButton1.ImageSize = new Size(16, 16);
            siticoneButton1.IsRadial = false;
            siticoneButton1.IsReadOnly = false;
            siticoneButton1.IsToggleButton = false;
            siticoneButton1.IsToggled = false;
            siticoneButton1.Location = new Point(448, 819);
            siticoneButton1.LongPressDurationMS = 1000;
            siticoneButton1.Name = "siticoneButton1";
            siticoneButton1.NormalFontStyle = FontStyle.Regular;
            siticoneButton1.ParticleColor = Color.FromArgb(200, 200, 200);
            siticoneButton1.ParticleCount = 15;
            siticoneButton1.PressAnimationScale = 0.97F;
            siticoneButton1.PressedBackColor = Color.SeaGreen;
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
            siticoneButton1.Size = new Size(146, 49);
            siticoneButton1.TabIndex = 29;
            siticoneButton1.Text = "Save Changes";
            siticoneButton1.TextAlign = ContentAlignment.MiddleCenter;
            siticoneButton1.TextColor = Color.White;
            siticoneButton1.TooltipText = null;
            siticoneButton1.UseAdvancedRendering = true;
            siticoneButton1.UseParticles = false;
            // 
            // userProfilePanel1
            // 
            userProfilePanel1.BackColor = Color.Transparent;
            userProfilePanel1.Location = new Point(988, 11);
            userProfilePanel1.Name = "userProfilePanel1";
            userProfilePanel1.Size = new Size(277, 71);
            userProfilePanel1.TabIndex = 30;
            // 
            // sideBar1
            // 
            sideBar1.Location = new Point(-1, -1);
            sideBar1.Name = "sideBar1";
            sideBar1.Size = new Size(345, 1250);
            sideBar1.TabIndex = 31;
            // 
            // Profile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 255, 224);
            ClientSize = new Size(1264, 930);
            Controls.Add(userProfilePanel1);
            Controls.Add(siticoneButton1);
            Controls.Add(editAvatarButton);
            Controls.Add(siticoneLabel9);
            Controls.Add(siticoneLabel8);
            Controls.Add(siticoneLabel7);
            Controls.Add(siticoneTextArea1);
            Controls.Add(siticoneTextBox5);
            Controls.Add(siticoneTextBox4);
            Controls.Add(siticoneTextBox3);
            Controls.Add(siticoneTextBox2);
            Controls.Add(siticoneTextBox1);
            Controls.Add(siticoneLabel5);
            Controls.Add(siticoneLabel4);
            Controls.Add(siticoneLabel3);
            Controls.Add(siticoneLabel2);
            Controls.Add(siticoneLabel1);
            Controls.Add(pictureBox_avatar);
            Controls.Add(siticoneLabel6);
            Controls.Add(sideBar1);
            Name = "Profile";
            Text = "Profile";
            ((System.ComponentModel.ISupportInitialize)pictureBox_avatar).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)editAvatarButton).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox_avatar;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel1;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel2;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel3;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel4;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel5;
        private SiticoneNetCoreUI.SiticoneTextBox siticoneTextBox1;
        private SiticoneNetCoreUI.SiticoneTextBox siticoneTextBox2;
        private SiticoneNetCoreUI.SiticoneTextBox siticoneTextBox3;
        private SiticoneNetCoreUI.SiticoneTextBox siticoneTextBox4;
        private SiticoneNetCoreUI.SiticoneTextBox siticoneTextBox5;
        private SiticoneNetCoreUI.SiticoneTextArea siticoneTextArea1;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel6;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel7;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel8;
        private BindingSource bindingSource1;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel9;
        private PictureBox editAvatarButton;
        private SiticoneNetCoreUI.SiticoneButton siticoneButton1;
        private UserProfilePanel userProfilePanel1;
        private SideBar sideBar1;
    }
}
