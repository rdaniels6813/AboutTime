using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AboutTime.Models;

namespace AboutTime.Controllers
{
    [Produces("application/json")]
    [Route("api/TimeCards")]
    public class TimeCardsController : Controller
    {
        private readonly ATContext _context;

        public TimeCardsController(ATContext context)
        {
            _context = context;
        }

        // GET: api/TimeCards
        [HttpGet]
        public IEnumerable<TimeCard> GetTimeCards()
        {
            return _context.TimeCards;
        }

        // GET: api/TimeCards/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTimeCard([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timeCard = await _context.TimeCards.SingleOrDefaultAsync(m => m.Id == id);

            if (timeCard == null)
            {
                return NotFound();
            }

            return Ok(timeCard);
        }

        // PUT: api/TimeCards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeCard([FromRoute] Guid id, [FromBody] TimeCard timeCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != timeCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(timeCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeCardExists(id))
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

        // POST: api/TimeCards
        [HttpPost]
        public async Task<IActionResult> PostTimeCard([FromBody] TimeCard timeCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TimeCards.Add(timeCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimeCard", new { id = timeCard.Id }, timeCard);
        }

        // DELETE: api/TimeCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeCard([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timeCard = await _context.TimeCards.SingleOrDefaultAsync(m => m.Id == id);
            if (timeCard == null)
            {
                return NotFound();
            }

            _context.TimeCards.Remove(timeCard);
            await _context.SaveChangesAsync();

            return Ok(timeCard);
        }

        private bool TimeCardExists(Guid id)
        {
            return _context.TimeCards.Any(e => e.Id == id);
        }
    }
}