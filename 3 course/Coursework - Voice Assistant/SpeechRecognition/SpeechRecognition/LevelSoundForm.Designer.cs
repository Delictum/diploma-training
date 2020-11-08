namespace SpeechRecognition
{
    partial class LevelSoundForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelSoundForm));
            this.levelGeneralSoundTrackBar = new System.Windows.Forms.TrackBar();
            this.muteImg1 = new System.Windows.Forms.PictureBox();
            this.okButton = new System.Windows.Forms.Button();
            this.levelProgramSoundTrackBar = new System.Windows.Forms.TrackBar();
            this.muteImg2 = new System.Windows.Forms.PictureBox();
            this.DinamycLabel = new System.Windows.Forms.Label();
            this.ElsaLabel = new System.Windows.Forms.Label();
            this.DynamicImg = new System.Windows.Forms.PictureBox();
            this.ElsaImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.levelGeneralSoundTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.muteImg1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelProgramSoundTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.muteImg2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DynamicImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElsaImg)).BeginInit();
            this.SuspendLayout();
            // 
            // levelGeneralSoundTrackBar
            // 
            this.levelGeneralSoundTrackBar.Location = new System.Drawing.Point(33, 102);
            this.levelGeneralSoundTrackBar.Maximum = 100;
            this.levelGeneralSoundTrackBar.Name = "levelGeneralSoundTrackBar";
            this.levelGeneralSoundTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.levelGeneralSoundTrackBar.Size = new System.Drawing.Size(45, 426);
            this.levelGeneralSoundTrackBar.TabIndex = 0;
            this.levelGeneralSoundTrackBar.TickFrequency = 25;
            this.levelGeneralSoundTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.levelGeneralSoundTrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.levelGeneralSoundTrackBar.ValueChanged += new System.EventHandler(this.levelSoundTrackBar_ValueChanged);
            // 
            // muteImg1
            // 
            this.muteImg1.Image = ((System.Drawing.Image)(resources.GetObject("muteImg1.Image")));
            this.muteImg1.Location = new System.Drawing.Point(36, 534);
            this.muteImg1.Name = "muteImg1";
            this.muteImg1.Size = new System.Drawing.Size(34, 36);
            this.muteImg1.TabIndex = 1;
            this.muteImg1.TabStop = false;
            this.muteImg1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.muteImg1.MouseLeave += new System.EventHandler(this.muteImg1_MouseLeave);
            this.muteImg1.MouseHover += new System.EventHandler(this.muteImg1_MouseHover);
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.okButton.BackColor = System.Drawing.SystemColors.Window;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(76, 581);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 26;
            this.okButton.Text = "&ОК";
            this.okButton.UseVisualStyleBackColor = false;
            // 
            // levelProgramSoundTrackBar
            // 
            this.levelProgramSoundTrackBar.Location = new System.Drawing.Point(147, 102);
            this.levelProgramSoundTrackBar.Maximum = 65;
            this.levelProgramSoundTrackBar.Name = "levelProgramSoundTrackBar";
            this.levelProgramSoundTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.levelProgramSoundTrackBar.Size = new System.Drawing.Size(45, 426);
            this.levelProgramSoundTrackBar.TabIndex = 27;
            this.levelProgramSoundTrackBar.TickFrequency = 16;
            this.levelProgramSoundTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.levelProgramSoundTrackBar.Scroll += new System.EventHandler(this.levelProgramSoundTrackBar_Scroll);
            this.levelProgramSoundTrackBar.ValueChanged += new System.EventHandler(this.levelProgramSoundTrackBar_ValueChanged);
            // 
            // muteImg2
            // 
            this.muteImg2.Image = ((System.Drawing.Image)(resources.GetObject("muteImg2.Image")));
            this.muteImg2.Location = new System.Drawing.Point(151, 534);
            this.muteImg2.Name = "muteImg2";
            this.muteImg2.Size = new System.Drawing.Size(34, 36);
            this.muteImg2.TabIndex = 28;
            this.muteImg2.TabStop = false;
            this.muteImg2.Click += new System.EventHandler(this.muteImg2_Click);
            this.muteImg2.MouseLeave += new System.EventHandler(this.muteImg2_MouseLeave);
            this.muteImg2.MouseHover += new System.EventHandler(this.muteImg2_MouseHover);
            // 
            // DinamycLabel
            // 
            this.DinamycLabel.AutoSize = true;
            this.DinamycLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DinamycLabel.Location = new System.Drawing.Point(12, 9);
            this.DinamycLabel.Name = "DinamycLabel";
            this.DinamycLabel.Size = new System.Drawing.Size(80, 19);
            this.DinamycLabel.TabIndex = 29;
            this.DinamycLabel.Text = "Динамики";
            // 
            // ElsaLabel
            // 
            this.ElsaLabel.AutoSize = true;
            this.ElsaLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ElsaLabel.Location = new System.Drawing.Point(146, 9);
            this.ElsaLabel.Name = "ElsaLabel";
            this.ElsaLabel.Size = new System.Drawing.Size(48, 19);
            this.ElsaLabel.TabIndex = 30;
            this.ElsaLabel.Text = "Эльза";
            // 
            // DynamicImg
            // 
            this.DynamicImg.Image = ((System.Drawing.Image)(resources.GetObject("DynamicImg.Image")));
            this.DynamicImg.Location = new System.Drawing.Point(33, 51);
            this.DynamicImg.Name = "DynamicImg";
            this.DynamicImg.Size = new System.Drawing.Size(45, 45);
            this.DynamicImg.TabIndex = 31;
            this.DynamicImg.TabStop = false;
            this.DynamicImg.Click += new System.EventHandler(this.DynamicImg_Click);
            this.DynamicImg.MouseLeave += new System.EventHandler(this.DynamicImg_MouseLeave);
            this.DynamicImg.MouseHover += new System.EventHandler(this.DynamicImg_MouseHover);
            // 
            // ElsaImg
            // 
            this.ElsaImg.Image = ((System.Drawing.Image)(resources.GetObject("ElsaImg.Image")));
            this.ElsaImg.Location = new System.Drawing.Point(147, 51);
            this.ElsaImg.Name = "ElsaImg";
            this.ElsaImg.Size = new System.Drawing.Size(45, 45);
            this.ElsaImg.TabIndex = 32;
            this.ElsaImg.TabStop = false;
            // 
            // LevelSoundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 616);
            this.Controls.Add(this.ElsaImg);
            this.Controls.Add(this.DynamicImg);
            this.Controls.Add(this.ElsaLabel);
            this.Controls.Add(this.DinamycLabel);
            this.Controls.Add(this.muteImg2);
            this.Controls.Add(this.levelProgramSoundTrackBar);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.muteImg1);
            this.Controls.Add(this.levelGeneralSoundTrackBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LevelSoundForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.LevelSoundForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.levelGeneralSoundTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.muteImg1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelProgramSoundTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.muteImg2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DynamicImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElsaImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar levelGeneralSoundTrackBar;
        private System.Windows.Forms.PictureBox muteImg1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TrackBar levelProgramSoundTrackBar;
        private System.Windows.Forms.PictureBox muteImg2;
        private System.Windows.Forms.Label DinamycLabel;
        private System.Windows.Forms.Label ElsaLabel;
        private System.Windows.Forms.PictureBox DynamicImg;
        private System.Windows.Forms.PictureBox ElsaImg;
    }
}