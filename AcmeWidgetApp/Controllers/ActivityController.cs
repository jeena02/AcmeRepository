using AcmeWidgetApp.Data;
using AcmeWidgetApp.Models.Registration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcmeWidgetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly AcmeWidgetDBContext _context;

        public ActivityController(AcmeWidgetDBContext context)
        {
            _context = context;
        }
        // GET: api/GetAllActivitiess
        [HttpGet("GetAllActivities")]

        public async Task<ActionResult<IEnumerable<Activity>>> GetAllActivities()
        {
            return await _context.Activity.ToListAsync();
        }

        // GET api/api/GetActivityById/5
        [HttpGet("GetActivityById/{id}")]
        public async Task<ActionResult<Activity>> GetActivityById(int id)
        {
            var activity = await _context.Activity.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }
            return activity;
        }
    }
}
