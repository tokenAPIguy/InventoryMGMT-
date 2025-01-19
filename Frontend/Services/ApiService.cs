using Frontend.Models;

namespace Frontend.Services;

public class ApiService(HttpClient client) {
    public async Task<List<Product>> GetProductsAsync() {
        return await client.GetFromJsonAsync<List<Product>>("api/products");
    }
}