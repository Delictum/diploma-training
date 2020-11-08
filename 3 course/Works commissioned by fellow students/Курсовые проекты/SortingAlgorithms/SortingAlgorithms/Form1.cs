using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace SortingAlgorithms
{
    public partial class Form1 : Form
    {
        static private int[] mas = new int[] { 12, 3, 4, 5, 6, 6, 8, 2, 5, 9, 1 };

        public Form1()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();

            for (int i = 0; i < mas.Length; i++)
            {
                dataGridView1.Columns.Add("", "");
                dataGridView1.Columns[i].Width = 40;

                dataGridView2.Columns.Add("", "");
                dataGridView2.Columns[i].Width = 40;
            }
            for (int i = 0; i < mas.Length; i++)
            {
                dataGridView1.Rows[0].Cells[i].Value = mas[i];
            }

            if (radioButton1.Checked == true)
            {                      
                string temp = string.Join(",", ClassNaturalFusion.sort(mas));
                string[] buf = temp.Split(',');
                for (int i = 0; i < mas.Length; i++)
                    dataGridView2.Rows[0].Cells[i].Value = buf[i];
            }
            if (radioButton2.Checked == true)
            {
                int[] buf = ClassMultipathMerger.Merger(mas);
                for (int i = 0; i < mas.Length; i++)
                    dataGridView2.Rows[0].Cells[i].Value = buf[i];                
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            textBox3.Text = elapsedTime;
            textBox1.Text = ClassNaturalFusion.T(mas.Length).ToString();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Random rand = new Random();
            mas = new int[Convert.ToInt32(comboBox1.Text)];
            for (int i = 0; i < Convert.ToInt32(comboBox1.Text); i++)
                mas[i] = rand.Next(1, Convert.ToInt32(comboBox1.Text));
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();            
            
            dataGridView3.Columns.Clear();
            dataGridView4.Columns.Clear();
            for (int i = 0; i < mas.Length; i++)
            {
                dataGridView3.Columns.Add("", "");
                dataGridView3.Columns[i].Width = 40;

                dataGridView4.Columns.Add("", "");
                dataGridView4.Columns[i].Width = 40;
            }
            for (int i = 0; i < mas.Length; i++)
            {
                dataGridView3.Rows[0].Cells[i].Value = mas[i];
            }
            if (radioButton4.Checked == true)
            {
                label6.Text = "O(n log n)";
                textBox4.Text = ClassNaturalFusion.T(mas.Length).ToString();
                int[] buf = ClassPyramidSorting.sorting(mas, mas.Length);
                for (int i = 0; i < mas.Length; i++)
                    dataGridView4.Rows[0].Cells[i].Value = buf[i];
            }
            if (radioButton3.Checked == true)
            {
                label6.Text = "O(n * n)";
                textBox4.Text = ClassBubble.T(mas.Length).ToString();
                int[] buf = ClassPyramidSorting.sorting(mas, mas.Length);
                for (int i = 0; i < mas.Length; i++)
                    dataGridView4.Rows[0].Cells[i].Value = buf[i];
            }
            if (radioButton5.Checked == true)
            {
                label6.Text = "O(n * n)";
                textBox4.Text = ClassBubble.T(mas.Length).ToString();
                int[] buf = ClassInsert.SortInsertMethod(mas);
                for (int i = 0; i < mas.Length; i++)
                    dataGridView4.Rows[0].Cells[i].Value = buf[i];
            }
            if (radioButton6.Checked == true)
            {
                label6.Text = "O(n * n)";
                textBox4.Text = ClassBubble.T(mas.Length).ToString();
                int[] buf = ClassSelection.SelectionSort(mas);
                for (int i = 0; i < mas.Length; i++)
                    dataGridView4.Rows[0].Cells[i].Value = buf[i];
            }
            if (radioButton7.Checked == true)
            {
                label6.Text = "O(n log2 n)";
                textBox4.Text = ClassShell.T(mas.Length).ToString();
                int[] buf = ClassShell.shellSort(mas);
                for (int i = 0; i < mas.Length; i++)
                    dataGridView4.Rows[0].Cells[i].Value = buf[i];
            }
            if (radioButton8.Checked == true)
            {
                label6.Text = "O(n log n)";
                textBox4.Text = ClassNaturalFusion.T(mas.Length).ToString();
                int[] buf = ClassFast.quicksort(mas, 0, mas.Length - 1);
                for (int i = 0; i < mas.Length; i++)
                    dataGridView4.Rows[0].Cells[i].Value = buf[i];
            }
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            textBox2.Text = elapsedTime;            
        }

        private void оПрограмееToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }
    }
}
