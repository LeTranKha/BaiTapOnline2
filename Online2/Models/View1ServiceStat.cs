using System;
using System.Collections.Generic;

namespace Online2.Models
{
    public partial class View1ServiceStat
    {
        public string? ServiceCode { get; set; }
        public string? ServiceName { get; set; }
        public long? TotalCurrentYear { get; set; }
        public long? TotalCurrentMonth { get; set; }
        public long? TotalCurrentWeek { get; set; }
    }
}
