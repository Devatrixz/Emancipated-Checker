using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emancipated_Checker.Pages
{
    public partial class AccMan_Home : UserControl
    {
        public AccMan_Home()
        {
            InitializeComponent();
        }

        string readmepath = Application.StartupPath + @"\resources/emancipatedsystem/avatar/profile-picture/Beni Oku.txt";
        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Acc_LoginLevel = "No";
            Properties.Settings.Default.Save();
            AccountManager acc = new AccountManager();
            acc.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult quest;
            quest = MessageBox.Show("Emancipated ID silmek istediğinden emin misin? Daha önce satın aldığın bir mağaza öğesinin ayrıcalıklarından faydalanamayacaksın ve Güvenlik ile alakalı sorunlar ile karşılaşma durumunda destek almayacaksın.","ID silme talebi",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);

            if (quest == DialogResult.Yes) 
            {
                Properties.Settings.Default.Acc_LoginLevel = "No";
                Properties.Settings.Default.Acc_Password = "";
                Properties.Settings.Default.Acc_Username = "";
                Properties.Settings.Default.Save();
                AccountManager acc = new AccountManager();
                acc.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PromotionCode promo = new PromotionCode();
            promo.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ThemeMusicSettings thm = new ThemeMusicSettings();
            thm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Customise custom = new Customise();
            custom.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(readmepath);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            requirementsscan req = new requirementsscan();
            req.ShowDialog();
        }
    }
}
