using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        float a, b;
        int count;
        bool znak = true;
        bool des = true;
        bool minus = true;

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 0;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (des == true)
            {
                textBox1.Text = textBox1.Text + ",";
                des = false;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 1;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 2;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 3;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 4;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 5;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 6;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 7;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 8;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 9;
        }

        private void calculate()
        {
            switch (count)
            {
                case 1:
                    b = a + float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;

                case 2:
                    b = a - float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case 3:
                    b = a * float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case 4:
                    b = a / float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;

                default:
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text[textBox1.Text.Length - 1] == ',')
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 1;
            label1.Text = a.ToString() + "+";
            znak = true;
            des = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox1.Text == "-")
            {
                textBox1.Text = "-";
                minus = false;
                return;
            }
            if (textBox1.Text[textBox1.Text.Length - 1] == ',')
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 2;
            label1.Text = a.ToString() + "-";
            znak = true;
            des = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text[textBox1.Text.Length - 1] == ',')
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 3;
            label1.Text = a.ToString() + "*";
            znak = true;
            des = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox1.Text[textBox1.Text.Length - 1] == ',')
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            if (textBox1.Text[0] == '-' && textBox1.Text.Length < 2)
                return;
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 4;
            label1.Text = a.ToString() + "/";
            znak = true;
            des = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            calculate();
            label1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Text = "";
            znak = true;
            des = true;
            minus = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text[textBox1.Text.Length - 1] == ',')
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            a = float.Parse(textBox1.Text);
            double b = Math.Sqrt(a);
            textBox1.Text = Convert.ToString(b);
            znak = true;
            des = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (number == '-' && minus == true)
            {
                e.Handled = false;
                minus = false;
            }
            if (number == ',' && des == true)
            {
                e.Handled = false;
                des = false;
            }
            if (!Char.IsDigit(number))
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (des == false && textBox1.Text[textBox1.Text.Length - 1] == ',')
                des = true;
            if (minus == false && textBox1.Text[0] == '-')
                minus = true;
            int lenght = textBox1.Text.Length - 1;
            string text = textBox1.Text;
            textBox1.Clear();
            for (int i = 0; i < lenght; i++)
                textBox1.Text = textBox1.Text + text[i];
        }
    }
}
