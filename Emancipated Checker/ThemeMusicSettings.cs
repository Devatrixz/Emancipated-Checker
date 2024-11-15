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

namespace Emancipated_Checker
{
    public partial class ThemeMusicSettings : Form
    {
        public ThemeMusicSettings()
        {
            InitializeComponent();
        }
        SoundPlayer sp = new SoundPlayer();
        private void LoadPage(UserControl page)
        {
            panelContainer.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(page);
        }

        private void ThemeMusicSettings_Load(object sender, EventArgs e)
        {
            LoadPage(new Emancipated_Checker.Pages.Personalize.Tmm_Menu());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadPage(new Emancipated_Checker.Pages.Personalize.Tmm_Menu());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadPage(new Emancipated_Checker.Pages.Personalize.Tmm_Something_Sensible());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadPage(new Emancipated_Checker.Pages.Personalize.Tmm_Hank_Wants_Peace());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadPage(new Emancipated_Checker.Pages.Personalize.Tmm_CustomMusic());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadPage(new Emancipated_Checker.Pages.Personalize.Tmm_Emancipated());
        }
    }
}
