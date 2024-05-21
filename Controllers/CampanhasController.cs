using LeadTechAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadTechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampanhasController : ControllerBase
    {
        private readonly LeadTechAPIContext _context;

        public CampanhasController(LeadTechAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campanha>>> GetCampanhas()
        {
            return await _context.Campanhas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Campanha>> GetCampanha(int id)
        {
            var campanha = await _context.Campanhas.FindAsync(id);

            if (campanha == null)
            {
                return NotFound();
            }

            return campanha;
        }

        [HttpPost]
        public async Task<ActionResult<Campanha>> PostCampanha(Campanha campanha)
        {
            _context.Campanhas.Add(campanha);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCampanha), new { id = campanha.IdCampanha }, campanha);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampanha(int id, Campanha campanha)
        {
            if (id != campanha.IdCampanha)
            {
                return BadRequest();
            }

            _context.Entry(campanha).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampanhaExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampanha(int id)
        {
            var campanha = await _context.Campanhas.FindAsync(id);
            if (campanha == null)
            {
                return NotFound();
            }

            _context.Campanhas.Remove(campanha);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CampanhaExists(int id)
        {
            return _context.Campanhas.Any(e => e.IdCampanha == id);
        }
    }
}
