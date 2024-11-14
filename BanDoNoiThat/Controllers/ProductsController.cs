﻿using BanDoNoiThat.Data;
using BanDoNoiThat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BanDoNoiThat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GetAll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GetById
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetByIdProducts(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // Create
        [HttpPost]
        public async Task<IActionResult> CreateProducts([FromBody] Products product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByIdProducts), new { id = product.product_id }, product);
        }

        // Update
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducts(int id, [FromBody] Products updatedProduct)
        {
            if (id != updatedProduct.product_id)
            {
                return BadRequest();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            // Cập nhật thông tin
            product.product_name = updatedProduct.product_name;
            product.image_path = updatedProduct.image_path;
            product.inventory_quantity = updatedProduct.inventory_quantity;
            product.original_price = updatedProduct.original_price;
            product.unit_price = updatedProduct.unit_price;
            product.description = updatedProduct.description;
            product.create_time = updatedProduct.create_time;
            product.update_time = updatedProduct.update_time;
            product.category_id = updatedProduct.category_id;

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducts(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
