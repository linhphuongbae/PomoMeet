namespace PomoMeetApp.View
{
    partial class StartApp
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
            LogoPomoMeet = new SiticoneNetCoreUI.SiticonePictureBox();
            SuspendLayout();
            // 
            // LogoPomoMeet
            // 
            LogoPomoMeet.BackColor = Color.Transparent;
            LogoPomoMeet.BorderColor = Color.Black;
            LogoPomoMeet.BorderWidth = 1;
            LogoPomoMeet.Brightness = 1F;
            LogoPomoMeet.Contrast = 1F;
            LogoPomoMeet.CornerRadius = 0;
            LogoPomoMeet.DraggingSpeed = 3.15F;
            LogoPomoMeet.EnableAsyncLoading = false;
            LogoPomoMeet.EnableCaching = false;
            LogoPomoMeet.EnableDragDrop = false;
            LogoPomoMeet.EnableExtendedImageSources = false;
            LogoPomoMeet.EnableFilters = false;
            LogoPomoMeet.EnableFlipping = false;
            LogoPomoMeet.EnableGlow = false;
            LogoPomoMeet.EnableHighDpiSupport = false;
            LogoPomoMeet.EnableMouseInteraction = false;
            LogoPomoMeet.EnablePlaceholder = false;
            LogoPomoMeet.EnableRotation = false;
            LogoPomoMeet.EnableShadow = false;
            LogoPomoMeet.EnableSlideshow = false;
            LogoPomoMeet.FlipHorizontal = false;
            LogoPomoMeet.FlipVertical = false;
            LogoPomoMeet.Grayscale = false;
            LogoPomoMeet.Image = Properties.Resources.LogoPomoMeet;
            LogoPomoMeet.ImageOpacity = 1F;
            LogoPomoMeet.Images = null;
            LogoPomoMeet.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            LogoPomoMeet.IsCircular = false;
            LogoPomoMeet.Location = new Point(555, 278);
            LogoPomoMeet.MaintainAspectRatio = true;
            LogoPomoMeet.Name = "LogoPomoMeet";
            LogoPomoMeet.PlaceholderImage = null;
            LogoPomoMeet.RotationAngle = 0F;
            LogoPomoMeet.Saturation = 1F;
            LogoPomoMeet.ShowBorder = false;
            LogoPomoMeet.Size = new Size(331, 341);
            LogoPomoMeet.SizeMode = SiticoneNetCoreUI.SiticonePictureBoxSizeMode.Normal;
            LogoPomoMeet.TabIndex = 0;
            LogoPomoMeet.Text = "siticonePictureBox1";
            LogoPomoMeet.Click += LogoPomoMeet_Click;
            // 
            // StartApp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 255, 224);
            ClientSize = new Size(1422, 977);
            Controls.Add(LogoPomoMeet);
            MaximumSize = new Size(1440, 1024);
            Name = "StartApp";
            Text = "StartApp";
            Load += StartApp_Load;
            ResumeLayout(false);
        }

        #endregion

        private SiticoneNetCoreUI.SiticonePictureBox LogoPomoMeet;
    }
}