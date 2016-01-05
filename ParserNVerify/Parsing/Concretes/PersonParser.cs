using CsvHelper;
using CsvHelper.Configuration;
using ParserNVerify.Models;
using ParserNVerify.Models.ClassMap;
using ParserNVerify.Parsing.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace ParserNVerify.Parsing.Concretes
{
    public class PersonParser : IPersonParser
    {
        public List<Person> Parse(string filename)
        {
            List<Person> list;
            using (TextReader reader = File.OpenText(filename))
            {
                list = Parse(reader);
            }
            return list;
        }

        public List<Person> Parse(TextReader textReader)
        {
            var csvConfiguration = new CsvConfiguration();
            csvConfiguration.RegisterClassMap<PersonMap>();

            var csv = new CsvReader(textReader, csvConfiguration);
            var allRecords = new List<Person>();
            while (csv.Read())
                allRecords.Add(csv.GetRecord<Person>());

            return allRecords;
        }
    }
}