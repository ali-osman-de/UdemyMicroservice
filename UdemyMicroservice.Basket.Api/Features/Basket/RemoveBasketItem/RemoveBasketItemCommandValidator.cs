using FluentValidation;

namespace UdemyMicroservice.Basket.Api.Features.Basket.RemoveBasketItem;

public class RemoveBasketItemCommandValidator : AbstractValidator<RemoveBasketItemCommand>
{
    public RemoveBasketItemCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("CourseId cannot be empty.");
    }
}
