using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using UdemyMicroservice.Basket.Api.Const;
using UdemyMicroservice.Basket.Api.Dtos;
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

        BasketDto currentBasket;
        var basket = new BasketItemDto(request.CourseId, request.CourseName, request.Price, request.ImageUri, null);

        if (string.IsNullOrEmpty(basketAsString))
        {
            currentBasket = new BasketDto(userId, [basket]);
            await CreateCacheAsync(cacheKey, currentBasket, cancellationToken);
            return ServiceResult.SuccessAsNoContent();
        }

        currentBasket = JsonSerializer.Deserialize<BasketDto>(basketAsString)!;
        
        var existingBasketItem = currentBasket.BasketItemsDto.FirstOrDefault(bi => bi.Id == basket.Id);
        if (existingBasketItem is not null) currentBasket.BasketItemsDto.Remove(existingBasketItem);
        currentBasket.BasketItemsDto.Add(basket);

        await CreateCacheAsync(cacheKey, currentBasket, cancellationToken);
        return ServiceResult.SuccessAsNoContent();
    }

    private async Task CreateCacheAsync(string cacheKey, BasketDto currentBasket, CancellationToken cancellationToken)
    {
        var basketAsString = JsonSerializer.Serialize(currentBasket);
        await dCache.SetStringAsync(cacheKey, basketAsString, cancellationToken);
    }
}
