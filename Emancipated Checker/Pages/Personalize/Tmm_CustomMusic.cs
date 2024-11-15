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
    public partial class Tmm_CustomMusic : UserControl
    {
        public Tmm_CustomMusic()
        {
            InitializeComponent();
        }
        SoundPlayer sp = new SoundPlayer();
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult selectedfile;
            selectedfile = openFileDialog1.ShowDialog();

            string musicLocation = Application.StartupPath + @"\resources/emancipatedsystem/themesound/Your Music/";
            openFileDialog1.InitialDirectory = musicLocation;

            if (selectedfile == DialogResult.OK)
            {
                textBox3.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sp.SoundLocation = textBox3.Text;
            sp.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Gerekli alanlar Boş Bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Gerekli alanlar Boş Bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                Properties.Settings.Default.thememusic = "yourmusic";
                Properties.Settings.Default.yourmusicpath = textBox3.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("Emancipated Checker Yeniden Başlatılacak...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
        }
    }
}
