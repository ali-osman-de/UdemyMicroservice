using UdemyMicroservice.Shared.Filters;

namespace UdemyMicroservice.Catalog.Api.Features.Categories.Create;

public static class CreateCategoryEndpoint
{
    public static RouteGroupBuilder CreateCategoryEndpointGroupItem(this RouteGroupBuilder group)
    {
        group.MapPost("/", async (CreateCategoryCommand command, IMediator mediator) => (await mediator.Send(command)).ToResult())
             .MapToApiVersion(1,0) 
             .AddEndpointFilter<ValidationFilter<CreateCategoryCommand>>();

        return group;
    }
}
