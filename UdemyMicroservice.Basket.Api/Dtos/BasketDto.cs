using System.Text.Json.Serialization;

namespace UdemyMicroservice.Basket.Api.Dtos;

public record BasketDto()
{
    public List<BasketItemDto>? BasketItems { get; set; }
    public float? DiscountRate { get; set; }
    public string? Coupon { get; set; }
    public BasketDto(List<BasketItemDto> basketItems) : this()
    {
        BasketItems = basketItems;
    }

    [JsonIgnore]
    public bool IsDiscountApplied => DiscountRate is > 0 && !string.IsNullOrEmpty(Coupon);
    public decimal TotalPrice => BasketItems.Sum(x => x.Price);

    public decimal? TotalPriceDiscounted => !IsDiscountApplied ? null : BasketItems.Sum(x => x.PriceByApplyDiscountRate);


};
