using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EInvoiceClient
{
    internal class ServiceParameters
    {
        public string BaseURL { get; set; }
        public string ComplianceCsidEndpoint { get; set; }
        public string Otp { get; set; }
        public string Csr { get; set; }
        public string ProdCsidEndpoint { get; set; }
        public string InvoiceClearanceEndPoint { get; set; }
    }
}
