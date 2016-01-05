using CsvHelper;
using CsvHelper.Configuration;
using ParserNVerify.Models;
using ParserNVerify.Models.ClassMap;
using ParserNVerify.Parsing.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace ParserNVerify.Parsing.Concretes
{
    public class PersonDetailWriter : IPersonDetailWriter
    {
        public void Write(TextWriter textWriter, List<PersonDetail> records, bool writeheader)
        {
            var csvConfiguration = new CsvConfiguration();
            csvConfiguration.RegisterClassMap<PersonDetailMap>();
            var csv = new CsvWriter(textWriter, csvConfiguration);
            if (writeheader)
                csv.WriteHeader<PersonDetail>();
            foreach (var record in records)
                csv.WriteRecord(record);
        }

        public void Write(string filename, List<PersonDetail> records, bool writeheader)
        {
            var textWriter = new StreamWriter(filename);
            Write(textWriter, records, writeheader);
            textWriter.Close();
        }
    }
}