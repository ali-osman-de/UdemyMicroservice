using MediatR;
using UdemyMicroservice.Shared.Extensions;
using UdemyMicroservice.Shared.Filters;

namespace UdemyMicroservice.Basket.Api.Features.Basket.ApplyDiscountToBasket;

public static class ApplyDiscountCouponEndpoint
{
    public static RouteGroupBuilder ApplyDiscountRateEndpointGroupItem(this RouteGroupBuilder group)
    {
        group.MapPut("/applydiscountrate", async (ApplyDiscountCouponCommand command, IMediator mediator) => (await mediator.Send(command)).ToResult())
             .MapToApiVersion(1, 0)
             .AddEndpointFilter<ValidationFilter<ApplyDiscountCouponCommandValidator>>();


        return group;
    }   
}
