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
    public partial class Form3 : Form
    {
        Form1 form;
        public Form3(Form1 form1)
        {
            form = form1;
            InitializeComponent();
        }
        Bitmap bitmap;

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (radioButton1.Checked == true)
                    form.g.FillEllipse(new SolidBrush(Color.Red), 50, 50, 100, 100);
                if (radioButton2.Checked == true)
                    form.g.FillEllipse(new SolidBrush(Color.Black), 50, 50, 100, 100);
                if (radioButton3.Checked == true)
                    form.g.FillEllipse(new SolidBrush(Color.Green), 50, 50, 100, 100);
                if (radioButton4.Checked == true)
                    form.g.FillEllipse(new SolidBrush(Color.Yellow), 50, 50, 100, 100);
                if (radioButton5.Checked == true)
                    form.g.FillEllipse(new SolidBrush(Color.Blue), 50, 50, 100, 100);
                if (radioButton6.Checked == true)
                    form.g.FillEllipse(new SolidBrush(Color.White), 50, 50, 100, 100);
            }
            else
            {
                if (radioButton1.Checked == true)
                    form.g.DrawEllipse(new Pen(Color.Red, 5), 50, 50, 100, 100);
                if (radioButton2.Checked == true)
                    form.g.DrawEllipse(new Pen(Color.Black, 5), 50, 50, 100, 100);
                if (radioButton3.Checked == true)
                    form.g.DrawEllipse(new Pen(Color.Green, 5), 50, 50, 100, 100);
                if (radioButton4.Checked == true)
                    form.g.DrawEllipse(new Pen(Color.Yellow, 5), 50, 50, 100, 100);
                if (radioButton5.Checked == true)
                    form.g.DrawEllipse(new Pen(Color.Blue, 5), 50, 50, 100, 100);
                if (radioButton6.Checked == true)
                    form.g.DrawEllipse(new Pen(Color.White, 5), 50, 50, 100, 100);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
