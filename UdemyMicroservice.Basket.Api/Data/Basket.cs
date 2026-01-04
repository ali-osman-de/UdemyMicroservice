using System.Text.Json.Serialization;
using UdemyMicroservice.Basket.Api.Dtos;

namespace UdemyMicroservice.Basket.Api.Data;

public class Basket
{
    public Guid UserId { get; set; }
    public List<BasketItem> BasketItems { get; set; } = new();
    public float? DiscountRate { get; set; }
    public string? Coupon { get; set; }

    [JsonIgnore]
    public bool IsDiscountApplied => DiscountRate is > 0 && !string.IsNullOrEmpty(Coupon);

    [JsonIgnore]
    public decimal TotalPrice => BasketItems.Sum(x => x.Price);
    
    [JsonIgnore]
    public decimal? TotalPriceDiscounted => !IsDiscountApplied? null : BasketItems.Sum(x => x.PriceByApplyDiscountRate);
    public Basket(Guid userId, List<BasketItem> basketItems)
    {
        UserId = userId;
        BasketItems = basketItems;
    }
    public Basket()
    {

    }

    public void ApplyDiscount(string coupon, float discountRate)
    {
        Coupon = coupon;
        DiscountRate = discountRate;

        foreach (var item in BasketItems)
        {
            item.PriceByApplyDiscountRate = item.Price * (decimal)(1 - discountRate);
        }

    }

    public void ApplyAvailableDiscount()
    {
        if (!IsDiscountApplied) return;

        foreach (var item in BasketItems)
        {
            item.PriceByApplyDiscountRate = item.Price * (decimal)(1 - DiscountRate!);
        }

    }

    public void ClearDiscount()
    {
        DiscountRate = null;
        Coupon = null;
        foreach (var item in BasketItems)
        {
            item.PriceByApplyDiscountRate = null;
        }
    }

}
