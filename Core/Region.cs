using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Region
{
    public class Region : AuditableEntity
    {
        public int RegionId { get; set; }
        public string Name { get; set; }        
        public Region ParentRegion { get; set; }
        public List<Employee.Employee> Employees { get; set; }
    }
}
