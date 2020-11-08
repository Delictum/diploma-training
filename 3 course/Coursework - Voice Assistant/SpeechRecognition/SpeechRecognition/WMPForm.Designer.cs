namespace SpeechRecognition
{
    partial class WMPForm
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
            this.PlayListBox = new System.Windows.Forms.ListBox();
            this.ClearListButton = new System.Windows.Forms.Button();
            this.LoadListButton = new System.Windows.Forms.Button();
            this.SaveListButton = new System.Windows.Forms.Button();
            this.AddFilesButton = new System.Windows.Forms.Button();
            this.playListLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PlayListBox
            // 
            this.PlayListBox.FormattingEnabled = true;
            this.PlayListBox.Location = new System.Drawing.Point(12, 69);
            this.PlayListBox.Name = "PlayListBox";
            this.PlayListBox.Size = new System.Drawing.Size(301, 368);
            this.PlayListBox.TabIndex = 32;
            this.PlayListBox.SelectedIndexChanged += new System.EventHandler(this.PlayListBox_SelectedIndexChanged);
            // 
            // ClearListButton
            // 
            this.ClearListButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ClearListButton.Location = new System.Drawing.Point(242, 6);
            this.ClearListButton.Name = "ClearListButton";
            this.ClearListButton.Size = new System.Drawing.Size(71, 34);
            this.ClearListButton.TabIndex = 36;
            this.ClearListButton.Text = "Очистить плейлист";
            this.ClearListButton.UseVisualStyleBackColor = true;
            this.ClearListButton.Click += new System.EventHandler(this.ClearListButton_Click);
            // 
            // LoadListButton
            // 
            this.LoadListButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoadListButton.Location = new System.Drawing.Point(166, 6);
            this.LoadListButton.Name = "LoadListButton";
            this.LoadListButton.Size = new System.Drawing.Size(71, 34);
            this.LoadListButton.TabIndex = 35;
            this.LoadListButton.Text = "Загрузить плейлист";
            this.LoadListButton.UseVisualStyleBackColor = true;
            this.LoadListButton.Click += new System.EventHandler(this.LoadListButton_Click);
            // 
            // SaveListButton
            // 
            this.SaveListButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveListButton.Location = new System.Drawing.Point(89, 6);
            this.SaveListButton.Name = "SaveListButton";
            this.SaveListButton.Size = new System.Drawing.Size(71, 34);
            this.SaveListButton.TabIndex = 34;
            this.SaveListButton.Text = "Сохранить плейлист";
            this.SaveListButton.UseVisualStyleBackColor = true;
            this.SaveListButton.Click += new System.EventHandler(this.SaveListButton_Click);
            // 
            // AddFilesButton
            // 
            this.AddFilesButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddFilesButton.Location = new System.Drawing.Point(12, 6);
            this.AddFilesButton.Name = "AddFilesButton";
            this.AddFilesButton.Size = new System.Drawing.Size(71, 34);
            this.AddFilesButton.TabIndex = 33;
            this.AddFilesButton.Text = "Добавить файлы";
            this.AddFilesButton.UseVisualStyleBackColor = true;
            this.AddFilesButton.Click += new System.EventHandler(this.AddFilesButton_Click);
            // 
            // playListLabel
            // 
            this.playListLabel.AutoSize = true;
            this.playListLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playListLabel.Location = new System.Drawing.Point(77, 47);
            this.playListLabel.Name = "playListLabel";
            this.playListLabel.Size = new System.Drawing.Size(80, 19);
            this.playListLabel.TabIndex = 37;
            this.playListLabel.Text = "Плейлист";
            // 
            // WMPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(325, 448);
            this.Controls.Add(this.playListLabel);
            this.Controls.Add(this.ClearListButton);
            this.Controls.Add(this.LoadListButton);
            this.Controls.Add(this.SaveListButton);
            this.Controls.Add(this.AddFilesButton);
            this.Controls.Add(this.PlayListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WMPForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Плейлист";
            this.Load += new System.EventHandler(this.WMPForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button LoadListButton;
        private System.Windows.Forms.Button SaveListButton;
        private System.Windows.Forms.Button AddFilesButton;
        public System.Windows.Forms.ListBox PlayListBox;
        public System.Windows.Forms.Button ClearListButton;
        private System.Windows.Forms.Label playListLabel;
    }
}