using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Employee
{
    public class Employee : AuditableEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Region.Region Region { get; set; }
    }
}
