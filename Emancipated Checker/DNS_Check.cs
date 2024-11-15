using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Emancipated_Checker
{

    public partial class DDOS_Attack : Form
    {
        public DDOS_Attack()
        {
            InitializeComponent();
        }
        int sendedvalue = 0;

        private Ping p = new Ping();
        private int sayac;
        private string durum = "";
        private string adress = "";
        private string zaman = "";
        private string sonuc = "";
        private long pingAdet = 10;
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            lst_sonuc.Items.Clear();
            sendedvalue = 0;
            timer1.Interval = Convert.ToInt32(maskedTextBox1.Text);
            progressBar1.Style = ProgressBarStyle.Marquee;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if (sayac >= pingAdet)
            {
                lst_sonuc.Items.Add("--------------" + Environment.NewLine);
                lst_sonuc.Items.Add(sonuc + Environment.NewLine);
                lst_sonuc.Items.Add("--------------" + Environment.NewLine);
                timer1.Stop();
                timer1.Enabled = false;
            }
            else
            {
                try
                {
                    PingReply reply = p.Send(txt_adres.Text);
                    durum = reply.Status.ToString();
                    adress = reply.Address.ToString();
                    zaman = reply.RoundtripTime.ToString();
                    lst_sonuc.Items.Add(string.Format("Sonuç : {0} {1} -> {2} ms.", durum, adress, zaman + Environment.NewLine));
                    sendedvalue++;
                    label1.Text = "Gönderilen Veri: " + sendedvalue + " BIT";
                    sonuc = "Ping başarı ile tamamlandı";
                }
                catch (PingException)
                {
                    lst_sonuc.Items.Add("Bilinen böyle bir ana bilgisayar yok" + Environment.NewLine);
                    sonuc = "Bir veya daha fazla Ping denemesi başarısız oldu";
                    panel1.Show();
                    label11.Text = "Bilinen böyle bir ana bilgisayar yok";
                    progressBar1.Style = ProgressBarStyle.Blocks;
                    timer1.Stop();
                }
                catch (NullReferenceException)
                {
                    lst_sonuc.Items.Add("Saldırı Başarısız Oldu. Adres yanlış olabilir." + Environment.NewLine);
                    sonuc = "Bir veya daha fazla Ping denemesi başarısız oldu";
                    panel1.Show();
                    label11.Text = "Saldırı Başarısız Oldu. Adres yanlış olabilir.";
                    progressBar1.Style = ProgressBarStyle.Blocks;
                    timer1.Stop();
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_sinirsiz_ping.CheckState == CheckState.Checked)
            {
                pingAdet = 9999999999;
                txt_ping_adet.Text = "9999999999";
                txt_ping_adet.Enabled = false;
            }
            else
            {
                txt_ping_adet.Text = "10";
                pingAdet = Convert.ToInt32(txt_ping_adet.Text);
                txt_ping_adet.Enabled = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            timer1.Stop();
            progressBar1.Style = ProgressBarStyle.Blocks;
            sonuc = "Ping başarı ile tamamlandı";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Hide();
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

        private void DDOS_Attack_Load(object sender, EventArgs e)
        {

        }
    }
}
