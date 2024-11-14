using Microsoft.AspNetCore.Mvc;

namespace BanDoNoiThat.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
