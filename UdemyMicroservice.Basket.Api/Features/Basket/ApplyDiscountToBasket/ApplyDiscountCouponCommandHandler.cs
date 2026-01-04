using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using System.Text.Json;
using UdemyMicroservice.Basket.Api.Const;
using UdemyMicroservice.Basket.Api.Dtos;
using UdemyMicroservice.Shared;
using UdemyMicroservice.Shared.Services;

namespace UdemyMicroservice.Basket.Api.Features.Basket.ApplyDiscountToBasket;

public class ApplyDiscountCouponCommandHandler(BasketService basketService) : IRequestHandler<ApplyDiscountCouponCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(ApplyDiscountCouponCommand request, CancellationToken cancellationToken)
    {
        var basketAsString = await basketService.GetBasketFromCache(cancellationToken);

        if (string.IsNullOrEmpty(basketAsString)) return ServiceResult.Error("Basket Issue", "Basket Not Found", HttpStatusCode.NotFound);

        var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsString);

        if (!basket!.BasketItems.Any()) return ServiceResult.Error("Basket Issue", "Basket items Not Found", HttpStatusCode.NotFound);

        basket.ApplyDiscount(request.Coupon, request.Rate);

        await basketService.CreateCache(basket, cancellationToken);
        return ServiceResult.SuccessAsNoContent();

    }
}
