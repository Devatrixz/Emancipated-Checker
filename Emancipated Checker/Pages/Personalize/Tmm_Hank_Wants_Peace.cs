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
    public partial class Tmm_Hank_Wants_Peace : UserControl
    {
        public Tmm_Hank_Wants_Peace()
        {
            InitializeComponent();
        }
        SoundPlayer sp = new SoundPlayer();
        private void button2_Click(object sender, EventArgs e)
        {
            string music = Application.StartupPath + @"\resources/emancipatedsystem/themesound/emancipated/main/Hank_Wants_Peace.wav";
            sp.SoundLocation = music;
            sp.Play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sp.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.thememusic = "hank-wants";
            Properties.Settings.Default.Save();
            MessageBox.Show("Emancipated Checker Yeniden Başlatılacak...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }
    }
}
