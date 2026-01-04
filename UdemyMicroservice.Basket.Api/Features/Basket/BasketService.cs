using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using UdemyMicroservice.Basket.Api.Const;
using UdemyMicroservice.Shared.Services;

namespace UdemyMicroservice.Basket.Api.Features.Basket;

public class BasketService(IDistributedCache dCache, IIdentityService identityService)
{
    public string GetCacheKey() => string.Format(BasketConst.BasketCacheKey, identityService.UserId);
    public Task<string?> GetBasketFromCache(CancellationToken cancellationToken)
    {
        return dCache.GetStringAsync(GetCacheKey(), cancellationToken);
    }
    public Task CreateCache(Data.Basket currentBasket, CancellationToken cancellationToken)
    {
        var basketAsString = JsonSerializer.Serialize(currentBasket);
        return dCache.SetStringAsync(GetCacheKey(), basketAsString, cancellationToken);
    }
}
