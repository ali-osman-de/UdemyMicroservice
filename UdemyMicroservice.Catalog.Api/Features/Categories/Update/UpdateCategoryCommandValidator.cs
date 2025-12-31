namespace UdemyMicroservice.Catalog.Api.Features.Categories.Update;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryRequest>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Name).NotNull()
                            .NotEmpty()
                            .WithMessage("Boş Olamaz")
                            .MinimumLength(5)
                            .WithMessage("5 karakterden fazla olmalı")
                            .MaximumLength(25)
                            .WithMessage("25 Karakterden fazla olamaz");
    }
}
