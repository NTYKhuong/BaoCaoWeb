using BanDoNoiThat.Data;
using BanDoNoiThat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BanDoNoiThat.Controllers
{
    public class CategoryController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly ApplicationDbContext _context;
        private readonly Serilog.ILogger _logger;

        public CategoryController(ApplicationDbContext context, Serilog.ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        // GetAll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            return await _context.Category.ToListAsync();
        }

        // GetById
        [HttpGet("{category_id}")]
        public async Task<ActionResult<Category>> GetByIdCategories(int id)
        {
            var category = await _context.Category.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // Create
        [HttpPost]
        public async Task<IActionResult> CreateCategories([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            _context.Category.Add(category);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByIdCategories), new { id = category.category_id }, category);
        }

        // Update
        [HttpPut("{category_id}")]
        public async Task<IActionResult> UpdateCategories(int id, [FromBody] Category updatedCategory)
        {
            if (id != updatedCategory.category_id)
            {
                return BadRequest();
            }

            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            // Cập nhật thông tin
            category.category_name = updatedCategory.category_name;

            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Delete
        [HttpDelete("{category_id}")]
        public async Task<IActionResult> DeleteCategories(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
