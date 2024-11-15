using BanDoNoiThat.Data;
using BanDoNoiThat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BanDoNoiThat.Controllers
{
    public class OrderDetailsController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly ApplicationDbContext _context;

        public OrderDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GetAll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetAllOrderDetails()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        // GetById
        [HttpGet("{detail_id}")]
        public async Task<ActionResult<OrderDetails>> GetByIdOrderDetails(int id)
        {
            var detail = await _context.OrderDetails.FindAsync(id);

            if (detail == null)
            {
                return NotFound();
            }

            return detail;
        }

        // Create
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetails([FromBody] OrderDetails detail)
        {
            if (detail == null)
            {
                return BadRequest();
            }

            _context.OrderDetails.Add(detail);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByIdOrderDetails), new { id = detail.detail_id }, detail);
        }

        // Update
        [HttpPut("{detail_id}")]
        public async Task<IActionResult> UpdateOrderDetails(int id, [FromBody] OrderDetails updatedDetail)
        {
            if (id != updatedDetail.detail_id)
            {
                return BadRequest();
            }

            var detail = await _context.OrderDetails.FindAsync(id);
            if (detail == null)
            {
                return NotFound();
            }

            // Cập nhật thông tin
            detail.total_quantity = updatedDetail.total_quantity;
            detail.sale_price = updatedDetail.sale_price;
            detail.order_id = updatedDetail.order_id;
            detail.product_id = updatedDetail.product_id;

            _context.Entry(detail).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Delete
        [HttpDelete("{detail_id}")]
        public async Task<IActionResult> DeleteOrderDetails(int id)
        {
            var detail = await _context.OrderDetails.FindAsync(id);
            if (detail == null)
            {
                return NotFound();
            }

            _context.OrderDetails.Remove(detail);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
