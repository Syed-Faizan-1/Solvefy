using Microsoft.AspNetCore.Mvc;
using Product_Inventory.Data;
using Product_Inventory.Models;

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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if(ModelState.IsValid)
            {
                _db.Products.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            return View();
        }
    }
}
