using Microsoft.AspNetCore.Mvc;
using ElectronicsStore.API.Models;
using ElectronicsStore.API.Data;
using Microsoft.EntityFrameworkCore;

namespace ElectronicsStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
            Console.WriteLine("✅ ProductsController initialized");
        }

        // GET: api/products or api/products?category=Laptops= fetches all products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts([FromQuery] string? category)
        {
            Console.WriteLine("🔍 GET /api/products called");

            if (!string.IsNullOrEmpty(category))
            {
                Console.WriteLine($"📂 Filtering products by category: {category}");
                return await _context.Products
                                     .Where(p => p.Category == category)
                                     .ToListAsync();
            }

            return await _context.Products.ToListAsync();
        }

        // POST: api/product=adds a new products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            Console.WriteLine("📝 POST /api/products called");

            if (string.IsNullOrWhiteSpace(product.Category))
            {
                Console.WriteLine("❌ Product category is missing");
                return BadRequest("Category is required.");
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
        }

        // PUT: api/products/{id}=updates a product
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                Console.WriteLine("❌ Mismatched product ID");
                return BadRequest();
            }

            Console.WriteLine($"✏️ PUT /api/products/{id} called");
            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Products.Any(p => p.Id == id))
                {
                    Console.WriteLine("❌ Product not found during update");
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/products/{id}=deletes a product
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            Console.WriteLine($"🗑️ DELETE /api/products/{id} called");
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                Console.WriteLine("❌ Product not found for deletion");
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
