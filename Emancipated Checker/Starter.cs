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
    public partial class Starter : Form
    {
        public Starter()
        {
            InitializeComponent();
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;

            if (i == 10) 
            {
                label2.Text = "Sahiplik kontrol ediliyor...";
            }

            if (i == 50)
            {
                label2.Text = "Hizmetler yükleniyor...";
            }

            if (i == 60)
            {
                label2.Text = "Özellikler yükleniyor...";
            }
            if (i == 70)
            {
                label2.Text = "Webhooklar ayarlanıyor...";
            }
            if (i == 80)
            {
                label2.Text = "Dizin yükleniyor...";
                label3.Visible = true;
            }

            if (i == 150)
            {
                timer1.Stop();
                Form1 f1 = new Form1();
                this.Hide();
                f1.Show();
            }
        }

        private void Starter_Load(object sender, EventArgs e)
        {

        }
    }
}
