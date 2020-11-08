using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class TestButtonsForm : Form
    {
        public TestButtonsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strMessage = "";
            if (radioButton1.Checked == true)
            {
                strMessage = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                strMessage = radioButton2.Text;
            }
            else if (radioButton3.Checked == true)
            {
                strMessage = radioButton3.Text;
            }
            if (checkBox1.Checked == true)
                MessageBox.Show("Вы выбрали " + strMessage);

        }
    }
}
