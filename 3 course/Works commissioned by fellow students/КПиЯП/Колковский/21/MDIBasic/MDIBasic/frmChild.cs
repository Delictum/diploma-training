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

namespace MDIBasic
{
    public partial class frmChild : Form
    {
        public frmChild(MDIBasic.frmContainer parent, string caption)
        {
            InitializeComponent();
            this.MdiParent = parent;
            this.Text = caption;
        }

        private void полужирныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font newFont = new Font(richTextBox2.SelectionFont,
                (richTextBox2.SelectionFont.Bold ? //2
                richTextBox2.SelectionFont.Style & ~FontStyle.Bold : //3
                richTextBox2.SelectionFont.Style | FontStyle.Bold)); //4
            richTextBox2.SelectionFont = newFont; //5

        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox2.Clear();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Text == null)
                return;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                string fileText = File.ReadAllText(filename);
                richTextBox2.Text = fileText;
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Text == null)
                return;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                File.WriteAllText(filename, richTextBox2.Text);
            }
        }

        private void курсивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font newFont = new Font(richTextBox2.SelectionFont,
                (richTextBox2.SelectionFont.Italic ? //2
                richTextBox2.SelectionFont.Style & ~FontStyle.Italic : //3
                richTextBox2.SelectionFont.Style | FontStyle.Italic)); //4
            richTextBox2.SelectionFont = newFont; //5
        }

        private void подчеркнутыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font newFont = new Font(richTextBox2.SelectionFont,
                (richTextBox2.SelectionFont.Underline ? //2
                richTextBox2.SelectionFont.Style & ~FontStyle.Underline : //3
                richTextBox2.SelectionFont.Style | FontStyle.Underline)); //4
            richTextBox2.SelectionFont = newFont; //5
        }
    }
}
