using SixLabors.ImageSharp;
using Microsoft.AspNetCore.Mvc;
using BlazorSample.FoodRecipes.DAL;
using Microsoft.EntityFrameworkCore;
using BlazorSample.FoodRecipes.DAL.Entities;
using BlazorSample.FoodRecipes.Shared.Features.ManageRecipes;

namespace BlazorSample.FoodRecipes.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecipeController : ControllerBase
{
    private readonly FoodRecipeContext _context;
    private readonly ILogger<RecipeController> _logger;

    public RecipeController(FoodRecipeContext context, ILogger<RecipeController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var ingridients = await _context.Recipes.Include(c => c.Ingridients).ToListAsync();
        return Ok(ingridients);
    }

    [HttpPost]
    public async Task<IActionResult> Add(RecipeDto model)
    {
        try
        {
            Recipe recipe = new Recipe
            {
                Name = model.Name,
                Price = model.Price,
                ImageUrl = "Not set yet!",
                Description = model.Description,
                Originality = model.Originality,
                TimeInMinutes = model.TimeInMinutes,
                Ingridients = model.Ingridients.Select(c => new Ingridient
                {
                    Name = c.Name,
                }).ToList(),
            };
            await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
            return Ok(recipe.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Baddness");
            return BadRequest(-1);
        }
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> AddImage(int id)
    {
        var file = Request.Form.Files[0];

        if (file.Length == 0)
        {
            return BadRequest();
        }

        Recipe recipe = _context.Recipes.FirstOrDefault(c => c.Id == id);
        if (recipe == null)
        {
            return BadRequest();
        }

        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
        var fileExtension = Path.GetExtension(file.FileName).ToLower();
        if (!allowedExtensions.Contains(fileExtension))
        {
            return BadRequest();
        }

        var fileName = $"{Guid.NewGuid()}{fileExtension}";

        var saveLocation = Path.Combine(Directory.GetCurrentDirectory(), "Images", fileName);

        using var image = Image.Load(file.OpenReadStream());
        await image.SaveAsync(saveLocation);//
        recipe.ImageUrl = fileName;
        await _context.SaveChangesAsync();
        return Ok();
    }
}
