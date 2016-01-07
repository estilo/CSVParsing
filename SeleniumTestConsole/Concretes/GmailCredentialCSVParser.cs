using CsvHelper;
using CsvHelper.Configuration;
using SeleniumTestConsole.Interfaces;
using SeleniumTestConsole.Models.ClassMap;
using System.Collections.Generic;
using System.IO;
using SeleniumTestConsole.Models;

namespace SeleniumTestConsole.Concretes
{
    public class GmailCredentialCSVParser : ICSVParser<GmailCredential>
    {
        public List<GmailCredential> Parse(string filename)
        {
            List<GmailCredential> list;
            using (TextReader reader = File.OpenText(filename))
            {
                list = Parse(reader);
            }
            return list;
        }

        public List<GmailCredential> Parse(TextReader textReader)
        {
            var csvConfiguration = new CsvConfiguration();
            csvConfiguration.RegisterClassMap<GmailCredentialMap>();

            var csv = new CsvReader(textReader, csvConfiguration);
            var allRecords = new List<GmailCredential>();
            while (csv.Read())
                allRecords.Add(csv.GetRecord<GmailCredential>());

            return allRecords;
        }
    }
}