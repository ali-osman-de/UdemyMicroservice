using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using System.Text.Json;
using UdemyMicroservice.Basket.Api.Const;
using UdemyMicroservice.Shared;
using UdemyMicroservice.Shared.Services;

namespace UdemyMicroservice.Basket.Api.Features.Basket.RollBackDiscountToBasket;

public class RollBackDiscountCouponCommandHandler(IDistributedCache dCache, IIdentityService identityService) : IRequestHandler<RollBackDiscountCouponCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(RollBackDiscountCouponCommand request, CancellationToken cancellationToken)
    {
        var cacheKey = string.Format(BasketConst.BasketCacheKey, identityService.UserId);
        var basketAsString = await dCache.GetStringAsync(cacheKey, cancellationToken);

        if (string.IsNullOrEmpty(basketAsString)) return ServiceResult.Error("Basket Issue", "Basket Not Found", HttpStatusCode.NotFound);

        var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsString);

        basket!.ClearDiscount();

        await dCache.SetStringAsync(cacheKey, JsonSerializer.Serialize(basket), cancellationToken);

        return ServiceResult.SuccessAsNoContent();
    }
}
