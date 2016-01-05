using CsvHelper.Configuration;

namespace ParserNVerify.Models.ClassMap
{
    public class PersonMap : CsvClassMap<Person>
    {
        public PersonMap()
        {
            Map(m => m.FirstName).Name("fname");//.Index(0);
            Map(m => m.LastName).Name("lname");//.Index(1);
            Map(m => m.Gender).Name("gender");//.Index(2);
        }
    }
}