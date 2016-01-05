using CsvHelper.Configuration;

namespace ParserNVerify.Models.ClassMap
{
    public class PersonDetailMap : CsvClassMap<PersonDetail>
    {
        public PersonDetailMap()
        {
            Map(m => m.PatientID).Name("PatientID");
            Map(m => m.EMail).Name("E-mail");
            Map(m => m.Password).Name("password");
            References<PersonMap>(m => m.Person);
            Map(m => m.Month).Name("month");
            Map(m => m.Day).Name("day");
            Map(m => m.Year).Name("year");
            References<PostalAddressMap>(m => m.Address);
            Map(m => m.Phone).Name("phone");
            Map(m => m.Condition).Name("condition");
            Map(m => m.Symptom).Name("symptom");
        }
    }
}