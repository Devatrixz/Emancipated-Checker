using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using System.Diagnostics;
using Microsoft.Win32;

namespace Emancipated_Checker
{
    public partial class requirementsscan : Form
    {
        public requirementsscan()
        {
            InitializeComponent();
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;

            if (i == 100) 
            {
                string pythonSurumKomutu = "python --version";

                try
                {
                    // Python sürümünü kontrol eden işlem
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = $"/c {pythonSurumKomutu}";
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();
                    string cikti = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    if (cikti.Contains("Python 3.10.9"))
                    {
                        listBox1.Items.Add("Python 3.10 yüklü.");
                    }
                    else
                    {
                        listBox1.Items.Add("Python 3.10 yüklü değil. Emancpated Checker'ın kusursuz çalışması için yüklemeniz gerekir.");
                        DialogResult quest;
                        quest = MessageBox.Show("Python 3.10 yüklü değil. Yüklemek ister misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (quest == DialogResult.Yes) 
                        {
                            DosyaAc();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            }

            if (i == 150) 
            {
                // WebView2 çalışma zamanı yüklü mü kontrol etmek için kayıt defteri kontrolü
                if (IsWebView2RuntimeInstalled())
                {
                    listBox1.Items.Add("WebView2 Yüklü");
                }
                else
                {
                    listBox1.Items.Add("WebView2 yüklü değil. Emancpated Checker'ın kusursuz çalışması için yüklemeniz gerekir.");
                    DialogResult quest;
                    quest = MessageBox.Show("WebView2 yüklü değil. Yüklemek ister misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (quest == DialogResult.Yes)
                    {
                        Process.Start("https://developer.microsoft.com/en-us/microsoft-edge/webview2/#download-section");
                    }
                }

                timer1.Stop();
                this.Close();
            }
        }

        private bool IsWebView2RuntimeInstalled()
        {
            try
            {
                // WebView2 çalışma zamanı için ilgili kayıt defteri anahtarını kontrol et
                string registryKeyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\EdgeWebView\2";
                // 64-bit sistemlerde de kontrol etmek için
                if (Environment.Is64BitOperatingSystem)
                {
                    registryKeyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\EdgeWebView\2";
                }

                // Kayıt defteri anahtarını kontrol et
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKeyPath))
                {
                    return key != null;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        private void DosyaAc()
        {
            string downloadrequirements = Application.StartupPath + @"\resources/tools/matrix-main/install_python.bat";
            System.Diagnostics.Process.Start(downloadrequirements);
        }
    }
}
