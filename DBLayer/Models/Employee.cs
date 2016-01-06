using System;

namespace DBLayer.Models
{
    public class Employee
    {
        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}