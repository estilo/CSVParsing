using System;

namespace DBLayer.Models
{
    public class Address
    {
        public virtual Guid EmployeeId { get; set; }
        public virtual string Street { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual int ZipCode { get; set; }
    }
}