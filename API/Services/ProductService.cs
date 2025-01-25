using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class ProductService(ApplicationDbContext context) {
    private readonly Logging.Logger logger = Logging.Logger.Default;
    
    // GET
    public async Task<Product?> GetProductAsync(int id) {
        string path = $"GET api/products/{id}";
        Product? response = await context.Products.FindAsync(id);

        if (response == null) {
            logger.Warning($"HTTP 404 - {path}");
            return null;
        }
        
        logger.Information($"HTTP 200 - {path}");
        return response;
    }
    
    // GET All
    public async Task<List<Product>?> GetAllProductsAsync(string? categoryId) {
        string path = $"GET api/products/?{categoryId}";
        List<Product> response;

        if (categoryId != null) {
            response = await context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        } else {
            response = await context.Products.ToListAsync();
        }

        if (!response.Any()) {
            logger.Warning($"HTTP 404 - {path}");
            return null;
        }
        
        logger.Information($"HTTP 200 - {path}");
        return response;
    }

    // POST
    public async Task<Product> CreateProductAsync(Product product) {
        string path = $"POST api/products/";
        
        var resposne = await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
        return product;
        
        // try {
        //     context.Products.Add(product);        
        //     await context.SaveChangesAsync();
        //     return product;
        // }
        // catch (Exception e) {
        //     logger.Error($"HTTP 500 - {path} | {e.Message}");
        // }
    }
    
    // PUT 
    public async Task<Product?> UpdateProductAsync(Product product) {
        // Add nullcheck
        Product? existingProduct = await context.Products.FindAsync(product.Id);
        context.Entry(existingProduct).CurrentValues.SetValues(product);
        await context.SaveChangesAsync();
        return existingProduct;
    }
    
    // DELETE 
    public async Task<bool> DeleteProductAsync(int id) {
        Product? product = await context.Products.FindAsync(id);

        if (product == null) {
            logger.Warning($"HTTP 404 - Product {id} does not exist");
            return false;
        }
        
        context.Products.Remove(product);
        await context.SaveChangesAsync();
        return true;
    }
}