using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wevi.Models;

namespace wevi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly WevDbContext _context;

        public EventsController(WevDbContext context)
        {
            _context = context;
        }

        // GET: api/Events
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Event>>> GetEvent()
        //{
        //    return await _context.Event.ToListAsync();
        //}

        [HttpGet]
        public async Task<outputEvents> GetEvent()
        {
            //await _context.User.ToListAsync();

            outputEvents output = new outputEvents();

            try
            {
                output.Result = "OK";
                output.events = await _context.Event.ToListAsync();
                output.Message = "Success";
            }
            catch (Exception ex)
            {
                output.Result = "NG";
                output.Message = ex.ToString();
            }
            return output;

        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Event>> GetEvent(int id)
        public async Task<outputEvents> GetEvent(int id)
        {
            outputEvents output = new outputEvents();

            try
            {
                var evt = await _context.Event.FindAsync(id);

                if (evt != null)
                {
                    output.Result = "OK";
                    output.events = evt;
                    output.Message = "Success";
                }
                else
                {
                    output.Result = "NG";
                    output.Message = "Failure";
                }
            }
            catch (Exception ex)
            {
                output.Result = "NG";
                output.Message = ex.ToString();
            }
            return output;
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event @event)
        {
            if (id != @event.eventid)
            {
                return BadRequest();
            }

            _context.Entry(@event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/Events
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event @event)
        {
            _context.Event.Add(@event);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = @event.eventid }, @event);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Event>> DeleteEvent(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();

            return @event;
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.eventid == id);
        }
    }
}
