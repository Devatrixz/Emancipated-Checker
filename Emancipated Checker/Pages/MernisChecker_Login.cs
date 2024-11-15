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
    public partial class MernisChecker_Login : UserControl
    {
        public MernisChecker_Login()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.emancipatedglobal.wuaze.com");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "XDAJ-JSUB-82NL-JA81") 
            {
                Properties.Settings.Default.mernisLogin = "Yes";
                Properties.Settings.Default.Save();
                MessageBox.Show("Şimdi Ana sayfaya geçebilirsiniz.");
            }
        }
    }
}
