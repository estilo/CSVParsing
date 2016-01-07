using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestConsole.Models.ClassMap
{
    public class GmailCredentialMap : CsvClassMap<GmailCredential>
    {
        public GmailCredentialMap()
        {
            Map(m => m.Username).Name("username");
            Map(m => m.Password).Name("password");
        }
    }
}
