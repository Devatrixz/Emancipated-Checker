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
    public partial class SupportChatAI : Form
    {
        public SupportChatAI()
        {
            InitializeComponent();
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            string inputText = txtInput.Text;
            string response = GetResponse(inputText);
            lblResult.Text = response;
        }

        private string GetResponse(string input)
        {
            // Küçük harfe dönüştür ve trim yap
            string processedInput = input.ToLower().Trim();

            // Anahtar kelime ve cevapları belirleyin
            var responses = new Dictionary<string, string>
        {
            { "internet", "İnternet ile alakalı sorunlar için Talep oluşturun" },
            { "şifre", "Şifrenizi sıfırlamak için 'Şifremi Unuttum' bağlantısını kullanın." },
            { "hesap", "Hesap bilgilerinizi güncellemek için profil sayfanıza gidin." },
            { "fatura", "Fatura detaylarınızı görmek için fatura sayfanıza gidin." },
            { "hata", "Hatanızın amına koyyim" }
        };

            // Anahtar kelimelerden birini içeriyorsa uygun cevabı verin
            foreach (var entry in responses)
            {
                if (processedInput.Contains(entry.Key))
                {
                    return entry.Value;
                }
            }

            // Uygun cevap bulunamazsa varsayılan cevap verin
            return "Üzgünüm, sorunuzu anlayamadım. Lütfen daha fazla bilgi verin.";
        }

        private void anahtarKelimelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }
    }
}
