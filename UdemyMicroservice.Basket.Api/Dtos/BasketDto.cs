using System.Text.Json.Serialization;

namespace UdemyMicroservice.Basket.Api.Dtos;

public record BasketDto()
{
    public BasketDto(Guid userId, List<BasketItemDto> basketItemsDto) : this()
    {
        UserId = userId;
        BasketItemsDto = basketItemsDto;
    }

    [JsonIgnore] 
    public Guid UserId { get; init; }
    public List<BasketItemDto> BasketItemsDto { get; set; } 


};
