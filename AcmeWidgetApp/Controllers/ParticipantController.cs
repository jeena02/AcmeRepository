using AcmeWidgetApp.Data;
using AcmeWidgetApp.Models.Registration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeWidgetApp.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly AcmeWidgetDBContext _context;

        public ParticipantController(AcmeWidgetDBContext context)
        {
            _context = context;
        }
        // GET: api/ParticipantInfo
        [HttpGet("GetAllParticipants")]
        public async Task<ActionResult<IEnumerable<ParticipantInfo>>> GetAllParticipants()
        {
            return await _context.ParticipantInfo.Include(n => n.ActivityList).ToListAsync();
        }

        // GET api/GetParticipantById/5
        [HttpGet("GetParticipantById/{id}")]
        public async Task<ActionResult<ParticipantInfo>> GetParticipantById(int id)
        {
            var participant = await _context.ParticipantInfo.FindAsync(id);
            if (participant == null)
            {
                return NotFound();
            }
            return participant;
        }


        // PUT: api/Participant/5

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParticipant(int id, ParticipantInfo participant)
        {
            participant.Id = id;

            _context.Entry(participant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST api/participant
        [HttpPost("AddParticipant")]
        public async Task<ActionResult<ParticipantInfo>> AddParticipant(ParticipantInfo participant)
        {
           
            try
            {
                participant.ActivityList = await _context.Activity.FindAsync(participant.ActivityId);

                _context.ParticipantInfo.Add(participant);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetParticipantById", new { id = participant.Id }, participant);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        // DELETE api/ParticipantInfo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ParticipantInfo>> DeleteSubscriber(int id)
        {
            var participant = await _context.ParticipantInfo.FindAsync(id);
            if (participant == null)
            {
                return NotFound();
            }

            _context.ParticipantInfo.Remove(participant);
            await _context.SaveChangesAsync();

            return participant;
        }

        private bool ParticipantExists(int id)
        {
            return _context.ParticipantInfo.Any(e => e.Id == id);
        }

        [HttpGet("GetRelatedParticipants/{id}")]
        public async Task<ActionResult<IEnumerable<ParticipantInfo>>> GetRelatedParticipants(int id)
        {

            return await _context.ParticipantInfo
                .Where(x => x.ActivityId == Convert.ToInt32(id))
                .ToListAsync();
        }

    }
}
