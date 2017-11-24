using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        [HttpPost]
        [Route("api/CreateShift")]
        public async Task<IActionResult> CreateShift(Shift shift)
        {
            if(shift == null)
            {
                return BadRequest();
            }

            try
            {
                context.Shift.Add(shift);
                await context.SaveChangesAsync();
            }
            catch(DbUpdateException ex)
            {
                ModelState.AddModelError(ex.Message, "Error creating shift: " + shift.ShiftId);
            }

            return Ok();
        }


    }
}
