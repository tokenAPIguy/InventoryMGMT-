using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Frontend.Models;
using Frontend.Services;

namespace Frontend.Controllers;

public class HomeController(ApiService service) : Controller {
    [HttpGet("products/")]
    public async Task<IActionResult> Index(ProductViewModel viewModel) {
        viewModel.Products = await service.GetProductsAsync();
        return View(viewModel);
    }

    [HttpGet("products/{id}")]
    public async Task<IActionResult> Edit(int id) {
        ProductViewModel viewModel = new();
        viewModel.Product = await service.GetProductByIdAsync(id);
        return View(viewModel);
    }
    
    [HttpPost("products/{id}")]
    public async Task<IActionResult> Edit(ProductViewModel viewModel) {
        await service.UpdateProductAsync(viewModel.Product);
        return RedirectToAction("Index");
    }
}