using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeechRecognition
{
    public partial class LevelPerceptionForm : Form
    {
        public LevelPerceptionForm(Color backColor, Color foreColor)
        {
            InitializeComponent();
            levelPerceptionTrackBar.Value = Convert.ToInt32(ElsaForm.levelOfPerceptionOfSpeech * 100); //Получение текущего значения восприятия речи
            BackColor = backColor;
            levelPerceptionTrackBar.BackColor = backColor;
            ForeColor = foreColor;
        }

		//Изменение значения восприятия речи
        private void levelPerceptionTrackBar_Scroll(object sender, EventArgs e)
        {
            ElsaForm.levelOfPerceptionOfSpeech = Convert.ToDouble(levelPerceptionTrackBar.Value) / 100; //Выставление значения восприятия речи
        }

        private void LevelPerceptionForm_Load(object sender, EventArgs e)
        {
            if (ForeColor == Color.WhiteSmoke)
                okButton.ForeColor = Color.Black;
        }
    }
}
