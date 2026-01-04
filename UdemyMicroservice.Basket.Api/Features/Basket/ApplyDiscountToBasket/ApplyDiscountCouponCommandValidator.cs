using FluentValidation;

namespace UdemyMicroservice.Basket.Api.Features.Basket.ApplyDiscountToBasket;

public class ApplyDiscountCouponCommandValidator : AbstractValidator<ApplyDiscountCouponCommand>
{
    public ApplyDiscountCouponCommandValidator()
    {
        RuleFor(x => x.Coupon).NotEmpty().WithMessage("Coupon code must not be empty.")
            .MaximumLength(50).WithMessage("Coupon code must not exceed 50 characters.");
        RuleFor(x => x.Rate).GreaterThan(0).WithMessage("Discount rate must be greater than zero.");
    }
}
