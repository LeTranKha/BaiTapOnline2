using System;
using System.Collections.Generic;

namespace Online2.Models
{
    public partial class Service
    {
        public Service()
        {
            Assignments = new HashSet<Assignment>();
        }

        public string ServiceCode { get; set; } = null!;
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public bool? IsInOperation { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
