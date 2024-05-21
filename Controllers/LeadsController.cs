using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeadTechAPI.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadTechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly LeadTechAPIContext _context;

        public LeadsController(LeadTechAPIContext context)
        {
            _context = context;
        }

        // GET: api/Leads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lead>>> GetLeads()
        {
            return await _context.Leads.ToListAsync();
        }

        // GET: api/Leads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lead>> GetLead(int id)
        {
            var lead = await _context.Leads.FindAsync(id);

            if (lead == null)
            {
                return NotFound();
            }

            return lead;
        }

        // PUT: api/Leads/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLead(int id, Lead lead)
        {
            if (id != lead.IdLead)
            {
                return BadRequest();
            }

            _context.Entry(lead).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadExists(id))
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

        // POST: api/Leads
        [HttpPost]
        public async Task<ActionResult<Lead>> PostLead(Lead lead)
        {
            _context.Leads.Add(lead);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLead", new { id = lead.IdLead }, lead);
        }

        // DELETE: api/Leads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLead(int id)
        {
            var lead = await _context.Leads.FindAsync(id);
            if (lead == null)
            {
                return NotFound();
            }

            _context.Leads.Remove(lead);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LeadExists(int id)
        {
            return _context.Leads.Any(e => e.IdLead == id);
        }
    }
}
