namespace BlazorSample.FoodRecipes.UI.Features.Home;

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string Originality { get; set; }
    public int TimeInMinutes { get; set; }
    public string TimeInString => $"{TimeInMinutes / 60}h {TimeInMinutes % 60}m";
    public int Price { get; set; }
    public IEnumerable<Ingridient> Ingridients { get; set; } = Array.Empty<Ingridient>();

}

public class Ingridient
{
    public int Id { get; set; }
    public string Name { get; set; }
}