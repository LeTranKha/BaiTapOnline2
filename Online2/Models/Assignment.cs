using System;
using System.Collections.Generic;

namespace Online2.Models
{
    public partial class Assignment
    {
        public string Code { get; set; } = null!;
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? Telephone { get; set; }
        public DateTime AssignmentDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public short? Status { get; set; }
        public string? ServiceCode { get; set; }
        public string? DeviceCode { get; set; }

        public virtual Device? DeviceCodeNavigation { get; set; }
        public virtual Service? ServiceCodeNavigation { get; set; }
    }
}
