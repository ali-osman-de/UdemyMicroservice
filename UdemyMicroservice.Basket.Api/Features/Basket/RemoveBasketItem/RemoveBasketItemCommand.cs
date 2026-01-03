using UdemyMicroservice.Shared.Interfaces;

namespace UdemyMicroservice.Basket.Api.Features.Basket.RemoveBasketItem;

public record RemoveBasketItemCommand(Guid Id) : IServiceResultWrapper.IRequestByServiceResult;
