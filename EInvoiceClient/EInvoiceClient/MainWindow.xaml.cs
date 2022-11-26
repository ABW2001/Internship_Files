using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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
using Microsoft.VisualBasic;
using Newtonsoft.Json;


namespace EInvoiceClient
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
        private const string baseAddress = "https://gw-apic-gov.gazt.gov.sa/e-invoicing/developer-portal/";
        private const string Csr = "LS0tLS1CRUdJTiBDRVJUSUZJQ0FURSBSRVFVRVNULS0tLS0KTUlJQnl6Q0NBWElDQVFBd1R6RUxNQWtHQTFVRUJoTUNVMEV4RnpBVkJnTlZCQXNNRG1GdGJXRnVJRUp5WVc1agphR05vTVJNd0VRWURWUVFLREFwb1lYbGhJSGxoWnlBek1SSXdFQVlEVlFRRERBa3hNamN1TUM0d0xqRXdWakFRCkJnY3Foa2pPUFFJQkJnVXJnUVFBQ2dOQ0FBVGJpclluL3l2L09zSGhGbE1QdkZjUnhJM250dWsxaXd0aWxOWXUKVjIrOTVrbkRBc2hiNU9Gc0lZQ0hvL2tMMDBLdnhMczQrcytyMWc4dnFVZ3BvazhYb0lIRE1JSEFCZ2txaGtpRwo5dzBCQ1E0eGdiSXdnYTh3SkFZSkt3WUJCQUdDTnhRQ0JCY1RGVlJUVkZwQlZFTkJMVU52WkdVdFUybG5ibWx1Clp6Q0JoZ1lEVlIwUkJIOHdmYVI3TUhreEd6QVpCZ05WQkFRTUVqRXRhR0Y1WVh3eUxUSXpOSHd6TFRNMU5ERWYKTUIwR0NnbVNKb21UOGl4a0FRRU1Eek14TURFM05UTTVOelF3TURBd016RU5NQXNHQTFVRURBd0VNVEV3TURFUQpNQTRHQTFVRUdnd0hXbUYwWTJFZ016RVlNQllHQTFVRUR3d1BSbTl2WkNCQ2RYTnphVzVsYzNNek1Bb0dDQ3FHClNNNDlCQU1DQTBjQU1FUUNJQ3JyTzdtSzZWZTZNTmIrSlNJRkRmK0FGMjhqV2ZJYTNIdzlhWEdVOS9KbkFpQXIKSnBVc0h4Z1RrOGtQZTRQSnNJVGJJYXlTeUh2emZwdHFFTWZEajdQN2F3PT0KLS0tLS1FTkQgQ0VSVElGSUNBVEUgUkVRVUVTVC0tLS0t";
        private const string Otp = "123345";
        private async void btnPost_Click(object sender, RoutedEventArgs e)
        {
            var bodyObject = new
            {
                csr = Csr,
            };
            HttpClient _client = new();
            _client.BaseAddress = new Uri(baseAddress);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("Accept-Version", "V2");
            _client.DefaultRequestHeaders.Add("accept-language", "en");
            _client.DefaultRequestHeaders.Add("OTP", Otp);
            HttpResponseMessage response = new();

            response = _client.PostAsJsonAsync("compliance", bodyObject).Result;
            response.EnsureSuccessStatusCode();
            //ComplianceCsrResponse result = response.Content.ReadFromJsonAsync<ComplianceCsrResponse>().Result;
            MessageBox.Show(response.ToString());
        }
    }
}
