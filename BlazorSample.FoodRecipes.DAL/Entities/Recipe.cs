namespace BlazorSample.FoodRecipes.DAL.Entities;

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string Originality { get; set; }
    public int TimeInMinutes { get; set; }
    public int Price { get; set; }
    public List<Ingridient> Ingridients { get; set; } = new List<Ingridient>();

}
