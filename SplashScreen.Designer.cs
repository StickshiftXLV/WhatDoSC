namespace WhatDoSC
{
    partial class SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            pictureBoxBackground = new PictureBox();
            btnStart = new Button();
            btnHelp = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxBackground
            // 
            pictureBoxBackground.BackColor = Color.Transparent;
            pictureBoxBackground.Dock = DockStyle.Fill;
            pictureBoxBackground.Image = Properties.Resources.whatDoTrailer;
            pictureBoxBackground.Location = new Point(0, 0);
            pictureBoxBackground.Name = "pictureBoxBackground";
            pictureBoxBackground.Size = new Size(1463, 813);
            pictureBoxBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxBackground.TabIndex = 0;
            pictureBoxBackground.TabStop = false;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(192, 255, 192);
            btnStart.FlatStyle = FlatStyle.Popup;
            btnStart.Font = new Font("Stencil", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStart.ForeColor = Color.Lime;
            btnStart.Location = new Point(28, 506);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(244, 62);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // btnHelp
            // 
            btnHelp.BackColor = Color.Black;
            btnHelp.FlatStyle = FlatStyle.Popup;
            btnHelp.Font = new Font("Stencil", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHelp.ForeColor = Color.Yellow;
            btnHelp.Location = new Point(28, 627);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(244, 62);
            btnHelp.TabIndex = 2;
            btnHelp.Text = "Help";
            btnHelp.UseVisualStyleBackColor = false;
            btnHelp.Click += btnHelp_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Stencil", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Red;
            button1.Location = new Point(28, 739);
            button1.Name = "button1";
            button1.Size = new Size(244, 62);
            button1.TabIndex = 3;
            button1.Text = "EXIT";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(292, 663);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(460, 138);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // SplashScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.IndianRed;
            BackgroundImage = Properties.Resources.whatDoTrailer;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1463, 813);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(btnHelp);
            Controls.Add(btnStart);
            Controls.Add(pictureBoxBackground);
            DoubleBuffered = true;
            ForeColor = Color.IndianRed;
            FormBorderStyle = FormBorderStyle.None;
            Name = "SplashScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SplashScreen";
            TopMost = true;
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBoxBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxBackground;
        private Button btnStart;
        private Button btnHelp;
        private Button button1;
        private PictureBox pictureBox1;
    }
}