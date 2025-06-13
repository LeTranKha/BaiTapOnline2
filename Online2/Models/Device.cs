using System;
using System.Collections.Generic;

namespace Online2.Models
{
    public partial class Device
    {
        public Device()
        {
            Assignments = new HashSet<Assignment>();
        }

        public string DeviceCode { get; set; } = null!;
        public string? DeviceName { get; set; }
        public string? IpAddress { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool? Connected { get; set; }
        public bool? OperationStatus { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
