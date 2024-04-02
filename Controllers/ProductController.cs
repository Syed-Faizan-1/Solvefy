using Microsoft.AspNetCore.Mvc;

namespace Product_Inventory.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
