using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class RegionsController : ControllerBase
        {
            private readonly ApplicationDbContext _context;

            public RegionsController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: api/regions
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Region>>> GetRegions()
            {
                var regions = await _context.Regions.ToListAsync();

            return Ok(regions);
                   
            }

            // GET: api/regions/1
            [HttpGet("{id}")]
            public async Task<ActionResult<Region>> GetProduct(int id)
            {
                var region = await _context.Regions.FindAsync(id);

                if (region == null)
                {
                    return NotFound();
                }

                return Ok(region);
            }

            // POST: api/products
            /*[HttpPost]
            public async Task<ActionResult<Product>> CreateProduct(Product product)
            {
                _context.Products.Add(product);

                await _context.SaveChangesAsync();

                return CreatedAtAction(
                    nameof(GetProduct),
                    new { id = product.Id },
                    product
                );
            }

            // PUT: api/products/1
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateProduct(
                int id,
                Product product)
            {
                if (id != product.Id)
                {
                    return BadRequest();
                }

                var existingProduct = await _context.Products.FindAsync(id);

                if (existingProduct == null)
                {
                    return NotFound();
                }

                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;

                await _context.SaveChangesAsync();

                return NoContent();
            }

            // DELETE: api/products/1
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteProduct(int id)
            {
                var product = await _context.Products.FindAsync(id);

                if (product == null)
                {
                    return NotFound();
                }

                _context.Products.Remove(product);

                await _context.SaveChangesAsync();

                return NoContent();
            }*/
        }
    }

