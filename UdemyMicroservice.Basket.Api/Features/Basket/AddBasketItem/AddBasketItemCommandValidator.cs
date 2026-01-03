using FluentValidation;

namespace UdemyMicroservice.Basket.Api.Features.Basket.AddBasketItem;

public class AddBasketItemCommandValidator : AbstractValidator<AddBasketItemCommand>
{
    public AddBasketItemCommandValidator()
    {
        RuleFor(x => x.CourseId).NotEmpty().WithMessage("Id cannot be empty.");
        RuleFor(x => x.CourseName).NotEmpty().WithMessage("Name cannot be empty.");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
    }
}
