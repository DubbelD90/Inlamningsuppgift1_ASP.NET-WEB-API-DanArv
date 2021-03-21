using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Uppgift1.Data;
using WebApi_Uppgift1.Models;

namespace WebApi_Uppgift1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CasesController : ControllerBase
    {
        private readonly SqlDbContext _context;


        public CasesController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: api/Cases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Case>>> GetCases([FromQuery] string status, int Id, int clientId, DateTime date)
        {
            var queryable = _context.Cases.AsQueryable();
            if (!string.IsNullOrEmpty(status))
            {
                queryable = queryable.Where(q => q.StatusId == status);
            }
            if(Id >= 1)
            {
                queryable = queryable.Where(q => q.Id == Id);
            }
            if(clientId >= 1)
            {
                queryable = queryable.Where(q => q.ClientId == clientId);
            }
            if(date != DateTime.MinValue)
            {
                queryable = queryable.Where(q => q.Created.Date == date);
            }

            return new OkObjectResult(await queryable.ToListAsync());
        }

        // GET: api/Cases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Case>> GetCase(long id)
        {
            var @case = await _context.Cases.FindAsync(id);

            if (@case == null)
            {
                return NotFound();
            }

            return @case;
        }

        // PUT: api/Cases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCase(long id, Case @case)
        {
            if (id != @case.Id)
            {
                return BadRequest();
            }

            _context.Entry(@case).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseExists(id))
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

        // POST: api/Cases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Case>> PostCase(Case @case)
        {
            _context.Cases.Add(@case);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCase", new { id = @case.Id }, @case);
        }

        // DELETE: api/Cases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCase(long id)
        {
            var @case = await _context.Cases.FindAsync(id);
            if (@case == null)
            {
                return NotFound();
            }

            _context.Cases.Remove(@case);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CaseExists(long id)
        {
            return _context.Cases.Any(e => e.Id == id);
        }
    }
}
