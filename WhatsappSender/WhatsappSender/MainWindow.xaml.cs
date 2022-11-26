using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WhatsappSender
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
                client.BaseAddress = new Uri("RemovedForSafety");
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("/api/WhatsAppSender/SendTemplateWithParameters", content);
                string resultContent = await result.Content.ReadAsStringAsync();
                MessageBox.Show(resultContent);
            }
        }
    }
}
