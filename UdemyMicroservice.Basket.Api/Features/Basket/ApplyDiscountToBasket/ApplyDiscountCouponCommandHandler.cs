using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using System.Text.Json;
using UdemyMicroservice.Basket.Api.Const;
using UdemyMicroservice.Basket.Api.Dtos;
using UdemyMicroservice.Shared;
using UdemyMicroservice.Shared.Services;

namespace UdemyMicroservice.Basket.Api.Features.Basket.ApplyDiscountToBasket;

public class ApplyDiscountCouponCommandHandler(IDistributedCache dCache, IIdentityService identityService) : IRequestHandler<ApplyDiscountCouponCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(ApplyDiscountCouponCommand request, CancellationToken cancellationToken)
    {
        var cacheKey = string.Format(BasketConst.BasketCacheKey, identityService.UserId);
        var basketAsString = await dCache.GetStringAsync(cacheKey, cancellationToken);

        if (string.IsNullOrEmpty(basketAsString))
        {
            return ServiceResult.Error("Basket Issue", "Basket Not Found", HttpStatusCode.NotFound);
        }

        var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsString);

        basket.ApplyDiscount(request.Coupon, request.Rate);

        await dCache.SetStringAsync(cacheKey, JsonSerializer.Serialize(basket), cancellationToken);
        return ServiceResult.SuccessAsNoContent();

    }
}
