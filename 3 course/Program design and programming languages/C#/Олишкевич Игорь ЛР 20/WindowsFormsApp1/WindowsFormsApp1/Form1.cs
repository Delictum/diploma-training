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
    public partial class Form1 : Form
    {
        private Image img;
        private PictureBox pctr;
        private Image[] oblaka = new Image[5];
        private Timer timer;
        private int animation;
        private bool us = true;

        public Form1()
        {
            Size = new Size(480, 500);
            img = new Bitmap(500, 500);
            Graphics grph = Graphics.FromImage(img);
            
            grph.DrawLine(Pens.Black, 50, 250, 175, 125); grph.DrawLine(Pens.Black, 175, 125, 300, 250); //Крыша
            grph.DrawRectangle(Pens.Black, 50, 250, 250, 200); //Коробка дома
            grph.DrawRectangle(Pens.Black, 100, 300, 50, 150); //Дверь
            grph.DrawEllipse(Pens.Black, 135, 400, 10, 15); //Дверная ручка
            grph.DrawRectangle(Pens.Black, 200, 300, 50, 75); //Коробка окна
            grph.DrawLine(Pens.Black, 225, 300, 225, 375); //Разделение окна
            grph.DrawLine(Pens.Black, 225, 330, 250, 330); //Створка окна
            grph.DrawLine(Pens.Black, 225, 175, 225, 100); //Левая часть трубы 
            grph.DrawLine(Pens.Black, 225, 100, 250, 100); //Верх трубы
            grph.DrawLine(Pens.Black, 250, 100, 250, 200); //Правая часть трубы

            //Дым из трубы
            for (int i = 4; i > -1; i--)
            {
                oblaka[i] = new Bitmap(500, 500);
                grph = Graphics.FromImage(oblaka[i]);
                grph.DrawEllipse(Pens.Black, 235 + (i * 10), 50 - (i * 10), 35 - (i * 10), 35 - (i * 10));
                grph.DrawEllipse(Pens.Black, 230 + (i * 11), 40 - (i * 11), 35 - (i * 11), 35 - (i * 11));
                grph.DrawEllipse(Pens.Black, 225 + (i * 12), 60 - (i * 12), 35 - (i * 12), 35 - (i * 12));
            }

            pctr = new PictureBox { Image = new Bitmap(500, 500), Location = new Point(0, 0), Size = new Size(500, 500) };
            Controls.Add(pctr);

            timer = new Timer { Interval = 300 };
            timer.Tick += Tick;
            timer.Start();
        }

        private void Tick(object sender, EventArgs e)
        {
            var graphics = Graphics.FromImage(pctr.Image);
            graphics.Clear(Color.White);
            graphics.DrawImageUnscaled(img, 0, 0, 500, 500);
            graphics.DrawImageUnscaled(oblaka[animation], 0, 0, 500, 500);
            pctr.Invalidate();
            if (++animation >= oblaka.Length)
                animation = 0;
        }
    }
}
