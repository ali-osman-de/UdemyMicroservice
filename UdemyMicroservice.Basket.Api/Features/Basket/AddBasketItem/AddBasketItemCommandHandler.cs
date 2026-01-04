using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using UdemyMicroservice.Basket.Api.Const;
using UdemyMicroservice.Basket.Api.Data;
using UdemyMicroservice.Shared;
using UdemyMicroservice.Shared.Services;

namespace UdemyMicroservice.Basket.Api.Features.Basket.AddBasketItem;

public class AddBasketItemCommandHandler(IDistributedCache dCache, IIdentityService identityService) : IRequestHandler<AddBasketItemCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
    {
        Guid userId = identityService.UserId;
        var cacheKey = string.Format(BasketConst.BasketCacheKey, userId);

        var basketAsString = await dCache.GetStringAsync(cacheKey, cancellationToken);

        Data.Basket currentBasket;
        var basket = new BasketItem(request.CourseId, request.CourseName, request.Price, request.ImageUri, null);

        if (string.IsNullOrEmpty(basketAsString))
        {
            currentBasket = new Data.Basket(userId, [basket]);
            await CreateCacheAsync(cacheKey, currentBasket, cancellationToken);
            return ServiceResult.SuccessAsNoContent();
        }

        currentBasket = JsonSerializer.Deserialize<Data.Basket>(basketAsString)!;
        
        var existingBasketItem = currentBasket.BasketItems.FirstOrDefault(bi => bi.Id == basket.Id);
        if (existingBasketItem is not null) currentBasket.BasketItems.Remove(existingBasketItem);
        currentBasket.BasketItems.Add(basket);

        currentBasket.ApplyAvailableDiscount();

        await CreateCacheAsync(cacheKey, currentBasket, cancellationToken);
        return ServiceResult.SuccessAsNoContent();
    }

    private async Task CreateCacheAsync(string cacheKey, Data.Basket currentBasket, CancellationToken cancellationToken)
    {
        var basketAsString = JsonSerializer.Serialize(currentBasket);
        await dCache.SetStringAsync(cacheKey, basketAsString, cancellationToken);
    }
}
