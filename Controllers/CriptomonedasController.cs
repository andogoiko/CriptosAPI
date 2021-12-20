using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Criptomonedas.Models;

namespace Criptomonedas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriptomonedasController : ControllerBase
    {
        private readonly CriptomonedasContext _context;

        public CriptomonedasController(CriptomonedasContext context)
        {
            _context = context;
        }

        // GET: api/Criptomonedas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Criptomoneda>>> GetCriptomonedas()
        {

            foreach (var moneda in _context.Criptomoneda.ToList())
            {
                moneda.lastValor = Math.Round((decimal)new Random().NextDouble() * 1000000, 2);

                if (moneda.lastValor > moneda.maxValor)
                {
                    moneda.maxValor = moneda.lastValor;
                }
            }

            _context.SaveChanges();

            return await _context.Criptomoneda.ToListAsync();
        }

        // GET: api/Criptomonedas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Criptomoneda>> GetCriptomonedas(string id)
        {
            var criptomoneda = await _context.Criptomoneda.FindAsync(id);

            if (criptomoneda == null)
            {
                return NotFound();
            }

            criptomoneda.lastValor = Math.Round((decimal)new Random().NextDouble() * 1000000, 2);

            if (criptomoneda.lastValor > criptomoneda.maxValor)
            {
                criptomoneda.maxValor = criptomoneda.lastValor;
            }

            _context.SaveChanges();

            return criptomoneda;
        }

        // PUT: api/Criptomonedas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCriptomonedas(string id, Criptomoneda criptomoneda)
        {
            if (id != criptomoneda.moneda)
            {
                return BadRequest();
            }

            _context.Entry(criptomoneda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CriptomonedasExists(id))
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

        // POST: api/Criptomonedas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Criptomoneda>> PostCriptomonedas(Criptomoneda criptomoneda)
        {
            _context.Criptomoneda.Add(criptomoneda);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CriptomonedasExists(criptomoneda.moneda))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCriptomonedas", new { id = criptomoneda.moneda }, criptomoneda);
        }

        // DELETE: api/Criptomonedas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCriptomonedas(string id)
        {
            var criptomoneda = await _context.Criptomoneda.FindAsync(id);
            if (criptomoneda == null)
            {
                return NotFound();
            }

            _context.Criptomoneda.Remove(criptomoneda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CriptomonedasExists(string id)
        {
            return _context.Criptomoneda.Any(e => e.moneda == id);
        }
    }
}
