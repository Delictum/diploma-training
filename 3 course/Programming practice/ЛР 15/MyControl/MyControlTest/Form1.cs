using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyControl;

namespace MyControlTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = "MyControl instances: " + MyControl.MyControl.InstanceCount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyControl.MyControl cd;
            int ct;
            for (ct = 0; ct < 1000; ct++)
                cd = new MyControl.MyControl();

            MyControl.PictureBoxControl dd;
            dd = new MyControl.PictureBoxControl();
            pictureBox1.Load(dd.onEnableStatmentVoid());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MyControl.PictureBoxControl cd;
            cd = new MyControl.PictureBoxControl();
            cd.onChange();
        }
    }    
}
