using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schedule.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule.Api.Controllers
{
    public class UsersController : Controller
    {
        private readonly ScheduleDBContext context;

        public UsersController(ScheduleDBContext _context)
        {
            context = _context;
        }

        [HttpGet]
        [Route("api/GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = from u in context.AspNetUsers
                        select new
                        {
                            Id    = u.Id,
                            Email = u.Email,
                            Phone = u.PhoneNumber
                        };

            return Json(users);
        }

        [HttpGet]
        [Route("api/GetUser")]
        public async Task<IActionResult> GetUserById(string id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var user = await context.AspNetUsers.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

            if(user == null)
            {
                return NotFound();
            }
            return Json(user);
        }
    }
}
