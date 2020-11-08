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

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private string fileName = "Untitled";
        private string[] lines;
        private int linesPrinted;

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileName = "Untitled";
            textBoxEdit.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                fileName = dlgOpen.FileName;
                try
                {
                    using (StreamReader reader = File.OpenText(fileName))
                    {
                        textBoxEdit.Clear();
                        textBoxEdit.Text = reader.ReadToEnd();
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message, "Simple Editor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                fileName = dlgSave.FileName;
                try
                {
                    Stream stream = File.OpenWrite(fileName);
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write(textBoxEdit.Text);
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message, "Simple Editor",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName == "Untitled")
                saveAsToolStripMenuItem_Click(sender, e);
            else
            {
                try
                {
                    Stream stream = File.OpenWrite(fileName);
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write(textBoxEdit.Text);
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message, "Simple Editor",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgPageSetup.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {            
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            Brush brush = new SolidBrush(textBoxEdit.ForeColor);
            if (e.PageSettings.Color == false)
                brush = Brushes.Black;
            while (linesPrinted < lines.Length)
            {
                e.Graphics.DrawString(lines[linesPrinted++],
                new Font(textBoxEdit.Font, textBoxEdit.Font.Style), brush, x, y);
                y += 15;
                if (y >= e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    linesPrinted = 0;
                    e.HasMorePages = false;
                }
            }
        }    

    private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            char[] param = { '\n' };
            lines = textBoxEdit.Text.Split(param);
            int i = 0;
            char[] trimParam = { '\r' };
            foreach (string s in lines)
            {
                lines[i++] = s.TrimEnd(trimParam);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog.ShowDialog();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreviewDialog.ShowDialog();
        }

        private void textSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            textBoxEdit.Font = fontDialog1.Font;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            textBoxEdit.ForeColor = colorDialog1.Color;
        }
    }
}
