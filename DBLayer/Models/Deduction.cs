using System;

namespace DBLayer.Models
{
    public class Deduction
    {
        public virtual Guid EmployeeId { get; set; }
        public virtual string Deduction1 { get; set; }
    }
}