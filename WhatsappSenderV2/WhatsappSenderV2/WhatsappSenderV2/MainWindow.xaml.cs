using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace WhatsappSenderV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnPost_Click(object sender, RoutedEventArgs e)
        {
            var data = new
            {
                Name = txtName.Text,
                RecipientPhoneNumber = txtNumber.Text,
                TemplateName = "productinformation",
                LanguageCode = "ar"
            };
            string json = JsonConvert.SerializeObject(data);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5026");
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("/whatsapp", content);
                string resultContent = await result.Content.ReadAsStringAsync();
                MessageBox.Show(resultContent);
            }
        }

        private async void btnGet_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient()) 
            {
                client.BaseAddress = new Uri("http://localhost:5026");
                var result = await client.GetAsync("/date");
                string resultContent = await result.Content.ReadAsStringAsync();
                MessageBox.Show(resultContent);
            }
        }
    }
}
