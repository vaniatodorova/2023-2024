using Microsoft.AspNetCore.Mvc;
using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ApiContext _context;

        public ProductController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public JsonResult GetProducts()
        {
            var products = _context.Products.ToList();
            return new JsonResult(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public JsonResult GetProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(product));
        }

        // POST: api/Product
        [HttpPost]
        public JsonResult PostProduct([FromForm] Product emp, IFormFile file)
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
                return new JsonResult(Ok(emp));
            }
            return new JsonResult(BadRequest(ModelState));
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public JsonResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
    }
}
