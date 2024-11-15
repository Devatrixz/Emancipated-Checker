using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Emancipated_Checker.Pages.Personalize
{
    public partial class Tmm_Something_Sensible : UserControl
    {
        public Tmm_Something_Sensible()
        {
            InitializeComponent();
        }
        SoundPlayer sp = new SoundPlayer();
        private void Tmm_Something_Sensible_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.thememusic = "sensible";
            Properties.Settings.Default.Save();
            MessageBox.Show("Emancipated Checker Yeniden Başlatılacak...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string music = Application.StartupPath + @"\resources/emancipatedsystem/themesound/emancipated/main/something_sensible.wav";
            sp.SoundLocation = music;
            sp.Play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sp.Stop();
        }
    }
}
