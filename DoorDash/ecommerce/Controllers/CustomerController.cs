using Microsoft.AspNetCore.Mvc;
using DoorDash.Data;
using DoorDash.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DoorDash.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Customer/Stores
        [HttpGet("Stores")]
        public async Task<ActionResult<IEnumerable<Store>>> GetStores()
        {
            return await _context.Stores.ToListAsync();
        }

        // GET: api/Customer/Stores/{storeId}/Products
        [HttpGet("Stores/{storeId}/Products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByStore(int storeId)
        {
            var store = await _context.Stores.FindAsync(storeId);
            if (store == null)
            {
                return NotFound();
            }
            return await _context.Products.Where(p => p.StoreId == storeId).ToListAsync();
        }

        // POST: api/Customer/Orders
        [HttpPost("Orders")]
        public async Task<ActionResult<Order>> PlaceOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        // GET: api/Customer/Orders/{id}
        [HttpGet("Orders/{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // DELETE: api/Orders/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            // Find the order by ID
            var order = await _context.Orders.FindAsync(id);

            // If the order is not found, return NotFound status
            if (order == null)
            {
                return NotFound();
            }

            // Remove the order from the context
            _context.Orders.Remove(order);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return NoContent status to indicate successful deletion
            return NoContent();
        }
    }
}
