using Frontend.Models;

namespace Frontend.Services;

public class ApiService(HttpClient client) {
    public async Task<List<Product>> GetProductsAsync() {
        return await client.GetFromJsonAsync<List<Product>>("api/products");
    }

    public async Task<Product> GetProductByIdAsync(int id) {
        return await client.GetFromJsonAsync<Product>($"api/products/{id}");
    }

    public async Task<HttpResponseMessage> UpdateProductAsync(Product product) {
        return await client.PutAsJsonAsync<Product>($"api/products/{product.Id}", product);
    }

    public async Task<HttpResponseMessage> CreateProductAsync(Product product) {
        return await client.PostAsJsonAsync<Product>($"api/products", product);
    }
}