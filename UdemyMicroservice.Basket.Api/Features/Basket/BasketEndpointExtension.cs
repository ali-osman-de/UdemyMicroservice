using Asp.Versioning.Builder;
using UdemyMicroservice.Basket.Api.Features.Basket.AddBasketItem;
using UdemyMicroservice.Basket.Api.Features.Basket.ApplyDiscountToBasket;
using UdemyMicroservice.Basket.Api.Features.Basket.GetBasket;
using UdemyMicroservice.Basket.Api.Features.Basket.RemoveBasketItem;
using UdemyMicroservice.Basket.Api.Features.Basket.RollBackDiscountToBasket;

namespace UdemyMicroservice.Basket.Api.Features.Basket;

public static class BasketEndpointExtension
{
    public static void AddBasketEndpointExtension(this WebApplication app, ApiVersionSet apiVersionSet)
    {
        app.MapGroup("api/v{version:apiVersion}/basket")
           .WithApiVersionSet(apiVersionSet)
           .AddBasketItemEndpointGroupItem()
           .RemoveBasketItemEndpointGroupItem()
           .GetBasketItemEndpointGroupItem()
           .ApplyDiscountRateEndpointGroupItem()
           .RollBackDiscountEndpointGroupItem();
    }
}
