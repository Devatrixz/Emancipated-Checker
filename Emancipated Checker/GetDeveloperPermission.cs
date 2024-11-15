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
    public partial class GetDeveloperPermission : Form
    {
        public GetDeveloperPermission()
        {
            InitializeComponent();
        }
        int hackcount = 0;
        string[] validSerialKeys = { "VVDCC-GMGWC-M74CA-G5MFY-C2978", "9MFWH-ACZER-RV3AD-CCDHP-2FMRC", "VY6C5-EBMDC-CA3CH-MG77A-P434A", "KHCYN-CTECC-CNPCA-5ZZ5Z-B59A9" };
        private void button1_Click(object sender, EventArgs e)
        {
            if (Array.Exists(validSerialKeys, key => key == textBox1.Text))
            {
                Properties.Settings.Default.developerpermission = "Yes";
                Properties.Settings.Default.Save();
                MessageBox.Show("Geliştirici izinleri açıldı", "Teşekkürler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
            else 
            {
                MessageBox.Show("Geliştirici izinleri açılmadı. Kod yanlış. Bence kodunu kontrol et ve yeniden dene. Sağın solun belli olmaz.", "Kod yanlış...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hackcount++;

                if (hackcount == 10) 
                {
                    MessageBox.Show("Kod halen yanlış. 10 kere yanlış kod girdin. Eğer birşeyler deniyorsan dur ve teslim ol. Her an IP adresini polislere verebiliriz. Dikkat et!", "Tespit edildin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (hackcount == 20) 
                {
                    MessageBox.Show("Sen normal bir kullanıcı değilsin. Birşeyler peşindesin. Elimizdesin.", "Bize bunu yaptırma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (hackcount == 30)
                {
                    MessageBox.Show("Makine adı: " + Environment.MachineName, "Bize bunu yaptırma... Anladın mı?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Dur! yoksa durdururuz!", "Bize bunu yaptırma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (hackcount == 40) 
                {
                    MessageBox.Show("Bunu sen istedin...", "Artık çok geç", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Properties.Settings.Default.Locked = "Yes_HackReason";
                    Properties.Settings.Default.Save();
                    Application.Restart();
                }
            }
        }
    }
}
