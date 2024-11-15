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
    public partial class AccMan_SignUp : UserControl
    {
        public AccMan_SignUp()
        {
            InitializeComponent();
        }
        string[] validSerialKeys = { "emancipated", "WNXS", "1905", "matrixdeveloper", "DARKER" };

        private void button1_Click(object sender, EventArgs e)
        {
            if (Array.Exists(validSerialKeys, key => key == textBox3.Text))
            {
                Properties.Settings.Default.Acc_Username = textBox1.Text;
                Properties.Settings.Default.Acc_Password = textBox4.Text;
                Properties.Settings.Default.Acc_Mail = textBox2.Text;
                Properties.Settings.Default.Acc_LoginLevel = "Yes";
                Properties.Settings.Default.Save();
                MessageBox.Show("Hesabınızı kaydetmek için Emancipated Checker yeniden başlatılacak", "Yeniden başlatma uyarsı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
            else
            {
                MessageBox.Show("Yanlış referans key girdiniz. Yeniden deneyin.", "Yanlış referans key", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
