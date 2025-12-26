using MediatR;
using UdemyMicroservice.Catalog.Api.Features.Categories.Create;
using UdemyMicroservice.Shared.Extensions;

namespace UdemyMicroservice.Catalog.Api.Features.Categories;

public static class CategoryEndpoint
{
    public static RouteGroupBuilder CategoryEndpointGroupItem(this RouteGroupBuilder group)
    {
        group.MapPost("/", async (CreateCategoryCommand command, IMediator mediator) => (await mediator.Send(command)).ToResult());

        return group;
    }
}
