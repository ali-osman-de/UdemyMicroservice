using MediatR;
using UdemyMicroservice.Shared.Extensions;
using UdemyMicroservice.Shared.Filters;

namespace UdemyMicroservice.Basket.Api.Features.Basket.RemoveBasketItem;

public static class RemoveBasketItemEndpoint
{
    public static RouteGroupBuilder RemoveBasketItemEndpointGroupItem(this RouteGroupBuilder group)
    {
        group.MapDelete("/item/{Id:guid}", async (Guid Id, IMediator mediator) => (await mediator.Send(new RemoveBasketItemCommand(Id))).ToResult())
             .MapToApiVersion(1, 0);
             //.AddEndpointFilter<ValidationFilter<RemoveBasketItemCommandValidator>>();

        return group;
    }
}
