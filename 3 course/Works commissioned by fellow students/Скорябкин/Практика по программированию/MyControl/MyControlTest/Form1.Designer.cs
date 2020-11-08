namespace MyControlTest
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }        
        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonControl1 = new MyControl.ButtonControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonControl1
            // 
            this.buttonControl1.EndColor = System.Drawing.Color.Black;
            this.buttonControl1.FontName = "Microsoft Sans Serif";
            this.buttonControl1.FontSize = 8.25F;
            this.buttonControl1.Location = new System.Drawing.Point(12, 39);
            this.buttonControl1.Name = "buttonControl1";
            this.buttonControl1.Size = new System.Drawing.Size(100, 23);
            this.buttonControl1.StartColor = System.Drawing.Color.White;
            this.buttonControl1.TabIndex = 0;
            this.buttonControl1.Text = "Клик";
            this.buttonControl1.Click += new System.EventHandler(this.buttonControl1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(126, 75);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MyControl.ButtonControl buttonControl1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

