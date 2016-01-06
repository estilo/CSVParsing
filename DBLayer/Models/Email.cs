using System;

namespace DBLayer.Models
{
    public class Email
    {
        public virtual Guid EmployeeId { get; set; }
        public virtual string EmailId { get; set; }
    }
}