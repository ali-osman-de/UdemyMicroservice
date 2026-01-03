using MediatR;
using UdemyMicroservice.Shared.Extensions;

namespace UdemyMicroservice.Basket.Api.Features.Basket.GetBasket;

public static class GetBasketEndpoint
{
    public static RouteGroupBuilder GetBasketItemEndpointGroupItem(this RouteGroupBuilder group)
    {
        group.MapGet("/user", async (IMediator mediator) => (await mediator.Send(new GetBasketQuery())).ToResult())
             .MapToApiVersion(1, 0);

        return group;
    }
}
