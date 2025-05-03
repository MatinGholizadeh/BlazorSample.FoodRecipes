namespace BlazorSample.FoodRecipes.Shared.Features.ManageRecipes;

public class RecipeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Originality { get; set; }
    public int TimeInMinutes { get; set; }
    public int Price { get; set; }
    public List<IngridientDto> Ingridients { get; set; } = new List<IngridientDto>();
}
