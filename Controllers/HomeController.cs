using Microsoft.AspNetCore.Mvc;
using ProductInventory.Data;
using ProductInventory.Models;
using System.Diagnostics;

namespace ProductInventory.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _db.Products;
            return View(productList);
        }
        public IActionResult Details(int id)
        {
            Product? product = _db.Products.FirstOrDefault(x => x.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
