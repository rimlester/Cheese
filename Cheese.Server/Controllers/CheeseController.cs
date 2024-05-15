﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cheese.Server;

namespace Cheese.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheeseController : ControllerBase
    {
        private readonly CheeseDbContext _context;

        public CheeseController(CheeseDbContext context)
        {
            _context = context;
        }

        // GET: api/Cheese
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cheese>>> GetCheeses()
        {
            return await _context.Cheeses.ToListAsync();
        }

        // GET: api/Cheese/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cheese>> GetCheese(Guid id)
        {
            var cheese = await _context.Cheeses.FindAsync(id);

            if (cheese == null)
            {
                return NotFound();
            }

            return cheese;
        }

        // PUT: api/Cheese/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCheese(Guid id, Cheese cheese)
        {
            if (id != cheese.Id)
            {
                return BadRequest();
            }

            _context.Entry(cheese).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheeseExists(id))
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

        // POST: api/Cheese
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cheese>> PostCheese(Cheese cheese)
        {
            _context.Cheeses.Add(cheese);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCheese", new { id = cheese.Id }, cheese);
        }

        // DELETE: api/Cheese/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCheese(Guid id)
        {
            var cheese = await _context.Cheeses.FindAsync(id);
            if (cheese == null)
            {
                return NotFound();
            }

            _context.Cheeses.Remove(cheese);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CheeseExists(Guid id)
        {
            return _context.Cheeses.Any(e => e.Id == id);
        }
    }
}