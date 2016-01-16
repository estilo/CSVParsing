using System.Collections.Generic;

namespace ParserNVerify.Models
{
    public class ProductInfo
    {
        public string OurBarcode { get; set; }
        public string SKU { get; set; }
        public string Location { get; set; }
        public List<string> Barcodes { get; set; }
        public string Unknown { get; set; }
        public string Remarks { get; set; }
    }
}