using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservingAPI.Models;
using RestaurantReservingAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace RestaurantReservingAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly EmployeeContext _context;

		public EmployeeController(EmployeeContext context)
		{
			_context = context;
		}

        // GET: api/Employee
        [HttpGet]
        public JsonResult GetEmployees()
        {
            var employees = _context.Employees.ToList();
            return new JsonResult(employees);
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public JsonResult GetEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(employee));
        }

        // POST: api/Employee
        [HttpPost]
        public JsonResult PostEmployee([FromForm] Employee emp, IFormFile file)
        {
            if (file == null || emp == null)
            {
                return new JsonResult(BadRequest());
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

                _context.Employees.Add(emp);
                _context.SaveChanges();
                return new JsonResult(Ok(emp));
            }
            return new JsonResult(BadRequest(ModelState));
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public JsonResult DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

    }
}
