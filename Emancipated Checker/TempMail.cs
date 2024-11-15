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
    public partial class TempMail : Form
    {
        public TempMail()
        {
            InitializeComponent();
        }

        private void TempMail_Load(object sender, EventArgs e)
        {
            LoadPage(new Emancipated_Checker.Pages.MailSys.TempMail_MailBox());
        }

        private void LoadPage(UserControl page)
        {
            panelContainer.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(page);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
