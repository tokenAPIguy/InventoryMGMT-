using API.Data;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(ProductService productService) : ControllerBase {
    [HttpGet("{id}")]
    public async Task<Product?> Get(int id) {
        return await productService.GetProductAsync(id);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAll(string? categoryId = null) {
        return await productService.GetAllProductsAsync(categoryId);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct(Product product) {
        await productService.CreateProductAsync(product);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }
    
    [HttpPut("{product.id}")]
    public async Task<IActionResult?> UpdateProduct(Product product) {
        await productService.UpdateProductAsync(product);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id) {
        await productService.DeleteProductAsync(id);
        return NoContent();
    }
}