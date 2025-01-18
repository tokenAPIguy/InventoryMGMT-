using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class ProductService(ApplicationDbContext context) {
    // GET
    public async Task<Product?> GetProductAsync(int id) {
        // Add nullcheck
        return await context.Products.FindAsync(id);
    }
    
    // GET All
    public async Task<List<Product>> GetAllProductsAsync(string? categoryId) {
        if (categoryId != null) {
            return await context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }
        return await context.Products.ToListAsync();
    }

    // POST
    public async Task<Product> CreateProductAsync(Product product) {
        context.Products.Add(product);        
        await context.SaveChangesAsync();
        return product;
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
            return false;
        }
        
        context.Products.Remove(product);
        await context.SaveChangesAsync();
        return true;
    }
}