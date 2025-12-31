using UdemyMicroservice.Shared.Filters;

namespace UdemyMicroservice.Catalog.Api.Features.Categories.Create;

public static class CreateCategoryEndpoint
{
    public static RouteGroupBuilder CreateCategoryEndpointGroupItem(this RouteGroupBuilder group)
    {
        group.MapPost("/", async (CreateCategoryCommand command, IMediator mediator) => (await mediator.Send(command)).ToResult())
             .AddEndpointFilter<ValidationFilter<CreateCategoryCommand>>();

        return group;
    }
}
