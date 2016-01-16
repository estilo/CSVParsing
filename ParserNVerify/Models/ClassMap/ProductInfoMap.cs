using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration;

namespace ParserNVerify.Models.ClassMap
{
    public class ProductInfoMap : CsvClassMap<ProductInfo>
    {
        public ProductInfoMap()
        {
            Map(m => m.OurBarcode).Name("OUR BARCODE");
            Map(m => m.SKU).Name("SKU");
            Map(m => m.Location).Name("LOCATION");
            Map(m => m.Barcodes).ConvertUsing(row => 
                new List<string>(
                    row.GetField<string>("BARCODE").Split(',').Select(t=> t.Trim()).ToList()
                ));
            Map(m => m.Unknown).Index(4);
            Map(m => m.Remarks).Index(5);
        }
    }
}