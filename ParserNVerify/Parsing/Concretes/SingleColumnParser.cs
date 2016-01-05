using CsvHelper;
using CsvHelper.Configuration;
using ParserNVerify.Parsing.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace ParserNVerify.Parsing.Concretes
{
    public class SingleColumnParser : ISingleColumnParser
    {
        public List<string> Parse(string filename)
        {
            List<string> list;
            using (TextReader reader = File.OpenText(filename))
            {
                list = Parse(reader);
            }
            return list;
        }

        public List<string> Parse(TextReader textReader)
        {
            var csvConfiguration = new CsvConfiguration();
            csvConfiguration.HasHeaderRecord = false;

            var csv = new CsvReader(textReader, csvConfiguration);
            var allRecords = new List<string>();
            while (csv.Read())
                allRecords.Add(csv.GetField(0));

            return allRecords;
        }
    }
}