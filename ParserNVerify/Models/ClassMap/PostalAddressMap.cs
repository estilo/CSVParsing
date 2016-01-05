using CsvHelper.Configuration;

namespace ParserNVerify.Models.ClassMap
{
    public class PostalAddressMap : CsvClassMap<PostalAddress>
    {
        public PostalAddressMap()
        {
            Map(m => m.Address).Name("address");//.Index(0);
            Map(m => m.City).Name("city");//.Index(1);
            Map(m => m.Province).Name("province");//.Index(2);
            Map(m => m.Postal).Name("postal");//.Index(3);
            //Map(m => m.Address).Name("address").Index(0);
            //Map(m => m.City).Name("city").Index(1);
            //Map(m => m.Province).Name("province").Index(2);
            //Map(m => m.Postal).Name("postal").Index(3);
        }
    }
}