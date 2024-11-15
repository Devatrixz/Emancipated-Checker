using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emancipated_Checker
{
    public partial class WebHook_Manager : Form
    {
        public WebHook_Manager()
        {
            InitializeComponent();
        }

        private void WebHook_Manager_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.savedwebhook == "Yes")
            {
                checkBox1.CheckState = CheckState.Checked;
                checkBox1.Enabled = false;
                textBox3.Text = Properties.Settings.Default.webhookname;
                textBox2.Text = Properties.Settings.Default.webhookurl;
            }
        }

        public static void sendWebHook(string URL, string msg, string username)
        {
            Http.Post(URL, new NameValueCollection()
            {
                {
                    "username",
                    username
                },
                {
                    "content",
                    msg
                }

            });
        }
        int progress = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            progress++;
            if (progress == 10) 
            {
                sendWebHook(textBox2.Text, "Bu Bir Emancipated Checker Test Mesajıdır. Eğer Mesaj Gelmediyse, lütfen durun. Discord_matrixdeveloper59", textBox3.Text);
                MessageBox.Show(textBox3.Text + " hedefine bir test mesajı gönderildi.");
            }

            if (progress == 20) 
            {
                sendWebHook(textBox2.Text, "Bu Bir Emancipated Checker Test Mesajıdır. Spam tool mu arıyorsun? Discord_matrixdeveloper59", textBox3.Text);
                MessageBox.Show(textBox3.Text + " hedefine bir test mesajı gönderildi.");
            }

            if (progress == 30)
            {
                sendWebHook(textBox2.Text, "Bu Bir Emancipated Checker Test Mesajıdır. ARTIK DUR! Discord_matrixdeveloper59", textBox3.Text);
                MessageBox.Show(textBox3.Text + " hedefine bir test mesajı gönderildi.");
            }

            if (progress == 40)
            {
                sendWebHook(textBox2.Text, "Bu Bir Emancipated Checker Test Mesajıdır. DURRRR!", textBox3.Text);
                MessageBox.Show(textBox3.Text + " hedefine bir test mesajı gönderildi.");
            }

            if (progress == 45)
            {
                timer1.Start();
                sendWebHook(textBox2.Text, "Bu Bir Emancipated Checker Test Mesajıdır. DURRRR!", textBox3.Text);
                MessageBox.Show(textBox3.Text + " hedefine SPAM BAŞLATILDI!");
            }
            sendWebHook(textBox2.Text, "Bu Bir Emancipated Checker Test Mesajıdır. Eğer Mesaj Gelmediyse, URL yi gözden geçirin veya destek ekibimize başvurun. Discord_matrixdeveloper59", textBox3.Text);
            MessageBox.Show(textBox3.Text + " hedefine bir test mesajı gönderildi.");
        }

        private void label7_Click(object sender, EventArgs e)
        {
            MessageBox.Show(label7.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label6.Text = textBox3.Text;
            label7.Text = textBox2.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox1.Enabled = false;
                Properties.Settings.Default.webhookname = textBox2.Text;
                Properties.Settings.Default.webhookurl = textBox3.Text;
                Properties.Settings.Default.savedwebhook = "Yes";
                Properties.Settings.Default.Save();
            }
        }

        private void kayıtlıVeriyiSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult quest1;
            quest1 = MessageBox.Show("Webhook kaydını silmeniz durumunda tekrar oluşturmanız gerekecektir. Devam etmek istiyor musunuz?","Webhook kaydını sil", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (quest1 == DialogResult.Yes) 
            {
                Properties.Settings.Default.webhookname = "";
                Properties.Settings.Default.webhookurl = "";
                Properties.Settings.Default.savedwebhook = "No";
                checkBox1.Checked = false;
                checkBox1.Enabled = true;
                textBox2.Text = "";
                textBox3.Text = "";
                Properties.Settings.Default.Save();
            }
        }

        private void veriyiGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Properties.Settings.Default.webhookname + " <-- Webhook adınız" + Properties.Settings.Default.webhookurl + " <-- Webhook URL niz");
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            sendWebHook(textBox2.Text, "Bu Bir Emancipated Checker Test Mesajıdır. " + i, textBox3.Text);
        }

        private void WebHook_Manager_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                timer1.Stop();
                MessageBox.Show("Durduğun için teşekkürler. Umarım hesabın kapatılmamıştır.");
                progress = 0;
            }
        }

        private void herZamanÜstteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (herZamanÜstteToolStripMenuItem.Checked == false)
            {
                herZamanÜstteToolStripMenuItem.Checked = true;
                this.TopMost = true;
            }
            else 
            {
                herZamanÜstteToolStripMenuItem.Checked = false;
                this.TopMost = false;
            }
        }
    }
}
