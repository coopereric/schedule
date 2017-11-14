using System;
using System.Collections.Generic;

namespace Schedule.Models.Models
{
    public partial class Shift
    {
        public Shift()
        {
            Schedule = new HashSet<Schedule>();
        }

        public int ShiftId { get; set; }
        public DateTime ShiftDate { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public DateTime? LunchStart { get; set; }
        public DateTime? LunchEnd { get; set; }

        public Date ShiftDateNavigation { get; set; }
        public ICollection<Schedule> Schedule { get; set; }
    }
}
