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
    public partial class IP_Check : Form
    {
        public IP_Check()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.purchased = "No";
            Properties.Settings.Default.loginLevel = 0;
            Properties.Settings.Default.sucsessHacks = 0;
            Properties.Settings.Default.hackLevels = 0;
            Properties.Settings.Default.panicLevel++;
            Properties.Settings.Default.Save();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength > 72)
            {
                listBox1.Items.Add("Token Girilmesi Gereken Uzunluktan Daha Uzun. Xcf7430900");
                panel1.Show();
                label11.Text = "Token Girilmesi Gereken Uzunluktan Daha Uzun.";
            }
            else 
            {
                listBox1.Items.Add("Token Girilmesi Gereken Uzunluktan Daha Kısa. Xcf7454900");
                panel1.Show();
                label11.Text = "Token Girilmesi Gereken Uzunluktan Daha Kısa.";
            }

            if (textBox2.TextLength == 72)
            {
                panel1.Hide();
                label8.Text = "Hedef Kilitlendi.";
                label9.Text = textBox2.Text;
                label10.Text = "IP Analiz Hazır Durumda.";
                MessageBox.Show("Token Uzunluğu Doğrulandı: " + textBox2.TextLength.ToString());
                listBox1.Items.Remove("Token Girilmesi Gereken Uzunluktan Daha Uzun. Xcf7430900");
            }

        }

        private void IP_Check_Load(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            MessageBox.Show(label9.Text);
        }

        private void wLANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label3.Text = "Alım Methodu WLAN olarak ayarlandı";
        }

        private void sSIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label3.Text = "Alım Methodu SSID olarak ayarlandı";
        }

        private void exeÇıktısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label3.Text = "Alım Methodu .exe Çıktısı olarak ayarlandı";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Seçilmeyen öğeyi null olarak mı gösterelim? Bir öğe seç.");
            }
            else
            {
                MessageBox.Show(listBox1.Items[listBox1.SelectedIndex].ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (label3.Text == "Bir Method Seçin")
            {
                listBox2.Items.Add("Saldırı methodu seçmediniz. Bir saldırı methodu seçin.");
            }
            else if (textBox1.Text == "" && textBox2.TextLength == 72)
            {
                timer1.Start();
            }
            else 
            {
                listBox2.Items.Add("Bilgiler yanlış veya boş.");
                panel1.Show();
                label11.Text = "Bilgiler yanlış veya boş.";
            }

           
        }
        int i = 0;
        int data = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            progressBar1.Value = i;

            if (i == 10) 
            {
                listBox2.Items.Add("Hedef Kullanıcı Bulundu.");
            }

            if (i == 20)
            {
                data = 55;
                listBox2.Items.Add("Veriler Alındı = 55 MB Çerezler");
                label1.Text = data + "MB Alındı";
                timer1.Interval = 500;
            }

            if (i == 40)
            {
                listBox2.Items.Add("Hedef Enjekte sırasında Bilinmeyen hata. Destek ile iletişime geçin. Xcf5577329");
                panel1.Show();
                label11.Text = "Hedef Enjekte sırasında Bilinmeyen hata. Destek ile iletişime geçin.";
                timer1.Stop();
                progressBar1.Value = 0;
                i = 0;
                data = 0;
                timer1.Interval = 100;
            }
        }
    }
}
