using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Product {
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Required]
    public string CategoryId { get; set; }
    
    [MaxLength(500)]
    public string Description { get; set; }

    public bool InStock { get; set; } = true;

    public int Quantity { get; set; }
    
    public Product() { }
    
    public Product(string name, string categoryId) {
        Name = name;
        CategoryId = categoryId;
    }
}