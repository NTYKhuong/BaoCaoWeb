using BanDoNoiThat.Data;
using BanDoNoiThat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BanDoNoiThat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly ApplicationDbContext _context;
        private readonly Serilog.ILogger _logger;

        public CustomersController(ApplicationDbContext context, Serilog.ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        // GetAll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GetById
        [HttpGet("{customer_id}")]
        public async Task<ActionResult<Customers>> GetByIdCustomers(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // Create
        [HttpPost]
        public async Task<IActionResult> CreateCustomers([FromBody] Customers customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByIdCustomers), new { id = customer.customer_id }, customer);
        }

        // Update
        [HttpPut("{customer_id}")]
        public async Task<IActionResult> UpdateCustomers(int id, [FromBody] Customers updatedCustomer)
        {
            if (id != updatedCustomer.customer_id)
            {
                return BadRequest();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            // Cập nhật thông tin
            customer.customer_name = updatedCustomer.customer_name;
            customer.address = updatedCustomer.address;
            customer.phone_number = updatedCustomer.phone_number;

            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Delete
        [HttpDelete("{customer_id}")]
        public async Task<IActionResult> DeleteCustomers(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
