namespace ParserNVerify.Models
{
    public class PostalAddress
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Postal { get; set; }

        public override string ToString()
        {
            return string.Format("{0}|{1}|{2}|{3}", Address, City, Province, Postal);
        }
    }
}