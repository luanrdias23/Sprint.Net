using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgroSenseAPI.Data;
using AgroSenseAPI.models;

namespace AgroSenseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VegetaisController : ControllerBase
    {
        private readonly AgroSenseContext _context;

        public VegetaisController(AgroSenseContext context)
        {
            _context = context;
        }

        // GET: api/vegetais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vegetal>>> GetVegetais()
        {
            return await _context.Vegetais.ToListAsync();
        }

        // GET: api/vegetais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vegetal>> GetVegetal(int id)
        {
            var vegetal = await _context.Vegetais.FindAsync(id);

            if (vegetal == null)
            {
                return NotFound();
            }

            return vegetal;
        }

        // POST: api/vegetais
        [HttpPost]
        public async Task<ActionResult<Vegetal>> PostVegetal(Vegetal vegetal)
        {
            _context.Vegetais.Add(vegetal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVegetal), new { id = vegetal.IdVegetais }, vegetal);
        }

        // PUT: api/vegetais/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVegetal(int id, Vegetal vegetal)
        {
            if (id != vegetal.IdVegetais)
            {
                return BadRequest();
            }

            _context.Entry(vegetal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VegetalExists(id))
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

        // DELETE: api/vegetais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVegetal(int id)
        {
            var vegetal = await _context.Vegetais.FindAsync(id);
            if (vegetal == null)
            {
                return NotFound();
            }

            _context.Vegetais.Remove(vegetal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VegetalExists(int id)
        {
            return _context.Vegetais.Any(e => e.IdVegetais == id);
        }
    }
}
