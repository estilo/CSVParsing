using ParserNVerify.Models;
using ParserNVerify.Parsing.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestConsole
{
    public class Program
    {
        private static void Main(string[] args)
        {
            
            displayList<PostalAddress>(new AddressParser().Parse("Address.csv"));
            displayList<Person>(new PersonParser().Parse("names.csv"));
            displayList<string>(new SingleColumnParser().Parse("usernames.txt"));
            displayList<string>(new SingleColumnParser().Parse("domains.txt"));

            WritePersonDetails();
            Console.ReadLine();
        }

        private static void WritePersonDetails()
        {
            var pd = new PersonDetail
            {
                //PatientID = "AB1234PQ",
                Person = new Person
                {
                    //Gender = "male",
                    //FirstName = "rob",
                    LastName = "ford"
                },
                Address = new PostalAddress
                {
                    Address = "200 king street",
                    Province = "ON",
                    Postal = "M9P1Z3",
                    City = "Toronto"
                },
                Condition = "all good",
                Day = 15,
                Month = 12,
                Year = 2015,
                EMail = "coolers@cool.com",
                //Password = "123456",
                Phone = "123-456-3333",
                Symptom = "no-headache"
            };
            var list = new List<PersonDetail>();
            list.Add(pd);
            new PersonDetailWriter().Write("combined.csv", list, true);
        }

        
        private static void displayList<T>(List<T> list)
        {
            if (list != null && list.Any())
                foreach (var item in list)
                    Console.WriteLine(item);
        }
    }
}