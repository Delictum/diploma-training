using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIBasic
{
    public partial class frmContainer : Form
    {
        private int nextFormNumber = 1;

        public frmContainer()
        {
            InitializeComponent();
            MDIBasic.frmChild child = new MDIBasic.frmChild(this, "Редактор 1");
            child.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void создатьНовоеОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild newChild = new frmChild(this, "Редактор" + ++nextFormNumber);
            newChild.Show();
        }

        private void плиткаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void каскадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild frm = (frmChild)this.ActiveMdiChild;
            if (frm != null)            
                frm.Close();
        }
    }
}
