using Microsoft.AspNetCore.Mvc;
using Product_Inventory.Data;

namespace Product_Inventory.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var productList = _db.Products.ToList();
            return View(productList);
        }
    }
}
