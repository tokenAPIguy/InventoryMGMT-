using Microsoft.AspNetCore.Mvc.Rendering;

namespace Frontend.Models;

public class ProductViewModel {
    public List<Product>? Products { get; set; }
    public Product Product { get; set; }
    public List<SelectListItem> ProductCategories { get; set; } = [
        new SelectListItem { Value = "Home", Text = "Home" },
        new SelectListItem { Value = "Garden", Text = "Garden" },
        new SelectListItem { Value = "Electronics", Text = "Electronics" },
        new SelectListItem { Value = "Clothing", Text = "Clothing" },
        new SelectListItem { Value = "Health", Text = "Health" },
        new SelectListItem { Value = "Auto", Text = "Auto" },
        new SelectListItem { Value = "Sports", Text = "Sports" },
        new SelectListItem { Value = "Toys", Text = "Toys" },
        new SelectListItem { Value = "Misc", Text = "Misc" }
    ];
}
   
