using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Emancipated_Checker
{
    public partial class SupportTicketForm : Form
    {
        public SupportTicketForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(bilmenizgerekenlertext);
        }

        public static string bilmenizgerekenlertext = @"1- Hiçbir kişisel bilgi paylaşmayın
2- Destek yazısına küfür, hakaret ve diğer kötü amaçlı anlamlar içeren kelimeleri eklemeyin
3- Talebinizi sürekli tekrarlamayın
4- Satın almış olduğunuz seri anahtarını kaybetmeniz durumunda yeni bir seri anahtarı istemeye çalışmayın.
Sadece kaybettim gibi birşeyler yazın. Biz gerekeni yaparız.

Destek ekibimiz, bu kurallara uymama doğrultusunda doğan olaylardan sorumlu değildir.
Destek ekibimiz, talepleri reddetme, sert çıkış, ve ihbar hakkını gizli tutar

Destek talebiniz bize Discord üzerinden bir bot ile mesaj yoluyla iletilecek. Ama sizin Discorda girmeniz gerekmeyecek.";

        private async void btnCreateSupportRequest_Click(object sender, EventArgs e)
        {
            // TextBox'ların boş olup olmadığını ve eposta alanının geçerli olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(txtAd.Text) ||
                string.IsNullOrWhiteSpace(txtSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtEposta.Text) ||
                string.IsNullOrWhiteSpace(txtUygulamaSurumu.Text) ||
                string.IsNullOrWhiteSpace(txtNeOldu.Text) ||
                string.IsNullOrWhiteSpace(txtNeYapmamiziIstersiniz.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidEmail(txtEposta.Text))
            {
                MessageBox.Show("Geçerli bir e-posta adresi girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Properties.Settings.Default.supportCooldown < 1)
            {
                // Discord webhook URL'si
                string webhookUrl = "https://discord.com/api/webhooks/1227555448132206614/ilxyRtftngUHMNrKIseGxXAsyoLhgm_FhIeycqG-85Z4ANBfzv2FJXlMTRgcOZ0pKvQg";

                // Kullanıcıdan alınan bilgiler
                string tarih = dateTimePickerTarih.Value.ToString("dd.MM.yyyy");
                string ad = txtAd.Text;
                string soyad = txtSoyad.Text;
                string eposta = txtEposta.Text;
                string uygulamaSurumu = txtUygulamaSurumu.Text;
                string neOldu = txtNeOldu.Text;
                string neYapmamiziIstersiniz = txtNeYapmamiziIstersiniz.Text;

                // Destek talebi mesajı
                string destekTalebiMesaji = $"**Destek Talebi**\n\n" +
                                            $"**Tarih:** {tarih}\n" +
                                            $"**Ad:** {ad}\n" +
                                            $"**Soyad:** {soyad}\n" +
                                            $"**E-posta:** {eposta}\n" +
                                            $"**Uygulama Sürümü:** {uygulamaSurumu}\n\n" +
                                            $"**Ne Oldu?**\n{neOldu}\n\n" +
                                            $"**Bu konuda ne yapmamızı istersiniz?**\n{neYapmamiziIstersiniz}";

                // Webhook talebi gönderme
                await SendWebhookMessage(webhookUrl, destekTalebiMesaji);
            }
            else
            {
                MessageBox.Show("Önceden zaten destek talebi oluşturdunuz. Lütfen birkaç gün bekleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        private async Task SendWebhookMessage(string webhookUrl, string message)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(new { content = message }), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(webhookUrl, content);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Webhook gönderme başarısız. HTTP kodu: {response.StatusCode}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Destek talebi başarıyla oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Properties.Settings.Default.supportCooldown = 3;
                    Properties.Settings.Default.Save();
                    ClearTextBoxes();
                }
            }
        }

        private void ClearTextBoxes()
        {
            // TextBox'ları temizle
            foreach (Control control in Controls)
            {
                if (control is TextBox)
                {
                    control.Text = string.Empty;
                }
            }
        }


    }
}
