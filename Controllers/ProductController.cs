﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product_Inventory;
using ProductInventory.Data;
using ProductInventory.Models;

namespace ProductInventory.Controllers
{
    [Authorize(Roles = Constants.Role_Admin)]
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
                TempData["success"] = "Product Created Successfully!";
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        public IActionResult Edit(int? productId)
        {
            if(productId == null || productId == 0)
            {
                return NotFound();
            }
            Product? p = _db.Products.FirstOrDefault(p => p.Id == productId);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);

        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Product Edited Successfully!";
                return RedirectToAction("Index", "Product");
            }
            return View();
        }
        public IActionResult Delete(int? productId)
        {
            if (productId == null || productId == 0)
            {
                return NotFound();
            }
            Product? p = _db.Products.FirstOrDefault(p => p.Id == productId);
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
