using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Product_Inventory;
using ProductInventory.Data;
using ProductInventory.Models;

namespace ProductInventory.Controllers
{
    [Authorize(Roles = Constants.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _environment;
        public ProductController(ApplicationDbContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }
        public IActionResult Index()
        {
            var productList = _db.Products.ToList();
            return View(productList);
        }
        public IActionResult Upsert(int? id)
        {
            if(id == null)
            {
                return View();
            }
            Product? p = _db.Products.FirstOrDefault(p => p.Id == id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }
        [HttpPost]
        public IActionResult Upsert(Product obj, IFormFile? file)
        {
            foreach (var modelStateEntry in ModelState.Values)
            {
                foreach (var error in modelStateEntry.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            if (ModelState.IsValid)
            {
                string wwwRootPath = _environment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"Images\Product");
                    if(obj.ImageUrl != null)
                    {
                        //delete the old image
                        var oldImagePath = Path.Combine(wwwRootPath, obj.ImageUrl.TrimStart('\\'));
                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using(var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.ImageUrl = @"\Images\Product\" + fileName;
                }
                if(obj.Id == 0)
                {
                    _db.Products.Add(obj);
                }
                else
                {
                    _db.Products.Update(obj);
                }
                _db.SaveChanges();
                TempData["success"] = "Product Created Successfully!";
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? p = _db.Products.FirstOrDefault(p => p.Id == id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? p = _db.Products.Find(id);
            if(p == null)
            {
                return NotFound();
            }
            _db.Products.Remove(p);
            _db.SaveChanges();
            TempData["success"] = "Product Deleted Successfully!";
            return RedirectToAction("Index", "Product");
        }
    }
}
