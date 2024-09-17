using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.database;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/item")]
    public class ItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Item>> CreateItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _context.Items.AddAsync(item);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(CreateItem), new { id = item.ItemId }, item);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"An error occurred while saving the item: {ex.Message}");
            }
        }
    }
}