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
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApiController : Controller
    {
        private readonly CRUDWITHEFIMGContext _context;

        public EmployeeApiController(CRUDWITHEFIMGContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeApi
        [HttpGet]
        public ActionResult<IEnumerable<Employeemaster>> GetEmployees()
        {
            return _context.Employeemasters.ToList();
        }

        // GET: api/EmployeeApi/5
        [HttpGet("{id}")]
        public ActionResult<Employeemaster> GetEmployee(int id)
        {
            var employee = _context.Employeemasters.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        // POST: api/EmployeeApi
        [HttpPost]
        public IActionResult PostEmployee([FromForm] Employeemaster emp, IFormFile file)
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
                return CreatedAtAction(nameof(GetEmployee), new { id = emp.Id }, emp);
            }
            return BadRequest(ModelState);
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

        // PUT: api/EmployeeApi/5
        [HttpPut("{id}")]
        public IActionResult PutEmployee(int id, [FromForm] Employeemaster emp, IFormFile file)
        {
            if (id != emp.Id)
            {
                return BadRequest();
            }

            var existingEmployee = _context.Employeemasters.Find(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            if (file != null && file.Length > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string _filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + filename;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", _filename);
                    emp.Empimg = "~/images/" + _filename;

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                else
                {
                    emp.Empimg = existingEmployee.Empimg; // Retain existing image path
                }

            existingEmployee.Empcode = emp.Empcode;
            existingEmployee.Empname = emp.Empname;
            existingEmployee.Designation = emp.Designation;
            existingEmployee.Salary = emp.Salary;

            _context.Entry(existingEmployee).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/EmployeeApi/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.Employeemasters.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employeemasters.Remove(employee);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
