using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("Winter.jpg");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("Zakat.jpg");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("Lilii.jpg");
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("Holmi.jpg");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                this.Text = "Зима";
            else if (comboBox1.SelectedIndex == 1)
                this.Text = "Закат";
            else if (comboBox1.SelectedIndex == 2)
                this.Text = "Водяные лилии";
            else if (comboBox1.SelectedIndex == 3)
                this.Text = "Голубые холмы";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            comboBox1.SelectedIndex = 0;
            numericUpDown1.Value = this.Height;
            numericUpDown2.Value = this.Width;
            listBox1.SelectedIndex = 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
                this.Font = new Font("TimesNewRoman", 8);
            else if (listBox1.SelectedIndex == 1)
                this.Font = new Font("Arial", 8);
            else if (listBox1.SelectedIndex == 0)
                this.Font = new Font("Microsoft Sans Serif", 8);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.Height = (int)(numericUpDown1.Value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            this.Width = (int)(numericUpDown2.Value);
        }
    }
}
