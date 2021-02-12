using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Region
{
    public class Region : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
        public Region ParentRegion { get; set; }
    }
}
