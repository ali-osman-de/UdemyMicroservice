using UdemyMicroservice.Shared.Interfaces;

namespace UdemyMicroservice.Basket.Api.Features.Basket.AddBasketItem;

public record AddBasketItemCommand(Guid CourseId, string CourseName, decimal Price, string? ImageUri) : IServiceResultWrapper.IRequestByServiceResult;
    