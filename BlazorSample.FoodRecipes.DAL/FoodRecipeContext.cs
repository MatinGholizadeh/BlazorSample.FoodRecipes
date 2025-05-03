using Microsoft.EntityFrameworkCore;
using BlazorSample.FoodRecipes.DAL.Entities;
using BlazorSample.FoodRecipes.DAL.Configuration;

namespace BlazorSample.FoodRecipes.DAL;

public class FoodRecipeContext : DbContext
{
    public FoodRecipeContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingridient> Ingridients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new RecipeConfig());
        modelBuilder.ApplyConfiguration(new IngridientConfig());
    }
}
