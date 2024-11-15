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
    public partial class GetToken : Form
    {
        public GetToken()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" && textBox2.Text == "")
            {
               MessageBox.Show("Hesap Bilgieri olmadan nasıl tokeni bulacaksın?", "Hesap bilgileri eksik", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                processTimer.Start();
                process = 0;
                button1.Text = "Durdur";
                button1.Visible = false;
            }

                

        }
        int process = 0;
        bool idVerifty;
        StringBuilder StrBuild = new StringBuilder();
        private void processTimer_Tick(object sender, EventArgs e)
        {
            process++;
            progressBar1.Value = process;

            if (process == 10) 
            {
                if (textBox2.TextLength == 19)
                {
                    listBox1.Items.Add("ID Geçerlilik koşullarını karşılıyor.");
                    idVerifty = true;
                }
                else if (textBox2.TextLength < 19) 
                {
                    listBox1.Items.Add("ID normalden daha kısa veya girilmemiş. (Xc43861)");
                    processTimer.Stop();
                    panel1.Show();
                    label5.Text = "ID girilmesi gereken uzunluktan daha kısa veya girilmemiş.";
                }

                if (textBox2.TextLength > 19)
                {
                    listBox1.Items.Add("ID normalden daha uzun. (Xc94381)");
                    processTimer.Stop();
                    panel1.Show();
                    label5.Text = "ID girilmesi gereken uzunluktan daha uzun.";
                }
            }

            if (process == 50 && idVerifty == true) 
            {
                listBox1.Items.Add("ID Tokene çevrilirken bekleyin.");
            }

            if (process == 99 && idVerifty == true) 
            {
                listBox1.Items.Add("Token alım method, nextcord tarafından desteklenmiyor veya indirilmemiş. (XcERR0000xc932)");
                processTimer.Stop();
                panel1.Show();
                label5.Text = "Hesabın alım methodu, uygulama methodu aracı olan nextcord tarafından desteklenmiyor veya indirilmemiş.";
                System.Diagnostics.Process.Start("https://docs.nextcord.dev/en/stable/");


            }
        }

        private void GetToken_Load(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            process = 0;
            processTimer.Start();
            panel1.Hide();
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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                MessageBox.Show("Bu özelliği kullanabilmek için Ultimate Sürüm satın alın.");
                radioButton2.Checked = false;
                radioButton1.Checked = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                MessageBox.Show("Bu özelliği kullanabilmek için Ultimate Sürüm satın alın.");
                radioButton3.Checked = false;
                radioButton1.Checked = true;
            }
        }
    }
}
