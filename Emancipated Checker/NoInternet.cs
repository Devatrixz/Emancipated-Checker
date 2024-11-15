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
    public partial class NoInternet : Form
    {
        public NoInternet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MernisChecker mr = new MernisChecker();
            mr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void NoInternet_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
