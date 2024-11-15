using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libKimlik;

namespace Emancipated_Checker
{
    public partial class MernisChecker_Sorgula : UserControl
    {
        public MernisChecker_Sorgula()
        {
            InitializeComponent();
        }

        private async void dogrulaButton_Click(object sender, EventArgs e)
        {
            // TextBox'lardan TC Kimlik Numarası, isim, soyisim ve doğum yılı bilgilerini al
            string kimlikNoText = kimlikNoTextBox.Text.Trim();
            string ad = adTextBox.Text.Trim();
            string soyad = soyadTextBox.Text.Trim();
            string dogumYiliText = dogumYiliTextBox.Text.Trim();

            // Girişlerin boş olup olmadığını kontrol et
            if (string.IsNullOrEmpty(kimlikNoText) || string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || string.IsNullOrEmpty(dogumYiliText))
            {
                MessageBox.Show("Lütfen tüm bilgileri eksiksiz giriniz.");
                return;
            }

            // Doğru formatta girilmiş olup olmadığını kontrol et
            long kimlikNo;
            int dogumYili;
            if (!long.TryParse(kimlikNoText, out kimlikNo) || !int.TryParse(dogumYiliText, out dogumYili))
            {
                MessageBox.Show("TC Kimlik Numarası ve doğum yılı yalnızca rakamlardan oluşmalıdır.");
                return;
            }

            // TCKimlikNo sınıfını kullanarak TC Kimlik doğrulaması yap
            TCKimlikNo tcKimlik = new TCKimlikNo(kimlikNo);

            // NVI doğrulaması yap
            bool dogrulamaSonucu = await tcKimlik.NVIKontrolAsync(ad, soyad, dogumYili);

            // Doğrulama sonucunu kontrol et
            if (dogrulamaSonucu)
            {
                // Doğrulama başarılı ise kişi bilgilerini göster
                MessageBox.Show("Bu kişi Türkiye Cumhuriyeti Vatandaşlığına Sahip");
                bilgiLabel.Text = $"Ad: {ad}\nSoyad: {soyad}\nDoğum Yılı: {dogumYili}\nTC Kimlik No: {kimlikNo}";
            }
            else
            {
                // Doğrulama başarısız ise mesaj göster
                bilgiLabel.Text = "TC Kimlik doğrulama başarısız.";
            }
        }
    }
}
