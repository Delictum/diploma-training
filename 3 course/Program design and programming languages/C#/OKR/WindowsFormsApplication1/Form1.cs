using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Задайте k");
                    label3.Text = "Result: none";
                    return;
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Задайте x");
                    label3.Text = "Result: none";
                    return;
                }
                int k = Int32.Parse(textBox1.Text);
                if (k < 1)
                {
                    MessageBox.Show("k должно быть натуральным числом");
                    label3.Text = "Result: none";
                    return;
                }                
                double x = double.Parse(textBox2.Text);
                StreamWriter sw = new StreamWriter("text.txt");
                double S = 0;
                for (int i = 1; i <= k; i++)
                {
                    S += Math.Pow(x, i) / i;                    
                    sw.WriteLine(S);
                }
                label3.Text = "Result: " + Convert.ToString(S);
                sw.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверно задано значение.");
                label3.Text = "Result: none";
            }
        }
    }
}
