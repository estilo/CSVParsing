using CsvHelper;
using CsvHelper.Configuration;
using ParserNVerify.Models;
using ParserNVerify.Models.ClassMap;
using ParserNVerify.Parsing.Interfaces;
using System.Collections.Generic;
using System.IO;
using System;

namespace ParserNVerify.Parsing.Concretes
{
    public class ProductInfoParser : IProductInfoParser
    {
        public List<ProductInfo> Parse(TextReader textReader)
        {
            var csvConfiguration = new CsvConfiguration();
            //csvConfiguration.HasHeaderRecord = false;
            csvConfiguration.RegisterClassMap<ProductInfoMap>();

            var csv = new CsvReader(textReader, csvConfiguration);
            var allRecords = new List<ProductInfo>();
            while (csv.Read())
                allRecords.Add(csv.GetRecord<ProductInfo>());

            return allRecords;
        }

        public List<ProductInfo> Parse(string filename)
        {
            List<ProductInfo> list;
            using (TextReader reader = File.OpenText(filename))
            {
                list = Parse(reader);
            }
            return list;
        }
    }

    public class AddressParser : IAddressParser
    {
        public List<PostalAddress> Parse(string filename)
        {
            List<PostalAddress> list;
            using (TextReader reader = File.OpenText(filename))
            {
                list = Parse(reader);
            }
            return list;
        }

        public List<PostalAddress> Parse(TextReader textReader)
        {
            var csvConfiguration = new CsvConfiguration();
            //csvConfiguration.HasHeaderRecord = false;
            csvConfiguration.RegisterClassMap<PostalAddressMap>();

            var csv = new CsvReader(textReader, csvConfiguration);
            var allRecords = new List<PostalAddress>();
            while (csv.Read())
                allRecords.Add(csv.GetRecord<PostalAddress>());

            return allRecords;
        }
    }
}