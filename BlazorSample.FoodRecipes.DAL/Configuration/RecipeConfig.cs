using Microsoft.EntityFrameworkCore;
using BlazorSample.FoodRecipes.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorSample.FoodRecipes.DAL.Configuration;

public class RecipeConfig : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.Property(n => n.Description).IsRequired();
        builder.Property(n => n.Name).IsRequired().HasMaxLength(100);
        builder.Property(n => n.ImageUrl).IsRequired().HasMaxLength(200);
        builder.Property(n => n.Originality).IsRequired().HasMaxLength(150);
    }
}
