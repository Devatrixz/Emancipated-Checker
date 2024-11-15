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
    public partial class CancelPurchase : Form
    {
        public CancelPurchase()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.userCount = 30;
            Properties.Settings.Default.purchased = "No";
            Properties.Settings.Default.Save();
            MessageBox.Show("Emancipated Checker Aboneliğini istediğin zaman önceden kullandığın key ile tekrardan aktifleştirebilirsin. Uygulama yeniden başlatılacak.", "Hatırlatma", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }
    }
}
