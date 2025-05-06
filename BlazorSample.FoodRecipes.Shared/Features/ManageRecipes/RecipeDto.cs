using FluentValidation;

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

public class RecipeDtoValidator : AbstractValidator<RecipeDto>
{
    public RecipeDtoValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Please Enter a name!");
        RuleFor(c => c.Price).GreaterThan(0).WithMessage("Please Enter the Price!");
        RuleFor(c => c.Description).NotEmpty().WithMessage("Please Enter a Description!");
        RuleFor(c => c.Originality).NotEmpty().WithMessage("Please Enter a Originality!");
        RuleFor(c => c.Ingridients).NotEmpty().WithMessage("Please Enter a Ingridients!");
        RuleFor(c => c.TimeInMinutes).GreaterThan(0).WithMessage("Please Enter a Time In Minutes!");
        RuleForEach(c => c.Ingridients).SetValidator(new IngridientDtoValidator());
    }
}

