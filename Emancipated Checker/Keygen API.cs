using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Emancipated_Checker
{
    public partial class Keygen_API : Form
    {
        private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private readonly Random random = new Random();
        public Keygen_API()
        {
            InitializeComponent();
        }
        private List<string> keyListesi = new List<string>();
        private void button2_Click(object sender, EventArgs e)
        {
            string rastgeleKey = GenerateRandomPrefence();
            textBox1.Text = rastgeleKey;
        }

        private string GenerateRandomPrefence()
        {
            const string karakterler = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] keyArray = new char[10];

            for (int i = 0; i < 10; i++)
            {
                keyArray[i] = karakterler[random.Next(karakterler.Length)];
            }

            return new string(keyArray);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Boş algoritma kabul edilemez!");
            }
            else 
            {
                label2.Text = "Algoritma Referans Key: " + textBox1.Text;
                button1.Enabled = false;
                textBox1.Enabled = false;
                button2.Enabled = false;
                groupBox3.Enabled = true;
                listBoxKeys.Enabled = true;
            }
        }

        private void btnGenerateKeys_Click(object sender, EventArgs e)
        {
            int keyLength = (int)numericUpDownKeyLength.Value;
            int numberOfKeys = (int)numericUpDownNumberOfKeys.Value;

            List<string> generatedKeys = GenerateSerialKeys(keyLength, numberOfKeys);
            DisplayKeysInListBox(generatedKeys);
            SaveKeysToFile(generatedKeys, "keys.txt");

            MessageBox.Show("Keyler keys.txt dosyasına kaydedildi","Sonuç",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private List<string> GenerateSerialKeys(int keyLength, int numberOfKeys)
        {
            List<string> keys = new List<string>();

            for (int i = 0; i < numberOfKeys; i++)
            {
                StringBuilder keyBuilder = new StringBuilder();

                for (int j = 0; j < keyLength; j++)
                {
                    // İlk iki ve son iki grup için ayıracı ekleyelim.
                    if (j == 2 || j == keyLength - 2)
                    {
                        keyBuilder.Append('-');
                    }

                    keyBuilder.Append(GetRandomCharacter());
                }

                keys.Add(keyBuilder.ToString());
            }

            return keys;
        }

        private char GetRandomCharacter()
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return characters[random.Next(characters.Length)];
        }

        private void DisplayKeysInListBox(List<string> keys)
        {
            listBoxKeys.Items.Clear();
            listBoxKeys.Items.AddRange(keys.ToArray());
        }

        private void SaveKeysToFile(List<string> keys, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (string key in keys)
                {
                    sw.WriteLine(key);
                }
            }
        }

        private void rastgeleBirAlgoritmaOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            textBox1.Enabled = true;
            button2.Enabled = true;
            groupBox3.Enabled = false;
            listBoxKeys.Enabled = false;
            label2.Text = "Algoritma Burada Gözükür";
            textBox1.Text = "";
        }
    }
}
