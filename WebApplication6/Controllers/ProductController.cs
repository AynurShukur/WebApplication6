using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Data;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var a = await _context.ProductModels.ToListAsync();
            return View(a);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductModel prod)
        {
            if (ModelState.IsValid)
            {
                _context.ProductModels.Add(prod);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prod);
        }
        
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductModel product = _context.ProductModels.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                if (_context.ProductModels.Find(id) != null)
                {
                    _context.ProductModels.Remove(_context.ProductModels.Find(id));
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }

        }


    }
}

