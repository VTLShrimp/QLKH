using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLKhoHang.Data;
using QLKhoHang.Models;

namespace QuanLyKhoHang.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create([FromBody] ProductModel productmodel)
        {
            if (productmodel == null)
                return BadRequest();

            var product = new ProductModel
            {
                Name = productmodel.Name,
                CategoryId = productmodel.CategoryId,
                Description = productmodel.Description,
                Quantity = productmodel.Quantity
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductModel updatedProduct)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();

            product.Name = updatedProduct.Name;
            product.Quantity = updatedProduct.Quantity;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }
    }
}