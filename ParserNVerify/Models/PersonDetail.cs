namespace ParserNVerify.Models
{
    public class PersonDetail
    {
        public string PatientID { get; set; }

        public string EMail { get; set; }
        public string Password { get; set; }
        public Person Person { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }
        public PostalAddress Address { get; set; }
        public string Phone { get; set; }
        public string Condition { get; set; }
        public string Symptom { get; set; }
    }
}