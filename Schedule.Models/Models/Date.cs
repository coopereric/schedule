using System;
using System.Collections.Generic;

namespace Schedule.Models.Models
{
    public partial class Date
    {
        public Date()
        {
            Schedule = new HashSet<Schedule>();
            Shift = new HashSet<Shift>();
        }

        public DateTime Pkdate { get; set; }
        public byte? CalendarDayInMonth { get; set; }
        public byte? CalendarDayInWeek { get; set; }
        public short? CalendarDayInYear { get; set; }
        public byte? CalendarMonth { get; set; }
        public string CalendarMonthNameLong { get; set; }
        public string CalendarMonthNameShort { get; set; }
        public byte? CalendarQuarter { get; set; }
        public string CalendarQuarterDesc { get; set; }
        public byte? CalendarWeekInMonth { get; set; }
        public byte? CalendarWeekInYear { get; set; }
        public short? CalendarYear { get; set; }
        public int? ContinuousDay { get; set; }
        public short? ContinuousMonth { get; set; }
        public short? ContinuousQuarter { get; set; }
        public short? ContinuousWeek { get; set; }
        public byte? ContinuousYear { get; set; }
        public string DayNameLong { get; set; }
        public string DayNameShort { get; set; }
        public string Description { get; set; }
        public byte? IsEvent { get; set; }
        public byte? IsHoliday { get; set; }
        public byte? IsWeekend { get; set; }
        public byte? IsWorkday { get; set; }
        public string MdyNameLong { get; set; }
        public string MdyNameLongWithSuffix { get; set; }

        public ICollection<Schedule> Schedule { get; set; }
        public ICollection<Shift> Shift { get; set; }
    }
}
