using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using System.Text.Json;
using UdemyMicroservice.Basket.Api.Const;
using UdemyMicroservice.Shared;
using UdemyMicroservice.Shared.Services;

namespace UdemyMicroservice.Basket.Api.Features.Basket.RemoveBasketItem;

public class RemoveBasketItemCommandHandler(IDistributedCache dCache, IIdentityService identityService) : IRequestHandler<RemoveBasketItemCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(RemoveBasketItemCommand request, CancellationToken cancellationToken)
    {
        var UserId = identityService.UserId;
        var cacheKey = string.Format(BasketConst.BasketCacheKey, UserId);

        var basketAsString = await dCache.GetStringAsync(cacheKey, cancellationToken);
        
        if (string.IsNullOrEmpty(basketAsString))
        {
            return ServiceResult.Error("Basket Issue", "Basket Not Found", HttpStatusCode.NotFound);
        }

        var currenBasket = JsonSerializer.Deserialize<Data.Basket>(basketAsString);
        var basketItemForRemove = currenBasket!.BasketItems.FirstOrDefault(bi => bi.Id == request.Id);

        if (basketItemForRemove is null)
        {
            return ServiceResult.Error("Basket Issue", "Basket Not Found", HttpStatusCode.NotFound);
        }
        currenBasket.BasketItems.Remove(basketItemForRemove);
        await dCache.SetStringAsync(cacheKey, JsonSerializer.Serialize(currenBasket), cancellationToken);
        return ServiceResult.SuccessAsNoContent();
    }
}
