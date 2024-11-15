using BanDoNoiThat.Data;
using BanDoNoiThat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BanDoNoiThat.Controllers
{
    public class OrdersController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GetAll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetAllOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        // GetById
        [HttpGet("{order_id}")]
        public async Task<ActionResult<Orders>> GetByIdOrders(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // Create
        [HttpPost]
        public async Task<IActionResult> CreateOrders([FromBody] Orders order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByIdOrders), new { id = order.order_id }, order);
        }

        // Update
        [HttpPut("{order_id}")]
        public async Task<IActionResult> UpdateOrders(int id, [FromBody] Orders updatedOrder)
        {
            if (id != updatedOrder.order_id)
            {
                return BadRequest();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            // Cập nhật thông tin
            order.order_date = updatedOrder.order_date;
            order.total_price = updatedOrder.total_price;
            order.customer_id = updatedOrder.customer_id;

            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Delete
        [HttpDelete("{order_id}")]
        public async Task<IActionResult> DeleteOrders(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
