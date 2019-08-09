using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExemploWebApiController : ControllerBase
    {
        private readonly ExemploWebApiContext _context;

        public ExemploWebApiController(ExemploWebApiContext context)
        {
            _context = context;

            // if(_context.ExemploWebApiItems.Count() == 0)
            // {
            //     _context.ExemploWebApiItems.Add(new ExemploWebApiItem {Name = "Item1"});
            //     _context.SaveChanges();
            // }
        }
        // GET api/ExemploWebApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExemploWebApiItem>>> GetItems()
        {
            return await _context.ExemploWebApiItems.ToListAsync();
        }

        // GET api/ExemploWebApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExemploWebApiItem>> GetItem(long id)
        {
            var ExemploWebApiItem = await _context.ExemploWebApiItems.FindAsync(id);

            if(ExemploWebApiItem == null)
            {
                return NotFound();
            }
            return ExemploWebApiItem;
        }

        // POST api/ExemploWebApi
        [HttpPost]
        public async Task<ActionResult<IEnumerable<ExemploWebApiItem>>> PostExemploWebApiItem(ExemploWebApiItem item)
        {
            _context.ExemploWebApiItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItem), new ExemploWebApiItem{Id = item.Id}, item);
        }

        // PUT api/ExemploWebApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(long id, ExemploWebApiItem item)
        {
            if(id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
       }

        // DELETE api/ExemploWebApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(long id)
        {
            var ExemploWebApiItem = await _context.ExemploWebApiItems.FindAsync(id);

            if(ExemploWebApiItem == null)
            {
                return NotFound();
            }

            _context.ExemploWebApiItems.Remove(ExemploWebApiItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
