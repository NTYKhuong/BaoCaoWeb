using BanDoNoiThat.Models;
using Microsoft.AspNetCore.Mvc;

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
        //private static List<Products> products = new List<Products>
        //{
        //    new Products { Id = 1, Name = "Coffee", Category = "Beverage", Price = 3.5m },
        //    new Products { Id = 2, Name = "Tea", Category = "Beverage", Price = 2.5m },
        //    new Products { Id = 3, Name = "Juice", Category = "Beverage", Price = 4.0m }
        //};

        //[HttpGet]
        //public ActionResult<IEnumerable<Products>> GetProducts()
        //{
        //    return Ok(products);
        //}

        //// Route: POST /products
        //[HttpPost]
        //public ActionResult CreateProduct([FromBody] Products newProduct)
        //{
        //    newProduct.Id = products.Count + 1;
        //    products.Add(newProduct);
        //    return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);
        //}

        //[HttpGet("{id}")]
        //public ActionResult<Products> GetProductById(int id)
        //{
        //    var product = products.FirstOrDefault(p => p.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound($"Product with id {id} not found.");
        //    }
        //    return Ok(product);
        //}
    }
}
