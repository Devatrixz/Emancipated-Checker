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
    public partial class Buy : Form
    {
        public Buy()
        {
            InitializeComponent();
        }
        string[] validSerialKeys = { "WZWJX-BCZER-RT4WC-CCMC5-BDBB5", "VY69C-3CCYM-C6FCM-CHAMH-Q8ER2", "9MAM4-ZU4CC-HCBCA-ALCDK-9F97E", "CCUVV-BDCCC-ZGC5C-66KMD-A5844", "5CZER-W4ACC-U2JC5-DLDCH-BBRC7", "CHZ5C-WUVVA-DKRCC-CHCLW-LFR2D" };
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            progressBar1.Style = ProgressBarStyle.Marquee;
            groupBox1.Show();
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;

            if (i == 100) 
            {
                timer1.Stop();
                if (Array.Exists(validSerialKeys, key => key == textBox1.Text))
                {
                    Properties.Settings.Default.purchased = "Yes";
                    Properties.Settings.Default.userCount = 99999;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Emancipated Checker Satın Aldığınız İçin Teşekkürler! Uygulama Yeniden Başlatılacak.", "Teşekkürler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                }
                else
                {
                    MessageBox.Show("Yanlış key girdiniz. Yeniden deneyin.", "Yanlış key", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    groupBox1.Hide();
                    i = 0;
                }
            }
        }

        private void Buy_Load(object sender, EventArgs e)
        {
            InternetKontrol();
        }

        private void Buy_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.userCount < 1) 
            {
                Application.Exit();
            }
        }

        public bool InternetKontrol()
        {
            try
            {
                System.Net.Sockets.TcpClient kontrol_client = new System.Net.Sockets.TcpClient("www.google.com.tr", 80);
                kontrol_client.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Internete Bağlı Değilsiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Restart();
                return false;
            }
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
