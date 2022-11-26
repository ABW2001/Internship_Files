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
using EInvoiceClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
builder.Services.Configure<ServiceParameters>(builder.Configuration.GetSection("ServiceParameters"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
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

        private readonly ServiceParameters ServiceParameter;   

        private async void btnPost_Click(object sender, RoutedEventArgs e)
        {
            var bodyObject = new
            {
                csr = ServiceParameter.Csr,
            };
            HttpClient _client = new();
            _client.BaseAddress = new Uri(ServiceParameter.BaseURL);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("Accept-Version", "V2");
            _client.DefaultRequestHeaders.Add("accept-language", "en");
            _client.DefaultRequestHeaders.Add("OTP", ServiceParameter.Otp);
            HttpResponseMessage response = new();

            response = _client.PostAsJsonAsync(ServiceParameter.ComplianceCsidEndpoint, bodyObject).Result;
            response.EnsureSuccessStatusCode();
            //ComplianceCsrResponse result = response.Content.ReadFromJsonAsync<ComplianceCsrResponse>().Result;
            MessageBox.Show(response.ToString());
        }
    }
}
