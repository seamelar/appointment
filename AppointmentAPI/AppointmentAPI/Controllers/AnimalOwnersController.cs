using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppointmentAPI;
using MyLibrary;

namespace AppointmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalOwnersController : ControllerBase
    {
        private readonly DataContext _context;

        public AnimalOwnersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/AnimalOwners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalOwner>>> GetOwners()
        {
            return await _context.Owners.ToListAsync();
        }

        // GET: api/AnimalOwners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalOwner>> GetAnimalOwner(int id)
        {
            var animalOwner = await _context.Owners.FindAsync(id);

            if (animalOwner == null)
            {
                return NotFound();
            }

            return animalOwner;
        }

        // PUT: api/AnimalOwners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimalOwner(int id, AnimalOwner animalOwner)
        {
            if (id != animalOwner.Id)
            {
                return BadRequest();
            }

            _context.Entry(animalOwner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalOwnerExists(id))
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

        // POST: api/AnimalOwners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnimalOwner>> PostAnimalOwner(AnimalOwner animalOwner)
        {
            _context.Owners.Add(animalOwner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimalOwner", new { id = animalOwner.Id }, animalOwner);
        }

        // DELETE: api/AnimalOwners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimalOwner(int id)
        {
            var animalOwner = await _context.Owners.FindAsync(id);
            if (animalOwner == null)
            {
                return NotFound();
            }

            _context.Owners.Remove(animalOwner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalOwnerExists(int id)
        {
            return _context.Owners.Any(e => e.Id == id);
        }
    }
}
