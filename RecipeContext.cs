using System;
using Microsoft.EntityFrameworkCore;
using Recipes.Models;


namespace Recipes.Data
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().HasKey(r => r.Id);
            modelBuilder.Entity<Recipe>().Property(r => r.Id).IsRequired();
            modelBuilder.Entity<Recipe>().Property(r => r.Title).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Recipe>().Property(r => r.Category).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Recipe>().Property(r => r.CreatedDate).IsRequired();
            modelBuilder.Entity<Recipe>().Property(r => r.Complexity).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Recipe>().Property(r => r.PreparationTime).IsRequired();

            modelBuilder.Entity<Recipe>().HasData(
                new Recipe { Id = 1, Title = "Banitsa", Category = "Pastry", CreatedDate = DateTime.UtcNow, Complexity = "Intermediate", PreparationTime = 60 },
                new Recipe { Id = 2, Title = "Shopska Salad", Category = "Salads", CreatedDate = DateTime.UtcNow, Complexity = "Easy", PreparationTime = 20 },
                new Recipe { Id = 3, Title = "Kavarma", Category = "Meat", CreatedDate = DateTime.UtcNow, Complexity = "Advanced", PreparationTime = 90 },
                new Recipe { Id = 4, Title = "Tarator", Category = "Soup", CreatedDate = DateTime.UtcNow, Complexity = "Easy", PreparationTime = 30 }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}