using Asp.Versioning.Builder;
using UdemyMicroservice.Basket.Api.Features.Basket.AddBasketItem;

namespace UdemyMicroservice.Basket.Api.Features.Basket;

public static class BasketEndpointExtension
{
    public static void AddBasketEndpointExtension(this WebApplication app, ApiVersionSet apiVersionSet)
    {
        app.MapGroup("api/v{version:apiVersion}/basket")
           .WithApiVersionSet(apiVersionSet)
           .AddBasketItemEndpointGroupItem();
    }
}
