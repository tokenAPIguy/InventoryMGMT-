using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Product>()
            .HasKey(p => p.Id);
        
        modelBuilder.Entity<Product>()
            .Property(p => p.Name)
            .IsRequired();
        
        modelBuilder.Entity<Product>()
            .Property(p => p.CategoryId)
            .IsRequired();
    }
}