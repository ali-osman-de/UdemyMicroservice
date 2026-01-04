using MediatR;
using UdemyMicroservice.Shared.Extensions;

namespace UdemyMicroservice.Basket.Api.Features.Basket.RollBackDiscountToBasket;

public static class RollBackDiscountCouponEndpoint
{
    public static RouteGroupBuilder RollBackDiscountEndpointGroupItem(this RouteGroupBuilder group)
    {
        group.MapDelete("/rollbackdiscount", async (IMediator mediator) => (await mediator.Send(new RollBackDiscountCouponCommand())).ToResult())
             .MapToApiVersion(1, 0);

        return group;
    }
}
