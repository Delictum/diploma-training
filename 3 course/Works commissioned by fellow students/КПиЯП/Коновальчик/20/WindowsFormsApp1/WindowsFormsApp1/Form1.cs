using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //Нарисовать рисунок – закипание жидкости в стакане. 
        //Температура увеличивается по нажатию клавиш управлением курсора.
        public Graphics g;

        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            g.DrawLine(new Pen(Color.Black, 1), 50, 250, 250, 250);
            g.DrawLine(new Pen(Color.Black, 1), 50, 250, 20, 20);
            g.DrawLine(new Pen(Color.Black, 1), 250, 250, 280, 20);
            g.DrawLine(new Pen(Color.Black, 1), 25, 40, 275, 40);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int speed = 1;
            for (int i = 1; i < trackBar1.Value; i++)
                speed += Convert.ToInt32(Math.Pow(1.07, i));            
            g.Clear(Color.White);

            //Стакан
            g.DrawLine(new Pen(Color.Black, 1), 50, 250, 250, 250);
            g.DrawLine(new Pen(Color.Black, 1), 50, 250, 20, 20);
            g.DrawLine(new Pen(Color.Black, 1), 250, 250, 280, 20);
            g.DrawLine(new Pen(Color.Black, 1), 25, 40, 275, 40);

            g.DrawEllipse(new Pen(Color.Black, 1), 150 + speed, 150 - speed, 1 + trackBar1.Value / 2, 1 + trackBar1.Value / 2);
            g.DrawEllipse(new Pen(Color.Black, 1), 145 + speed, 200 - speed, 1 + trackBar1.Value / 2, 1 + trackBar1.Value / 2);
            g.DrawEllipse(new Pen(Color.Black, 1), 155 - speed, 175 - speed, 1 + trackBar1.Value / 2, 1 + trackBar1.Value / 2);

            g.DrawEllipse(new Pen(Color.Black, 1), 175 - speed, 195 - speed, 1 + trackBar1.Value / 2, 1 + trackBar1.Value / 2);
            g.DrawEllipse(new Pen(Color.Black, 1), 200 - speed, 175 - speed, 1 + trackBar1.Value / 2, 1 + trackBar1.Value / 2);
            g.DrawEllipse(new Pen(Color.Black, 1), 100 + speed, 175 - speed, 1 + trackBar1.Value / 2, 1 + trackBar1.Value / 2);

            g.DrawEllipse(new Pen(Color.Black, 1), 175 + trackBar1.Value, 195 - speed, 1 + trackBar1.Value / 2, 1 + trackBar1.Value / 2);
            g.DrawEllipse(new Pen(Color.Black, 1), 200 + trackBar1.Value, 175 - speed, 1 + trackBar1.Value / 2, 1 + trackBar1.Value / 2);
            g.DrawEllipse(new Pen(Color.Black, 1), 100 + trackBar1.Value, 175 - speed, 1 + trackBar1.Value / 2, 1 + trackBar1.Value / 2);

            g.DrawEllipse(new Pen(Color.Black, 1), 205, 195 - speed, 1 + trackBar1.Value / 2, 1 + trackBar1.Value / 2);
            g.DrawEllipse(new Pen(Color.Black, 1), 230, 175 - speed, 1 + trackBar1.Value / 2, 1 + trackBar1.Value / 2);
            g.DrawEllipse(new Pen(Color.Black, 1), 210, 175 - speed, 1 + trackBar1.Value / 2, 1 + trackBar1.Value / 2);
        }
    }
}
