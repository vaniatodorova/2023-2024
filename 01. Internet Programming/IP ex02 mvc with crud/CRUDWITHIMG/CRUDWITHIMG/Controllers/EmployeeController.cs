using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDWITHIMG.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using CRUDWITHIMG.Data.Static;

namespace CRUDWITHIMG.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class EmployeeController : Controller
    {
        private readonly CRUDWITHEFIMGContext _context;

        public EmployeeController(CRUDWITHEFIMGContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        // GET: Employee
        public IActionResult Index()
        {
            return View(_context.Employeemasters.ToList());
        }

        [AllowAnonymous]
        // GET: Employee/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var employee = _context.Employeemasters.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormFile file, Employeemaster emp)
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
                emp.Empimg = "~/images/" + _filename;
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

                _context.Employeemasters.Add(emp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emp);
        }

        // GET: Employee/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var employee = _context.Employeemasters.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormFile file, Employeemaster emp)
        {
            if (id != emp.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var existingEmployee = _context.Employeemasters.Find(id);
                if (existingEmployee == null)
                {
                    return NotFound();
                }

                if (file != null && file.Length > 0)
                {
                    // Generate a unique filename to avoid conflicts
                    string uniqueFileName = $"{Guid.NewGuid().ToString()}_{Path.GetFileName(file.FileName)}";
                    string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", uniqueFileName);

                    using (var stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    // Update the employee's image path
                    existingEmployee.Empimg = $"/images/{uniqueFileName}";
                }

                // Update other properties
                existingEmployee.Empcode = emp.Empcode;
                existingEmployee.Empname = emp.Empname;
                existingEmployee.Designation = emp.Designation;
                existingEmployee.Salary = emp.Salary;

                _context.Entry(existingEmployee).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            // If ModelState is not valid, return the view with the existing employee object
            return View(emp);
        }

        // GET: Employee/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var employee = _context.Employeemasters.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _context.Employeemasters.Find(id);
            _context.Employeemasters.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
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
