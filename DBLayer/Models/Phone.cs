using System;

namespace DBLayer.Models
{
    public class Phone
    {
        public virtual Guid EmployeeId { get; set; }
        public virtual string Home { get; set; }
        public virtual string Mobile { get; set; }
    }
}