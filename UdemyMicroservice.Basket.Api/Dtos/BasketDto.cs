using System.Text.Json.Serialization;

namespace UdemyMicroservice.Basket.Api.Dtos;

public record BasketDto()
{
    public BasketDto(Guid userId, List<BasketItemDto> basketItems) : this()
    {
        UserId = userId;
        BasketItems = basketItems;
    }

    [JsonIgnore] 
    public Guid UserId { get; init; }
    public List<BasketItemDto>? BasketItems { get; set; } 


};
