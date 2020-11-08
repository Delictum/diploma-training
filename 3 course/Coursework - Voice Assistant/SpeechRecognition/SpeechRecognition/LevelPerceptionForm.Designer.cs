namespace SpeechRecognition
{
    partial class LevelPerceptionForm
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
            this.levelPerceptionTrackBar = new System.Windows.Forms.TrackBar();
            this.okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.levelPerceptionTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // levelPerceptionTrackBar
            // 
            this.levelPerceptionTrackBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.levelPerceptionTrackBar.Location = new System.Drawing.Point(12, 12);
            this.levelPerceptionTrackBar.Maximum = 100;
            this.levelPerceptionTrackBar.Name = "levelPerceptionTrackBar";
            this.levelPerceptionTrackBar.Size = new System.Drawing.Size(479, 45);
            this.levelPerceptionTrackBar.TabIndex = 0;
            this.levelPerceptionTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.levelPerceptionTrackBar.Scroll += new System.EventHandler(this.levelPerceptionTrackBar_Scroll);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.BackColor = System.Drawing.SystemColors.Window;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(213, 63);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 25;
            this.okButton.Text = "&ОК";
            this.okButton.UseVisualStyleBackColor = false;
            // 
            // LevelPerceptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(503, 88);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.levelPerceptionTrackBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LevelPerceptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Уровень распознования";
            this.Load += new System.EventHandler(this.LevelPerceptionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.levelPerceptionTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar levelPerceptionTrackBar;
        private System.Windows.Forms.Button okButton;
    }
}