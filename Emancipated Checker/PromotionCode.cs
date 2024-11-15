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
    public partial class PromotionCode : Form
    {
        public PromotionCode()
        {
            InitializeComponent();
        }
        string[] validSerialKeys = { "XDAW","OJKD","EHFD","999A","UGTE","874J","PPOA","PORN","DARK","3162","OUYU","ERTG","ASDA","FGHY" };
        private void button1_Click(object sender, EventArgs e)
        {
            if (Array.Exists(validSerialKeys, key => key == textBox1.Text))
            {
                Properties.Settings.Default.promotion = "matrixteam";
                Properties.Settings.Default.Save();
                MessageBox.Show("Kod başarıyla aktifleştirildi!", "Teşekkürler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Yanlış promosyon kodu girdiniz. Yeniden deneyin.", "Yanlış kod", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
    }
}
