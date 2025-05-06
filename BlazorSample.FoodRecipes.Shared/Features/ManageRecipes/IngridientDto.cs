using FluentValidation;

namespace BlazorSample.FoodRecipes.Shared.Features.ManageRecipes;

public class IngridientDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}


public class IngridientDtoValidator : AbstractValidator<IngridientDto>
{
    public IngridientDtoValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Please Enter a name!");
    }
}