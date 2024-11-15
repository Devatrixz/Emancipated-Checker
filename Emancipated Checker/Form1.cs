using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Media;
using Markdig;

namespace Emancipated_Checker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ApplyTheme();
        }

        public string rootDirectory = @"C:\";
        public string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        string avatarpath = Application.StartupPath + @"\resources/emancipatedsystem/avatar/profile-picture/avatar.png";

        private void ApplyTheme()
        {
            if (Properties.Settings.Default.theme == "black")
            {
                SetControlStyle(this); // Başlangıç formu için
                foreach (Form form in Application.OpenForms)
                {
                    SetControlStyle(form); // Açık olan tüm formlar için
                }
            }
        }

        private void SetControlStyle(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                // Butonlar için stil uygulama
                if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Popup;
                    button.BackColor = Color.Black;
                    button.ForeColor = Color.White;
                }
                // GroupBox için stil uygulama
                else if (control is GroupBox groupBox)
                {
                    groupBox.BackColor = Color.Black;
                    groupBox.ForeColor = Color.White;
                }
                // Menü şeritleri için stil uygulama
                else if (control is MenuStrip menuStrip)
                {
                    menuStrip.BackColor = Color.Black;
                    menuStrip.ForeColor = Color.White;
                }
                // TextBox için stil uygulama
                else if (control is TextBox textBox)
                {
                    textBox.BackColor = Color.Black;
                    textBox.ForeColor = Color.White;
                }
                // Label için stil uygulama
                else if (control is Label label)
                {
                    label.ForeColor = Color.White;
                }
                // ComboBox için stil uygulama
                else if (control is ComboBox comboBox)
                {
                    comboBox.BackColor = Color.Black;
                    comboBox.ForeColor = Color.White;
                }
                // ListBox için stil uygulama
                else if (control is ListBox listBox)
                {
                    listBox.BackColor = Color.Black;
                    listBox.ForeColor = Color.White;
                }
                // TabControl ve TabPage için stil uygulama
                else if (control is TabControl tabControl)
                {
                    tabControl.BackColor = Color.Black;
                    tabControl.ForeColor = Color.White;
                    foreach (TabPage tabPage in tabControl.TabPages)
                    {
                        tabPage.BackColor = Color.Black;
                        tabPage.ForeColor = Color.White;
                        SetControlStyle(tabPage); // TabPage içindeki kontrolleri de ayarla
                    }
                }
                // Diğer tüm kontroller için rekürsif olarak alt kontrolleri kontrol et
                else if (control.HasChildren)
                {
                    SetControlStyle(control); // Alt kontrolleri de kontrol et
                }
            }
        }
        private void tokenAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels++.ToString();
            //Properties.Settings.Default.Save();
            //yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels.ToString();
            //GetToken gettokeninf = new GetToken();
            //gettokeninf.ShowDialog();

            MessageBox.Show("Token al aracı maalesef şu anda kullanılamamaktadır. Sebep: Nextcord is not avaible now. Check important info","Tool Başlatılamıyor",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            string changelogLocation = Application.StartupPath + @"\resources/emancipatedsystem/changelog/changelog.html";
            webBrowserMarkdown.Source = new Uri(changelogLocation);

            if (!string.IsNullOrEmpty(Properties.Settings.Default.thememusic))
            {
                temaMüziğiSesiToolStripMenuItem.Checked = true;
            }
            else
            {
                temaMüziğiSesiToolStripMenuItem.Checked = false;
                temaMüziğiSesiToolStripMenuItem.Enabled = false;
            }

            if (Properties.Settings.Default.thememusic == "emancipated") 
            {
                SoundPlayer sp = new SoundPlayer();
                string music = Application.StartupPath + @"\resources/emancipatedsystem/themesound/emancipated/main/emancipated_theme.wav";
                sp.SoundLocation = music;
                sp.PlayLooping();
            }

            if (Properties.Settings.Default.thememusic == "sensible")
            {
                SoundPlayer sp = new SoundPlayer();
                string music = Application.StartupPath + @"\resources/emancipatedsystem/themesound/emancipated/main/something_sensible.wav";
                sp.SoundLocation = music;
                sp.PlayLooping();
            }

            if (Properties.Settings.Default.thememusic == "hank-wants")
            {
                SoundPlayer sp = new SoundPlayer();
                string music = Application.StartupPath + @"\resources/emancipatedsystem/themesound/emancipated/main/Hank_Wants_Peace.wav";
                sp.SoundLocation = music;
                sp.PlayLooping();
            }

            if (Properties.Settings.Default.thememusic == "yourmusic")
            {

                if (System.IO.File.Exists(Properties.Settings.Default.yourmusicpath))
                {
                    SoundPlayer sp = new SoundPlayer();
                    string music = Properties.Settings.Default.yourmusicpath;
                    sp.SoundLocation = music;
                    sp.PlayLooping();
                }

                else 
                {
                    MessageBox.Show("Lütfen belirtilen konumda ses dosyasının bulunduğunu doğrulayın.", "Dosya Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    temaMüziğiSesiToolStripMenuItem.Checked = false;
                    temaMüziğiSesiToolStripMenuItem.Enabled = false;
                }
                
            }

            if (Properties.Settings.Default.promotion == "matrixteam") 
            {
                pictureBox1.Image = Properties.Resources._290;
                groupBox1.Visible = true;
                promotiontypeLabel.Text = "Promosyon Tipi: MatrixTeam";
                Properties.Settings.Default.promotioncount--;
                Properties.Settings.Default.Save();
                promotionCountLabel.Text = "Kalan Kullanım: " + Properties.Settings.Default.promotioncount.ToString();
                promotionspecialLabel.Text = "Bu promosyon kodu, kullanıcının daha öncelikli bir konuma gelmesini sağlar.";
            }

            if (Properties.Settings.Default.promotioncount == 0) 
            {
                groupBox1.Visible = false;
                Properties.Settings.Default.promotion = "";
                Properties.Settings.Default.promotioncount = 30;
                Properties.Settings.Default.Save();
                MessageBox.Show("Promosyon Kodunuz geçerliliğini yitirdi. Lütfen Emancipated Checker'ı yeniden başlatın.","Kullanım Sonu",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Application.Restart();
            }

            if (Properties.Settings.Default.hackLevels >= 9999) 
            {
                MessageBox.Show("Hata");
                m4NCIPLTDToolStripMenuItem.Visible = true;
            }

            if (Properties.Settings.Default.loginLevel == 100) 
            {
                SoundPlayer sp = new SoundPlayer();
                string music = Application.StartupPath + @"\resources/emancipatedsystem/sound/main2.wav";
                sp.SoundLocation = music;
                sp.Play();
                MessageBox.Show(@"
Değerli Kullanıcımız,

Emancipated Checker'a 100. kez giriş yaptığınızı büyük bir memnuniyetle görmekteyiz! Bu önemli kilometre taşına ulaştığınız için size içten teşekkürlerimizi sunarız.

Sizlerin desteği ve güveni, bizim için son derece kıymetli. Her gün uygulamamızı tercih ettiğiniz için minnettarız ve bu yolculuğunuzda size en iyi deneyimi sunmaya devam etmek için çalışıyoruz.

Sizlerle birlikte daha nice başarılara imza atmayı dört gözle bekliyoruz. 100. girişiniz kutlu olsun!

Saygılarımızla,

Emancipated Team");
                label1.Text = "Değerli Kullanıcı (100. Giriş)";
                this.Text = "Emancipated Checker Version 1.39 (100. Giriş)";

            }

            if (Properties.Settings.Default.Acc_LoginLevel == "Yes")
            {
                label1.Text = "Emancipated Kullanıcısı";
            }

            else
            {
                label1.Text = "Kayıtsız Kullanıcı";
            }

            webBrowser1.Source = new Uri("http://emancipatedglobal.wuaze.com/store.html");
            Properties.Settings.Default.loginLevel++;
            loginLabel.Text = "Kaç kere giriş yaptı: " + Properties.Settings.Default.loginLevel.ToString();
            basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks.ToString();
            yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels.ToString();
            paniclabel.Text = "Panic Seviyesi: " + Properties.Settings.Default.panicLevel.ToString();
            Properties.Settings.Default.userCount--;
            Properties.Settings.Default.supportCooldown--;
            Properties.Settings.Default.Save();
            label3.Text = "Kalan giriş hakkınız: " + Properties.Settings.Default.userCount;

            if (Properties.Settings.Default.userCount < 1) 
            {
                MessageBox.Show("Giriş hakkınız sona erdi ve tüm araçlar kilitlendi. Lütfen şimdi satın alın.", "Giriş hakkınız bitmiştir");
                string targetFolder = Application.StartupPath + @"\resources";
                LockFolder(targetFolder);
                Buy buy = new Buy();
                buy.ShowDialog();
                Application.Exit();
            }

            if (Properties.Settings.Default.purchased == "Yes")
            {
                label3.Text = "Bu ürün satın alındı.";
                label2.Text = "H4CK€R Version Kullanmaktasınız.";
                kayitlabel.Text = "Abonelik: Abonelik Mevcut";
                birAbonelikSatınAlToolStripMenuItem.Visible = false;
                abonelikİptalToolStripMenuItem.Visible = true;
                string targetFolder = Application.StartupPath + @"\resources";
                UnlockFolder(targetFolder);
            }

            else 
            {
                birAbonelikSatınAlToolStripMenuItem.Visible = true;
                abonelikİptalToolStripMenuItem.Visible = false;
            }

            if (Properties.Settings.Default.developerpermission == "Yes")
            {
                panel1.Visible = true;
                groupBox4.Visible = false;
            }
            else 
            {
                panel1.Visible = false;
                groupBox4.Visible = true;
            }

            if (Properties.Settings.Default.Locked == "Yes_HackReason") 
            {
                MessageBox.Show("Sen geliştirici izinleri hacklemeye çalıştın. Bu izinler normal bir kullanıcı çok tehlikeli. Ve sen aptal gibi devam ettin. İnşallah internet servis sağlayıcın mesaide değildir. Yoksa sen bittin.", "Game over... H4CKER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Çok fazla yanlış kod girdiğinden ötürü veya kaba kuvvet saldırısı (BruteForce) kullandığından ötürü panel kilitlendi. Açmak için paneli sil ve birdaha yükleme.", "Paneli sil ve sakın yükleme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (Properties.Settings.Default.Locked == "Yes_DevReason") 
            {
                DialogResult lockdisable;
                lockdisable = MessageBox.Show("Emancipated Checker geliştirici denemesi için kilitlendi. Kilidi açmak için Tamam butonuna tıkla.", "Kilitlendi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (lockdisable == DialogResult.OK)
                {
                    Properties.Settings.Default.Locked = "No";
                    Properties.Settings.Default.Save();
                    Application.Restart();
                }
                else 
                {
                    Application.Exit();
                }
            }

            if (Properties.Settings.Default.Acc_LoginLevel == "Yes") 
            {
                groupBox6.Show();
                label10.Text = Properties.Settings.Default.Acc_Username;
                label6.Text = Properties.Settings.Default.Acc_Mail;

                if (System.IO.File.Exists(avatarpath))
                {
                    pictureBox8.Image = Image.FromFile(avatarpath);
                }
                else
                {
                    MessageBox.Show("Avatar resmi bulunamadı.");
                }
            }

            if (Properties.Settings.Default.Locked == "Yes") 
            {
                MessageBox.Show("Emancipated Checker bilinmeyen bir nedenden dolayı kilitlendi. Lütfen teknik destek ile iletişime geçin. Kod: 00xc6ha", "Emancipated Checker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            #region İnternet Kontrol
            InternetKontrol();
            #endregion
        }

        private void birAbonelikSatınAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Buy buy = new Buy();
            buy.ShowDialog();
        }

        private void resetForDevelopersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.userCount = 30;
            Properties.Settings.Default.purchased = "No";
            Properties.Settings.Default.loginLevel = 0;
            Properties.Settings.Default.sucsessHacks = 0;
            Properties.Settings.Default.hackLevels = 0;
            Properties.Settings.Default.panicLevel++;
            Properties.Settings.Default.Save();
            Application.Restart();
        }

        private void ıPSorguToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels++.ToString();
            //Properties.Settings.Default.Save();
            //yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels.ToString();
            //IP_Check ip = new IP_Check();
            //ip.ShowDialog();

            MessageBox.Show("IP Check aracı maalesef şu anda kullanılamamaktadır. Sebep: Nextcord is not avaible now. Check important info", "Tool Başlatılamıyor", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void webhooklarıYönetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //WebHook_Manager webHook = new WebHook_Manager();
            //webHook.Show();

            MessageBox.Show("Webhook Manager aracı maalesef şu anda kullanılamamaktadır. Sebep: Nextcord is not avaible now. Check important info", "Tool Başlatılamıyor", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void noUserCountForDevelopersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.userCount = 0;
            Properties.Settings.Default.purchased = "No";
            Properties.Settings.Default.Save();
            Application.Restart();
        }

        public bool InternetKontrol()
        {
            try
            {
                System.Net.Sockets.TcpClient kontrol_client = new System.Net.Sockets.TcpClient("www.google.com.tr", 80);
                kontrol_client.Close();
                return true;
            }
            catch (Exception e)
            {
                NoInternet no = new NoInternet();
                no.ShowDialog();
                this.Hide();
                return false;
            }
        }

        private void dDOSAtackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels++.ToString();
            Properties.Settings.Default.Save();
            yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels.ToString();
            DDOS_Attack attack = new DDOS_Attack();
            attack.Show();
        }

        private void store1_MouseEnter(object sender, EventArgs e)
        {
            this.MaximizeBox = true;
        }

        private void store1_MouseLeave(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void tabPage3_MouseEnter(object sender, EventArgs e)
        {
            this.MaximizeBox = true;
        }

        private void tabPage3_MouseLeave(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void paniclabel_Click(object sender, EventArgs e)
        {

        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void genelYardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.emancipatedglobal.wuaze.com");
        }

        private void keygenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels++.ToString();
            Properties.Settings.Default.Save();
            yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels.ToString();
            Keygen_API keygen = new Keygen_API();
            keygen.ShowDialog();
        }

        private void zorVeKarmaşıkHesapÜreticiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Açılan konsolun dosyaları Emancipated Checkerın kurulu olduğu dizinden şu yolda bulunur: resources/tools/");
            string openbuilder = Application.StartupPath + @"\resources/tools/accountConsole.exe";
            System.Diagnostics.Process.Start(openbuilder);
            yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels++.ToString();
            Properties.Settings.Default.Save();
            yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels.ToString();

        }

        private void toolsKlasörünüAçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tools = Application.StartupPath + @"\resources/tools";
            System.Diagnostics.Process.Start(tools);
        }

        private void rastgeleCVÜreticiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.purchased == "Yes")
            {
                yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels++.ToString();
                Properties.Settings.Default.Save();
                yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels.ToString();
                MessageBox.Show("Bu alanda üretilen bilgilerin hiçbir şekilde geçerliliği yoktur. Eğer geçerliliği varsa bunlar tamamen tesadüften ibarettir. Yük sizin omuzunuza!", "Yasal uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                string openbuilder = Application.StartupPath + @"\resources/tools/generateCV.exe";
                System.Diagnostics.Process.Start(openbuilder);
                basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks++.ToString();
                Properties.Settings.Default.Save();
                basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks.ToString();
            }
            else 
            {
                MessageBox.Show("Maalesef Emancipated Checker'a sınırlamalar getirdik. Bunca zaman ücretsiz olan CV üretici artık sadece lisanslı olanlar kullanabilir. Bir açığını bulup kullanmaya kalkma... Çünkü seni izlemekteyiz.", "Panel etkinleştirilmemiş!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void kurulumDizininiAçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string installedDirectory = Application.StartupPath;
            System.Diagnostics.Process.Start(installedDirectory);
        }

        private void dllInjectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels++.ToString();
            Properties.Settings.Default.Save();
            yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels.ToString();
            string openbuilder = Application.StartupPath + @"\resources/tools/DLLInjectSystem.exe";
            System.Diagnostics.Process.Start(openbuilder);
            basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks++.ToString();
            Properties.Settings.Default.Save();
            basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks.ToString();
        }

        private void emancipatedConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.purchased == "Yes")
            {
                yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels++.ToString();
                Properties.Settings.Default.Save();
                yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels.ToString();
                MessageBox.Show("Bu alanda tipik bir komut satırı saldırısı yapabilirsiniz. Bu konsol linux ve parrot dağıtımlarının veritabanını kullanır ve bunları kullanmayı bilen bir kişi çok kolay hack saldırıları düzenleyebilir. Arkanı kolla dostum...", "Yasal uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                string openbuilder = Application.StartupPath + @"\resources/tools/Emancipated_Console.exe";
                System.Diagnostics.Process.Start(openbuilder);
                basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks++.ToString();
                Properties.Settings.Default.Save();
                basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks.ToString();
            }
            else 
            {
                MessageBox.Show("Maalesef Emancipated Checker'a sınırlamalar getirdik. Bunca zaman ücretsiz olan Emancipated Enviroment artık sadece lisanslı olanlar kullanabilir. Bir açığını bulup kullanmaya kalkma... Çünkü seni izlemekteyiz.", "Panel etkinleştirilmemiş!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void abonelikİptalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelPurchase cancel = new CancelPurchase();
            cancel.ShowDialog();
        }

        private void nitroGenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels++.ToString();
            Properties.Settings.Default.Save();
            yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels.ToString();
            string openbuilder = Application.StartupPath + @"\resources/DiscordExperiments/NitroGen/DiscordExperiments.exe";
            System.Diagnostics.Process.Start(openbuilder);
            basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks++.ToString();
            Properties.Settings.Default.Save();
            basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void AnaDiziniGoster()
        {
            treeView1.Nodes.Clear(); // Varolan düğümleri temizle

            string anaDizin = Path.GetPathRoot(documentsPath); // Bilgisayarınızdaki ana dizin (genellikle C:\) alınır

            TreeNode rootNode = new TreeNode(anaDizin); // Kök düğümü oluştur
            treeView1.Nodes.Add(rootNode);

            DiziniDoldur(anaDizin, rootNode); // Ana dizinin alt dizinlerini doldurmak için metodu çağır

            // İlk düğümü genişlet
            rootNode.Expand();
        }

        private void DiziniDoldur(string dizinYolu, TreeNode parentNode)
        {
            try
            {
                string[] altDizinler = Directory.GetDirectories(dizinYolu); // Dizindeki alt dizinlerin listesi alınır

                // Her bir alt dizin için bir TreeNode oluşturulur ve parentNode'ya eklenir
                foreach (string altDizin in altDizinler)
                {
                    TreeNode node = new TreeNode(Path.GetFileName(altDizin));
                    parentNode.Nodes.Add(node);
                    DiziniDoldur(altDizin, node); // Alt dizinin alt dizinlerini doldurmak için metodu tekrar çağır
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme Hatası. Tekrar deneyin veya destek ile iletişime geçin");
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node; // Seçilen düğümü al

            if (selectedNode != null)
            {
                string selectedFolderPath = selectedNode.FullPath; // Seçilen düğümün tam yolu alınır

                try
                {
                    // Seçilen dizinin içeriğini göstermek için bir Explorer penceresi aç
                    System.Diagnostics.Process.Start(selectedFolderPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dizin açılırken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void diziniYükleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult quest1;
            quest1 = MessageBox.Show(directoryQuestText, "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            if (quest1 == DialogResult.Yes) 
            {
                AnaDiziniGoster();
            }
        }

        string directoryQuestText = @"Dizini yükleme işlemi genellikle çok uzun sürer veya checker kesme moduna girebilir.

Bu durumda Emancipated Checker'ı kullanamazsınız.

Devam etmek istiyor musunuz?";

        private void button1_Click_1(object sender, EventArgs e)
        {
            SupportTicketForm sp = new SupportTicketForm();
            sp.ShowDialog();
        }

        private void destekTalebiOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.supportCooldown < 1)
            {
                SupportTicketForm sp = new SupportTicketForm();
                sp.ShowDialog();
            }
            else 
            {
                MessageBox.Show("Önceden zaten destek talebi oluşturdunuz. Lütfen birkaç gün bekleyin.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void LockFolder(string folderPath)
        {
            // Klasörün erişim izinlerini değiştir
            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
            directoryInfo.Attributes |= FileAttributes.ReadOnly;

            // Klasördeki dosyaları al
            FileInfo[] files = directoryInfo.GetFiles();

            // Her dosya için işlem yap
            foreach (var file in files)
            {
                // Dosyanın erişim izinlerini değiştir
                file.Attributes |= FileAttributes.ReadOnly;
            }

            // Klasördeki alt klasörleri al
            DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();

            // Her alt klasör için işlem yap
            foreach (var subDirectory in subDirectories)
            {
                // Alt klasörleri de kilitler
                LockFolder(subDirectory.FullName);
            }
        }

        // Klasörü ve içindeki dosyaların kilidini kaldırır
        private void UnlockFolder(string folderPath)
        {
            // Klasörün erişim izinlerini geri al
            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
            directoryInfo.Attributes &= ~FileAttributes.ReadOnly;

            // Klasördeki dosyaları al
            FileInfo[] files = directoryInfo.GetFiles();

            // Her dosya için işlem yap
            foreach (var file in files)
            {
                // Dosyanın erişim izinlerini geri al
                file.Attributes &= ~FileAttributes.ReadOnly;
            }

            // Klasördeki alt klasörleri al
            DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();

            // Her alt klasör için işlem yap
            foreach (var subDirectory in subDirectories)
            {
                // Alt klasörlerin kilidini kaldır
                UnlockFolder(subDirectory.FullName);
            }
        }

        private void resetSupportCooldownForDevelopersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.supportCooldown = 0;
            Properties.Settings.Default.Save();
            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.userCount = 0;
            Properties.Settings.Default.purchased = "No";
            Properties.Settings.Default.Save();
            Application.Restart();
        }

        private void ResetCooldownButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.supportCooldown = 0;
            Properties.Settings.Default.Save();
            Application.Restart();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
            Application.Restart();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            GetDeveloperPermission get = new GetDeveloperPermission();
            get.ShowDialog();
        }

        private void modemWatcherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.purchased == "Yes")
            {
                yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels++.ToString();
                Properties.Settings.Default.Save();
                yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels.ToString();
                MessageBox.Show("Bu alanda tipik bir komut satırı saldırısı yapabilirsiniz. Bu konsol linux ve parrot dağıtımlarının veritabanını kullanır ve bunları kullanmayı bilen bir kişi çok kolay hack saldırıları düzenleyebilir. Arkanı kolla dostum...", "Yasal uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // string openbuilder = Application.StartupPath + @"\resources/tools/Emancipated_Console.exe";
                // System.Diagnostics.Process.Start(openbuilder);
                basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks++.ToString();
                Properties.Settings.Default.Save();
                basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks.ToString();
            }
            else
            {
                MessageBox.Show("Maalesef Emancipated Checker'a sınırlamalar getirdik. Hiçbir yerde bulamayacağın toollara erişmek kolay değil. Bir açığını bulup kullanmaya kalkma... Çünkü seni izlemekteyiz.", "Panel etkinleştirilmemiş!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ıSSİzleyiciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.purchased == "Yes")
            {
                yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels++.ToString();
                Properties.Settings.Default.Save();
                yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels.ToString();
                MessageBox.Show("Bu alanda tipik bir komut satırı saldırısı yapabilirsiniz. Bu konsol linux ve parrot dağıtımlarının veritabanını kullanır ve bunları kullanmayı bilen bir kişi çok kolay hack saldırıları düzenleyebilir. Arkanı kolla dostum...", "Yasal uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // string openbuilder = Application.StartupPath + @"\resources/tools/Emancipated_Console.exe";
                // System.Diagnostics.Process.Start(openbuilder);
                basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks++.ToString();
                Properties.Settings.Default.Save();
                basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks.ToString();
            }
            else
            {
                MessageBox.Show("Maalesef Emancipated Checker'a sınırlamalar getirdik. Hiçbir yerde bulamayacağın toollara erişmek kolay değil. Bir açığını bulup kullanmaya kalkma... Çünkü seni izlemekteyiz.", "Panel etkinleştirilmemiş!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void remoteAdministraionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.purchased == "Yes")
            {
                yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels++.ToString();
                Properties.Settings.Default.Save();
                yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels.ToString();
                MessageBox.Show("Bu alanda tipik bir komut satırı saldırısı yapabilirsiniz. Bu konsol linux ve parrot dağıtımlarının veritabanını kullanır ve bunları kullanmayı bilen bir kişi çok kolay hack saldırıları düzenleyebilir. Arkanı kolla dostum...", "Yasal uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // string openbuilder = Application.StartupPath + @"\resources/tools/Emancipated_Console.exe";
                // System.Diagnostics.Process.Start(openbuilder);
                basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks++.ToString();
                Properties.Settings.Default.Save();
                basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks.ToString();
            }
            else
            {
                MessageBox.Show("Maalesef Emancipated Checker'a sınırlamalar getirdik. Hiçbir yerde bulamayacağın toollara erişmek kolay değil. Bir açığını bulup kullanmaya kalkma... Çünkü seni izlemekteyiz.", "Panel etkinleştirilmemiş!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Locked = "Yes_DevReason";
            Properties.Settings.Default.Save();
            Application.Restart();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.loginLevel = 9999;
            Properties.Settings.Default.hackLevels = 9999;
            Properties.Settings.Default.panicLevel = 9999;
            Properties.Settings.Default.sucsessHacks = 9999;
            Properties.Settings.Default.Save();
            Application.Restart();
        }

        private void sMSBomberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.purchased == "Yes")
            {
                MessageBox.Show("Bu aracı kullanmak için Python indirdiğinden emin ol!", "Python Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels++.ToString();
                Properties.Settings.Default.Save();
                yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels.ToString();
                MessageBox.Show("Bu alana dikkat edin. SMS Bomb yaptığınız telefon numarasının sahibi, sizden şüphelenebilir. Ayrıca eğer Emniyete başvurulursa sms sağlayıcılarından IP alınır ve konumunuzu bulurlar. Gerçi bunlarla uğraşırlarmı pek sanmam. Ayrıca VPN kullanman da çözüm sağlamaz çünkü VPN sağlayıcından bilgiler istenir ve aynı methodla IP bulunur.", "Yasal uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                string openbuilder = Application.StartupPath + @"\resources/smssystem/EmancipatedSMS/clinet.py";
                System.Diagnostics.Process.Start(openbuilder);
                basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks++.ToString();
                Properties.Settings.Default.Save();
                basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks.ToString();
            }
            else
            {
                MessageBox.Show("Maalesef Emancipated Checker'a sınırlamalar getirdik. Hiçbir yerde bulamayacağın toollara erişmek kolay değil. Bir açığını bulup kullanmaya kalkma... Çünkü seni izlemekteyiz.", "Panel etkinleştirilmemiş!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mernisSorguSistemiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MernisChecker checker = new MernisChecker();
            checker.Show();
        }

        private void vIPSorgularToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mernisSorguSistemiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.purchased == "Yes")
            {
                MernisChecker checker = new MernisChecker();
                checker.Show(); Properties.Settings.Default.sucsessHacks.ToString();
            }
            else
            {
                MessageBox.Show("Maalesef Emancipated Checker'a sınırlamalar getirdik. Hiçbir yerde bulamayacağın toollara erişmek kolay değil. Bir açığını bulup kullanmaya kalkma... Çünkü seni izlemekteyiz.", "Panel etkinleştirilmemiş!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sMSBomberToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.purchased == "Yes")
            {
                MessageBox.Show("Bu aracı kullanmak için Python indirdiğinden emin ol!", "Python Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels++.ToString();
                Properties.Settings.Default.Save();
                yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels.ToString();
                MessageBox.Show("Bu alana dikkat edin. SMS Bomb yaptığınız telefon numarasının sahibi, sizden şüphelenebilir. Ayrıca eğer Emniyete başvurulursa sms sağlayıcılarından IP alınır ve konumunuzu bulurlar. Gerçi bunlarla uğraşırlarmı pek sanmam. Ayrıca VPN kullanman da çözüm sağlamaz çünkü VPN sağlayıcından bilgiler istenir ve aynı methodla IP bulunur.", "Yasal uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                string openbuilder = Application.StartupPath + @"\resources/smssystem/EmancipatedSMS/clinet.py";
                System.Diagnostics.Process.Start(openbuilder);
                basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks++.ToString();
                Properties.Settings.Default.Save();
                basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks.ToString();
            }
            else
            {
                MessageBox.Show("Maalesef Emancipated Checker'a sınırlamalar getirdik. Hiçbir yerde bulamayacağın toollara erişmek kolay değil. Bir açığını bulup kullanmaya kalkma... Çünkü seni izlemekteyiz.", "Panel etkinleştirilmemiş!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void emancipatedEnviromentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void dllInjectionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.purchased == "Yes")
            {
                yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels++.ToString();
                Properties.Settings.Default.Save();
                yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels.ToString();
                string openbuilder = Application.StartupPath + @"\resources/tools/DLLInjectSystem.exe";
                System.Diagnostics.Process.Start(openbuilder);
                basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks++.ToString();
                Properties.Settings.Default.Save();
                basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks.ToString();
            }
            else
            {
                MessageBox.Show("Maalesef Emancipated Checker'a sınırlamalar getirdik. Bunca zaman ücretsiz olan Emancipated Enviroment artık sadece lisanslı olanlar kullanabilir. Bir açığını bulup kullanmaya kalkma... Çünkü seni izlemekteyiz.", "Panel etkinleştirilmemiş!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void geriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack)
            {
                webBrowser1.GoBack();
            }
        }

        private void ileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward)
            {
                webBrowser1.GoForward();
            }
        }

        private void sayfayıYenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void syfaYüklenmesiniDurdurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Source = new Uri("http://emancipatedglobal.wuaze.com/store.html");
        }

        private void hesapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountManager acc = new AccountManager();
            acc.ShowDialog();
        }

        private void mailSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.purchased == "Yes")
            {
                MessageBox.Show("Bu araç, API kısıtlamalarından dolayı düzgün çalışmayabilir. Eğer bu araç düzgün çalışmıyorsa, destek talebi açarak bizimle iletişime geçin.", "Posta uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TempMail tmp = new TempMail();
                tmp.Show();
            }
            else 
            {
                MessageBox.Show("Maalesef Emancipated Checker'a sınırlamalar getirdik. Bunca zaman ücretsiz olan Emancipated Enviroment artık sadece lisanslı olanlar kullanabilir. Bir açığını bulup kullanmaya kalkma... Çünkü seni izlemekteyiz.", "Panel etkinleştirilmemiş!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void enviromentBasicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.purchased == "Yes")
            {
                yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels++.ToString();
                Properties.Settings.Default.Save();
                yapilanhacklabel.Text = "Yapılan Hackler: " + Properties.Settings.Default.hackLevels.ToString();
                MessageBox.Show("Bu alanda tipik bir komut satırı saldırısı yapabilirsiniz. Bu konsol linux ve parrot dağıtımlarının veritabanını kullanır ve bunları kullanmayı bilen bir kişi çok kolay hack saldırıları düzenleyebilir. Arkanı kolla dostum...", "Yasal uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                string openbuilder = Application.StartupPath + @"\resources/tools/Emancipated_Console.exe";
                System.Diagnostics.Process.Start(openbuilder);
                basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks++.ToString();
                Properties.Settings.Default.Save();
                basarilihacklabel.Text = "Başarılı Hackler: " + Properties.Settings.Default.sucsessHacks.ToString();
            }
            else
            {
                MessageBox.Show("Maalesef Emancipated Checker'a sınırlamalar getirdik. Hiçbir yerde bulamayacağın toollara erişmek kolay değil. Bir açığını bulup kullanmaya kalkma... Çünkü seni izlemekteyiz.", "Panel etkinleştirilmemiş!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void enviromentPremiumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.purchased == "Yes") 
            {
                MessageBox.Show("Yakında Emancipated Checker içine entegre edilecektir. Ürünü mağazamızdan satın alanlar için, Emancipated Checker 1.35.2 pre build sürümünü beklemeniz önemle rica olunur.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Maalesef Emancipated Checker'a sınırlamalar getirdik. Hiçbir yerde bulamayacağın toollara erişmek kolay değil. Bir açığını bulup kullanmaya kalkma... Çünkü seni izlemekteyiz.", "Panel etkinleştirilmemiş!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void enviromentProToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.purchased == "Yes")
            {
                MessageBox.Show("Yakında Emancipated Checker içine entegre edilecektir. Ürünü mağazamızdan satın alanlar için, Emancipated Checker 1.35.2 pre build sürümünü beklemeniz önemle rica olunur.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Maalesef Emancipated Checker'a sınırlamalar getirdik. Hiçbir yerde bulamayacağın toollara erişmek kolay değil. Bir açığını bulup kullanmaya kalkma... Çünkü seni izlemekteyiz.", "Panel etkinleştirilmemiş!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void allinoneEnviromentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.purchased == "Yes")
            {
                MessageBox.Show("Yakında Emancipated Checker içine entegre edilecektir. Ürünü mağazamızdan satın alanlar için, Emancipated Checker 1.35.2 pre build buildsürümünü beklemeniz önemle rica olunur.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Maalesef Emancipated Checker'a sınırlamalar getirdik. Hiçbir yerde bulamayacağın toollara erişmek kolay değil. Bir açığını bulup kullanmaya kalkma... Çünkü seni izlemekteyiz.", "Panel etkinleştirilmemiş!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void aIDestekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupportChatAI sp = new SupportChatAI();
            sp.Show();
        }

        private void bunlarınAnlamınıSenÇözToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            string music = Application.StartupPath + @"\resources/emancipatedsystem/sound/main1.wav";
            sp.SoundLocation = music;
            sp.PlayLooping();
            MessageBox.Show("Hpdpflsdwhg vhul idun hwwl. Sdqho wdpdpohq kdfnohqphnwh yh vhq nxsfdqdlulpvgdq elvlvlq. Xqxpqd nl vhqgh elchqvlq. -Pdawul Ohdghu","Matrix Leader mesajı. Sezar şifrelemesi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            Emancipated_Checker.SecretMode.Dduhvlfoln_elu_upuyyuu secret = new SecretMode.Dduhvlfoln_elu_upuyyuu();
            secret.Show();
            this.Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void matrixMalwareBuilderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.purchased == "Yes")
            {
                DialogResult quest1;
                MessageBox.Show("Bu araç, Python Agent oluşturmanı sağlar. Aracın etik olmayan kullanımı ağır sonuçlar doğurabileceği gibi, bildiğin üzere son zamanda olan olaylardan sonra başın eskisinden çok daha ağrıyacak. KİMSEYE GÜVENME", "Yasal uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                quest1 = MessageBox.Show("Bu aracı kullanmak için gereksinimleri karşılaman gerekiyor. Kullanım Kılavuzu size güzel bir rehber olacak. Gösterilmesini istiyor musunuz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (quest1 == DialogResult.Yes)
                {
                    string openinformation = Application.StartupPath + @"\resources/tools/matrix-main/Detaylı ve basit kullanım kılavuzu.txt";
                    System.Diagnostics.Process.Start(openinformation);
                }
                else
                {
                    string openbuilder = Application.StartupPath + @"\resources/tools/matrix-main/build.bat";
                    System.Diagnostics.Process.Start(openbuilder);
                }
            }
            else
            {
                MessageBox.Show("Maalesef Emancipated Checker'a sınırlamalar getirdik. Hiçbir yerde bulamayacağın toollara erişmek kolay değil. Bir açığını bulup kullanmaya kalkma... Çünkü seni izlemekteyiz.", "Panel etkinleştirilmemiş!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tokenAlToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Token al aracı maalesef şu anda kullanılamamaktadır. Sebep: Nextcord is not avaible now. Check important info", "Tool Başlatılamıyor", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ıPSorguToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("IP Sorgulama aracı maalesef şu anda kullanılamamaktadır. Sebep: Nextcord is not avaible now. Check important info", "Tool Başlatılamıyor", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void webhookYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Webhook Manager aracı maalesef şu anda kullanılamamaktadır. Sebep: Nextcord is not avaible now. Check important info", "Tool Başlatılamıyor", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void temaMüziğiSesiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (temaMüziğiSesiToolStripMenuItem.Checked == false)
            {
                if (Properties.Settings.Default.thememusic == "emancipated")
                {
                    SoundPlayer sp = new SoundPlayer();
                    string music = Application.StartupPath + @"\resources/emancipatedsystem/themesound/emancipated/main/emancipated_theme.wav";
                    sp.SoundLocation = music;
                    sp.PlayLooping();
                }

                if (Properties.Settings.Default.thememusic == "solider")
                {
                    SoundPlayer sp = new SoundPlayer();
                    string music = Application.StartupPath + @"\resources/emancipatedsystem/themesound/emancipated/main/solider_theme.wav";
                    sp.SoundLocation = music;
                    sp.PlayLooping();
                }

                if (Properties.Settings.Default.thememusic == "subsolider")
                {
                    SoundPlayer sp = new SoundPlayer();
                    string music = Application.StartupPath + @"\resources/emancipatedsystem/themesound/emancipated/main/subsolider.wav";
                    sp.SoundLocation = music;
                    sp.PlayLooping();
                }

                if (Properties.Settings.Default.thememusic == "yourmusic")
                {
                    SoundPlayer sp = new SoundPlayer();
                    string music = Properties.Settings.Default.yourmusicpath;
                    sp.SoundLocation = music;
                    sp.PlayLooping();
                }
                temaMüziğiSesiToolStripMenuItem.Checked = true;
            }
            else 
            {
                SoundPlayer sp = new SoundPlayer();
                sp.SoundLocation = Properties.Settings.Default.thememusic;
                sp.Stop();
                temaMüziğiSesiToolStripMenuItem.Checked = false;
            }
        }

        //private void emancipatedCheckerD4VELP4RToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //}

    }

}
