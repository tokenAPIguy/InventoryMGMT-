using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Frontend.Models;
using Frontend.Services;

namespace Frontend.Controllers;

public class HomeController(ApiService service) : Controller {
    public async Task<IActionResult> Index(ProductViewModel viewModel) {
        viewModel.Products = await service.GetProductsAsync();
        return View(viewModel);
    }
}