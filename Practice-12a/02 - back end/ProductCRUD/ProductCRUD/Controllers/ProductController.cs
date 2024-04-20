using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCRUD.Data.Static;
using ProductCRUD.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCRUD.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProductController : Controller
    {
        private readonly ProductCRUDContext _context;

        public ProductController(ProductCRUDContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        // GET: Product
        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }

        //GET: Admin
        public IActionResult Admin()
        {
            return View(_context.Products.ToList());
        }

        [AllowAnonymous]
        // GET: Product/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormFile file, Product emp)
        {
            if (file == null || emp == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                string filename = Path.GetFileName(file.FileName);
                string _filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + filename;
                string extension = Path.GetExtension(file.FileName);
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                string filePath = Path.Combine(uploadsFolder, _filename);
                emp.Image = "~/images/" + _filename;
                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                {
                    if (file != null && file.Length > 0)
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }
                }

                _context.Products.Add(emp);
                _context.SaveChanges();
                return RedirectToAction("Admin");
            }

            return View(emp);
        }

        // GET: Product/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormFile file, Product emp)
        {
            if (id != emp.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var existingProduct = _context.Products.Find(id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                if (file != null && file.Length > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string _filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + filename;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", _filename);
                    emp.Image = "~/images/" + _filename;

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                else
                {
                    emp.Image = existingProduct.Image; // Retain existing image path
                }

                existingProduct.Name = emp.Name;
                existingProduct.Description = emp.Description;
                existingProduct.Cost = emp.Cost;

                _context.Entry(existingProduct).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Admin");
            }

            return View(emp);
        }

        // GET: Product/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Admin");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
