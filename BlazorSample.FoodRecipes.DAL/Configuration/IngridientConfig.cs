using Microsoft.EntityFrameworkCore;
using BlazorSample.FoodRecipes.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorSample.FoodRecipes.DAL.Configuration;

public class IngridientConfig : IEntityTypeConfiguration<Ingridient>
{
    public void Configure(EntityTypeBuilder<Ingridient> builder)
    {
        builder.Property(n => n.Name).IsRequired().HasMaxLength(100);
    }
}