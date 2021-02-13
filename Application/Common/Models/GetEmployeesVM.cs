using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models
{
    public class GetEmployeesVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Regions { get; set; }
    }
}
