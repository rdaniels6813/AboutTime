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
    [Route("api/Connectors")]
    public class ConnectorsController : Controller
    {
        private readonly ATContext _context;

        public ConnectorsController(ATContext context)
        {
            _context = context;
        }

        // GET: api/Connectors
        [HttpGet]
        public IEnumerable<Connector> GetConnectors()
        {
            return _context.Connectors;
        }

        // GET: api/Connectors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConnector([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var connector = await _context.Connectors.SingleOrDefaultAsync(m => m.Id == id);

            if (connector == null)
            {
                return NotFound();
            }

            return Ok(connector);
        }

        // PUT: api/Connectors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConnector([FromRoute] Guid id, [FromBody] Connector connector)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != connector.Id)
            {
                return BadRequest();
            }

            _context.Entry(connector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConnectorExists(id))
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

        // POST: api/Connectors
        [HttpPost]
        public async Task<IActionResult> PostConnector([FromBody] Connector connector)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Connectors.Add(connector);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConnector", new { id = connector.Id }, connector);
        }

        // DELETE: api/Connectors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConnector([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var connector = await _context.Connectors.SingleOrDefaultAsync(m => m.Id == id);
            if (connector == null)
            {
                return NotFound();
            }

            _context.Connectors.Remove(connector);
            await _context.SaveChangesAsync();

            return Ok(connector);
        }

        private bool ConnectorExists(Guid id)
        {
            return _context.Connectors.Any(e => e.Id == id);
        }
    }
}