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
    public partial class AccountManager : Form
    {
        public AccountManager()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LoadPage(UserControl page)
        {
            panelContainer.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(page);
        }

        private void AccountManager_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Acc_LoginLevel == "Yes")
            {
                LoadPage(new Emancipated_Checker.Pages.AccMan_Home());
            }
            else 
            {
                LoadPage(new Emancipated_Checker.Pages.AccMan_SignUp());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Acc_LoginLevel == "Yes")
            {
                LoadPage(new Emancipated_Checker.Pages.AccMan_Home());
            }
            else
            {
                LoadPage(new Emancipated_Checker.Pages.AccMan_SignUp());
            }
        }
    }
}
