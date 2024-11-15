using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emancipated_Checker
{
    public partial class MernisChecker_Home : UserControl
    {
        public MernisChecker_Home()
        {
            InitializeComponent();
        }

        private void MernisChecker_Home_Load(object sender, EventArgs e)
        {
            loginLabel.Text = "Kaç kere giriş yaptı: " + Properties.Settings.Default.loginLevel.ToString();
            basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks.ToString();
            yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels.ToString();
            paniclabel.Text = "Panic Seviyesi: " + Properties.Settings.Default.panicLevel.ToString();

            if (Properties.Settings.Default.purchased == "Yes")
            {
                kayitlabel.Text = "Abonelik: Abonelik Mevcut";
            }
        }
    }
}
