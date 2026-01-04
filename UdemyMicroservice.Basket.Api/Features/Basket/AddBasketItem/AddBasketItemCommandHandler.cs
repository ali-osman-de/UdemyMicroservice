using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using UdemyMicroservice.Basket.Api.Const;
using UdemyMicroservice.Basket.Api.Data;
using UdemyMicroservice.Shared;
using UdemyMicroservice.Shared.Services;

namespace UdemyMicroservice.Basket.Api.Features.Basket.AddBasketItem;

public class AddBasketItemCommandHandler(IIdentityService identityService, BasketService basketService) : IRequestHandler<AddBasketItemCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
    {
        Guid userId = identityService.UserId;
        
        var basketAsString = await basketService.GetBasketFromCache(cancellationToken);

        Data.Basket currentBasket;
        var basket = new BasketItem(request.CourseId, request.CourseName, request.Price, request.ImageUri, null);

        if (string.IsNullOrEmpty(basketAsString))
        {
            currentBasket = new Data.Basket(userId, [basket]);
            await basketService.CreateCache(currentBasket, cancellationToken);
            return ServiceResult.SuccessAsNoContent();
        }

        currentBasket = JsonSerializer.Deserialize<Data.Basket>(basketAsString)!;
        
        var existingBasketItem = currentBasket.BasketItems.FirstOrDefault(bi => bi.Id == basket.Id);
        if (existingBasketItem is not null) currentBasket.BasketItems.Remove(existingBasketItem);
        currentBasket.BasketItems.Add(basket);

        currentBasket.ApplyAvailableDiscount();

        await basketService.CreateCache(currentBasket, cancellationToken);
        return ServiceResult.SuccessAsNoContent();
    }


}
