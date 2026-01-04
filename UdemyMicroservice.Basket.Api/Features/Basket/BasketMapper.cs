using AutoMapper;
using UdemyMicroservice.Basket.Api.Dtos;

namespace UdemyMicroservice.Basket.Api.Features.Basket;

public class BasketMapper : Profile
{
    public BasketMapper()
    {
        CreateMap<BasketDto, Data.Basket>().ReverseMap();
        CreateMap<BasketItemDto, Data.BasketItem>().ReverseMap();
    }

}
