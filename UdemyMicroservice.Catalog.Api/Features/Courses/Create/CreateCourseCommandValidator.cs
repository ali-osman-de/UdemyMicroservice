namespace UdemyMicroservice.Catalog.Api.Features.Courses.Create;

public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Boş Olamaz").MaximumLength(100);
        RuleFor(x => x.Description).NotEmpty().WithMessage("Boş Olamaz").MaximumLength(1000).WithMessage("Max 1000 length");
        RuleFor(x => x.Price).NotEmpty().WithMessage("Boş Olamaz").GreaterThan(0).WithMessage("0 dan büyük olmalı!");
        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Boş Olamaz");
    }
}
