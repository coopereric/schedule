using Microsoft.AspNetCore.Mvc;
using Schedule.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule.Api.Controllers
{
    public class ShiftsController : Controller
    {
        private readonly ScheduleDBContext context;

        public ShiftsController(ScheduleDBContext _context)
        {
            context = _context;
        }

        [HttpGet]
        [Route("api/GetShifts")]
        public IActionResult GetAllShifts()
        {
            var shifts = from s in context.Shift
                         select s;

            return Json(shifts);
        }


    }
}
