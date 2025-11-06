
using Microsoft.AspNetCore.Mvc;
using ProductManagement;
using ProductManagementApi.Models;
using ProductManagementApi.Services.Interfaces;

namespace ProductManagementApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

       [HttpPost]
public async Task<IActionResult> Create([FromBody] ProductCreateDto dto)
{
    if (!ModelState.IsValid) return BadRequest(ModelState);

    var product = new Product
    {
        Name = dto.Name,
        Price = dto.Price,
        Stock = dto.Stock,
        Description = dto.Description
    };

    var created = await _service.CreateProductAsync(product);
    var response = new ProductDto
    {
        Id = created.Id,
        Name = created.Name,
        Price = created.Price,
        Stock = created.Stock,
        Description = created.Description
    };

    return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
}


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != product.Id) return BadRequest("ID mismatch");

            var updated = await _service.UpdateProductAsync(product);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteProductAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
