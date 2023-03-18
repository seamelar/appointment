using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeedAPI;
using FeedAPI.Models;

namespace FeedAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedingHistoryController : ControllerBase
    {
        private readonly DataContext _context;

        public FeedingHistoryController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FeedingHistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feed>>> GetFeedingHistory()
        {
            return await _context.FeedingHistory.ToListAsync();
        }

        // GET: api/FeedingHistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feed>> GetFeed(int id)
        {
            var feed = await _context.FeedingHistory.FindAsync(id);

            if (feed == null)
            {
                return NotFound();
            }

            return feed;
        }

        // PUT: api/FeedingHistory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeed(int id, Feed feed)
        {
            if (id != feed.Id)
            {
                return BadRequest();
            }

            _context.Entry(feed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedExists(id))
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

        // POST: api/FeedingHistory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Feed>> PostFeed(Feed feed)
        {
            _context.FeedingHistory.Add(feed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeed", new { id = feed.Id }, feed);
        }

        // DELETE: api/FeedingHistory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeed(int id)
        {
            var feed = await _context.FeedingHistory.FindAsync(id);
            if (feed == null)
            {
                return NotFound();
            }

            _context.FeedingHistory.Remove(feed);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeedExists(int id)
        {
            return _context.FeedingHistory.Any(e => e.Id == id);
        }
    }
}
