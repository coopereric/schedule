using System;
using System.Collections.Generic;

namespace Schedule.Models.Models
{
    public partial class Schedule
    {
        public int ScheduleId { get; set; }
        public string Description { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime Pkdate { get; set; }
        public int ShiftId { get; set; }
        public string UserId { get; set; }

        public Date PkdateNavigation { get; set; }
        public Shift Shift { get; set; }
        public AspNetUsers User { get; set; }
    }
}
