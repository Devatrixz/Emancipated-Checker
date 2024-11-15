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
    public partial class Customise : Form
    {
        public Customise()
        {
            InitializeComponent();
        }

        private void Customise_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.theme = "black";
            Properties.Settings.Default.Save();
            Application.Restart();
        }
    }
}
