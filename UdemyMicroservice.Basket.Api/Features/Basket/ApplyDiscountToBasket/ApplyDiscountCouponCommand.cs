using UdemyMicroservice.Shared.Interfaces;

namespace UdemyMicroservice.Basket.Api.Features.Basket.ApplyDiscountToBasket;

public record ApplyDiscountCouponCommand(string Coupon, float Rate) : IServiceResultWrapper.IRequestByServiceResult;