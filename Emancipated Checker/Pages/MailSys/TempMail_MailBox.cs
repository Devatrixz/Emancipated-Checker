using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Emancipated_Checker.Pages.MailSys
{
    public partial class TempMail_MailBox : UserControl
    {
        private static readonly HttpClient client = new HttpClient();
        private string tempEmailAddress;

        public TempMail_MailBox()
        {
            InitializeComponent();
        }

        private async void btnGenerateEmail_Click(object sender, EventArgs e)
        {
            await GenerateEmail();
            if (!timerCheckEmails.Enabled)
            {
                timerCheckEmails.Start();
            }
        }

        private async Task GenerateEmail()
        {
            string apiUrl = "https://www.1secmail.com/api/v1/?action=genRandomMailbox&count=1";
            try
            {
                var response = await client.GetStringAsync(apiUrl);
                var emailArray = JsonConvert.DeserializeObject<string[]>(response);
                tempEmailAddress = emailArray[0];
                txtEmail.Text = tempEmailAddress;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void timerCheckEmails_Tick(object sender, EventArgs e)
        {
            await CheckEmails();
        }

        private async Task CheckEmails()
        {
            try
            {
                if (string.IsNullOrEmpty(tempEmailAddress))
                {
                    MessageBox.Show("Temp email address is empty.");
                    return;
                }

                // Updated API URL for testing purposes
                string apiUrl = $"https://www.1secmail.com/api/v1/?action=getMessages&login={tempEmailAddress.Split('@')[0]}&domain={tempEmailAddress.Split('@')[1]}";
                var response = await client.GetStringAsync(apiUrl);

                // Show the raw response for debugging
                MessageBox.Show(response, "API Response");

                var messages = JsonConvert.DeserializeObject<EmailMessage[]>(response);

                if (messages == null || messages.Length == 0)
                {
                    MessageBox.Show("No new emails found.");
                    return;
                }

                foreach (var message in messages)
                {
                    MessageBox.Show($"ID: {message.id}\nFrom: {message.from}\nSubject: {message.subject}\nDate: {message.date}", "New Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class EmailMessage
        {
            public int id { get; set; }
            public string from { get; set; }
            public string subject { get; set; }
            public string date { get; set; }
        }
    }
}
