using UdemyMicroservice.Basket.Api.Dtos;
using UdemyMicroservice.Shared.Interfaces;

namespace UdemyMicroservice.Basket.Api.Features.Basket.GetBasket;

public record GetBasketQuery : IServiceResultWrapper.IRequestByServiceResult<BasketDto>;
