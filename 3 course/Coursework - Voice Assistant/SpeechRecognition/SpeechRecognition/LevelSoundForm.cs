using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CoreAudioApi;
using System.Diagnostics;

namespace SpeechRecognition
{
    public partial class LevelSoundForm : Form
    {
        private MMDevice device; //Устройство динамиков
        MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();

        //Пути расположения ICO
        static string pathFileInProject = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        static string mutePNG = pathFileInProject + "\\img\\ico\\mute.png";
        static string onPNG = pathFileInProject + "\\img\\ico\\on.png";

        //Значения уровней громкости
        private int saveVolumeValue1 = 0;
        private int saveVolumeValue2 = 0;

        public LevelSoundForm(Color color, Color foreColor)
        {
            InitializeComponent();
            BackColor = color;
            ForeColor = foreColor;
            //Инициализация устройства динамиков
            device = DevEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
            device.AudioEndpointVolume.OnVolumeNotification += new AudioEndpointVolumeNotificationDelegate(AudioEndpointVolume_OnVolumeNotification);
        }

        //Получение значений в trackBar'ы
        void AudioEndpointVolume_OnVolumeNotification(AudioVolumeNotificationData data)
        {
            if (levelGeneralSoundTrackBar.InvokeRequired)
            {
                levelGeneralSoundTrackBar.Invoke(new MethodInvoker(delegate
                {
                    levelGeneralSoundTrackBar.Value = (int)(data.MasterVolume * 100);
                }));
            }
            else
            {
                levelGeneralSoundTrackBar.Value = (int)(data.MasterVolume * 100);
            }
        }

        //Изменение значения уровня громкости динамиков
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            device.AudioEndpointVolume.MasterVolumeLevelScalar = (float)levelGeneralSoundTrackBar.Value / 100;
        }

        //Инициализация при запуске текущих значений уровней громкости
        private void LevelSoundForm_Load(object sender, EventArgs e)
        {
            if (ForeColor == Color.WhiteSmoke)
                okButton.ForeColor = Color.Black;
            levelGeneralSoundTrackBar.Value = Convert.ToInt32(device.AudioEndpointVolume.MasterVolumeLevelScalar * 100);
            levelProgramSoundTrackBar.Value = 65;
            if (levelGeneralSoundTrackBar.Value == 0)
                muteImg1.Image = Image.FromFile(mutePNG);
            if (levelProgramSoundTrackBar.Value == 0)
                muteImg2.Image = Image.FromFile(mutePNG);
        }        

        //Вкл./откл. звука динамиков
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (saveVolumeValue1 == 0)
            {
                saveVolumeValue1 = levelGeneralSoundTrackBar.Value;
                levelGeneralSoundTrackBar.Value = 0;
            }
            else
            {
                levelGeneralSoundTrackBar.Value = saveVolumeValue1;
                saveVolumeValue1 = 0;                
            }
        }

        //Прогрузка типа ICO для динамиков
        private void levelSoundTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (levelGeneralSoundTrackBar.Value != 0)
                muteImg1.Image = Image.FromFile(onPNG);
            else
                muteImg1.Image = Image.FromFile(mutePNG);
        }

        //Изменение значения уровня громкости программы
        private void levelProgramSoundTrackBar_Scroll(object sender, EventArgs e)
        {
            PC_VolumeControl.VolumeControl.SetVolume(levelProgramSoundTrackBar.Value * 1000);            
        }

        //Прогрузка типа ICO для программы
        private void levelProgramSoundTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (levelProgramSoundTrackBar.Value != 0)
                muteImg2.Image = Image.FromFile(onPNG);
            else
                muteImg2.Image = Image.FromFile(mutePNG);            
        }

        //Вкл./откл. звука программы
        private void muteImg2_Click(object sender, EventArgs e)
        {
            if (saveVolumeValue2 == 0)
            {
                saveVolumeValue2 = levelProgramSoundTrackBar.Value;
                levelProgramSoundTrackBar.Value = 0;
            }
            else
            {
                levelProgramSoundTrackBar.Value = saveVolumeValue2;
                saveVolumeValue2 = 0;
            }
        }

        //Открытие микшера громкости
        private void DynamicImg_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("SndVol.exe"));
        }

        //Отображение рамки при наведении мыши динамиков
        private void DynamicImg_MouseHover(object sender, EventArgs e)
        {
            DynamicImg.Height = 47;
            DynamicImg.Width = 47;
            DynamicImg.Location = new Point(32, 50);
            DynamicImg.BorderStyle = BorderStyle.FixedSingle;
        }
		
        //Скрытие рамки при отведении мыши динамиков
        private void DynamicImg_MouseLeave(object sender, EventArgs e)
        {
            DynamicImg.Height = 45;
            DynamicImg.Width = 45;
            DynamicImg.Location = new Point(33, 51);
            DynamicImg.BorderStyle = BorderStyle.None;
        }
		
        //Отображение рамки при наведении мыши значка громкости 1
        private void muteImg1_MouseHover(object sender, EventArgs e)
        {
            muteImg1.Height = 34;
            muteImg1.Width = 36;
            muteImg1.Location = new Point(35, 533);
            muteImg1.BorderStyle = BorderStyle.FixedSingle;
        }
		
        //Отображение рамки при наведении мыши значка громкости 2
        private void muteImg2_MouseHover(object sender, EventArgs e)
        {
            muteImg2.Height = 34;
            muteImg2.Width = 36;
            muteImg2.Location = new Point(150, 533);
            muteImg2.BorderStyle = BorderStyle.FixedSingle;
        }
		
        //Скрытие рамки при отведении мыши значка громкости 1
        private void muteImg1_MouseLeave(object sender, EventArgs e)
        {
            muteImg1.Height = 34;
            muteImg1.Width = 36;
            muteImg1.Location = new Point(36, 534);
            muteImg1.BorderStyle = BorderStyle.None;
        }
		
        //Скрытие рамки при отведении мыши значка громкости 2
        private void muteImg2_MouseLeave(object sender, EventArgs e)
        {
            muteImg2.Height = 34;
            muteImg2.Width = 36;
            muteImg2.Location = new Point(151, 534);
            muteImg2.BorderStyle = BorderStyle.None;
        }
    }
}