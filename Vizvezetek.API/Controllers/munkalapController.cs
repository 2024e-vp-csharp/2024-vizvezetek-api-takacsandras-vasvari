﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vizvezetek.API.Models;

namespace Vizvezetek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class munkalapController : ControllerBase
    {
        private readonly vizvezetekContext _context;

        public munkalapController(vizvezetekContext context)
        {
            _context = context;
        }

        // GET: api/munkalap
        [HttpGet]
        public async Task<ActionResult<IEnumerable<munkalap>>> Getmunkalap()
        {
            return await _context.munkalap.ToListAsync();
        }

        // GET: api/munkalap/5
        [HttpGet("{id}")]
        public async Task<ActionResult<munkalap>> Getmunkalap(int id)
        {
            var munkalap = await _context.munkalap.FindAsync(id);

            if (munkalap == null)
            {
                return NotFound();
            }

            return munkalap;
        }

        // PUT: api/munkalap/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmunkalap(int id, munkalap munkalap)
        {
            if (id != munkalap.id)
            {
                return BadRequest();
            }

            _context.Entry(munkalap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!munkalapExists(id))
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

        // POST: api/munkalap
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<munkalap>> Postmunkalap(munkalap munkalap)
        {
            _context.munkalap.Add(munkalap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getmunkalap", new { id = munkalap.id }, munkalap);
        }

        // DELETE: api/munkalap/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemunkalap(int id)
        {
            var munkalap = await _context.munkalap.FindAsync(id);
            if (munkalap == null)
            {
                return NotFound();
            }

            _context.munkalap.Remove(munkalap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool munkalapExists(int id)
        {
            return _context.munkalap.Any(e => e.id == id);
        }
    }
}
