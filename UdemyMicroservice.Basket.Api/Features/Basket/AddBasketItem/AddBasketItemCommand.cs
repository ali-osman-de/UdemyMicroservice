using UdemyMicroservice.Shared.Interfaces;

namespace UdemyMicroservice.Basket.Api.Features.Basket.AddBasketItem;

public record AddBasketItemCommand(Guid Id, string Name, decimal Price, string? ImageUri) : IServiceResultWrapper.IRequestByServiceResult;
    