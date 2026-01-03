using MediatR;
using UdemyMicroservice.Shared.Extensions;
using UdemyMicroservice.Shared.Filters;

namespace UdemyMicroservice.Basket.Api.Features.Basket.AddBasketItem;

public static class AddBasketItemEndpoint
{
    public static RouteGroupBuilder AddBasketItemEndpointGroupItem(this RouteGroupBuilder group)
    {
        group.MapPost("/item", async (AddBasketItemCommand command, IMediator mediator) => (await mediator.Send(command)).ToResult())
             .MapToApiVersion(1, 0)
             .AddEndpointFilter<ValidationFilter<AddBasketItemCommandValidator>>();

        return group;
    }
}
