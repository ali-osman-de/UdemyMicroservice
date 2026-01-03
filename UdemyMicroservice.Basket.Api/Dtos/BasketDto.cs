namespace UdemyMicroservice.Basket.Api.Dtos;

public record BasketDto(Guid UserId, List<BasketItemDto> BasketItemsDto);
