using FluentValidation;

namespace UdemyMicroservice.Catalog.Api.Features.Categories.Create;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Boş Olamaz!")
                            .MaximumLength(25).WithMessage("25 Karakterden fazla olamaz");
    }
}
