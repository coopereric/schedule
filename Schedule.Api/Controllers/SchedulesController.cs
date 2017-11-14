using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Schedule.Models.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Schedule.Api.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly ScheduleDBContext context;

        public SchedulesController(ScheduleDBContext _context)
        {
            context = _context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult GetAllSchedules()
        {
            var results = from s in context.Schedule
                          select new
                          {
                              Id            = s.ScheduleId,
                              User          = s.UserId,
                              TimeIn        = s.Shift.TimeIn,
                              TimeOut       = s.Shift.TimeOut,
                              LunchStart    = s.Shift.LunchStart,
                              LunchEnd      = s.Shift.LunchEnd
                          };

            return Json(results);
        }
    }
}
