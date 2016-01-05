namespace ParserNVerify.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        public override string ToString()
        {
            return string.Format("{0}|{1}|{2}", FirstName, LastName, Gender);
        }
    }
}