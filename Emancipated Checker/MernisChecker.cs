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
    public partial class MernisChecker : Form
    {
        public MernisChecker()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MernisChecker_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.mernisLogin == "Yes")
            {
                LoadPage(new MernisChecker_Home());
            }
            else 
            {
                LoadPage(new MernisChecker_Login());
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void LoadPage(UserControl page)
        {
            panelContainer.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(page);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadPage(new MernisChecker_Home());
            this.MaximizeBox = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadPage(new MernisChecker_Sorgula());
            this.MaximizeBox = false;
        }
    }
}
