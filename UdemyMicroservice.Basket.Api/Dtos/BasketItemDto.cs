namespace UdemyMicroservice.Basket.Api.Dtos;

public record BasketItemDto(Guid Id, string Name, decimal Price, string? ImageUri, decimal? PriceByApplyDiscountRate);