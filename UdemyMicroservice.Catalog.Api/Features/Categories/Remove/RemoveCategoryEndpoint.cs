namespace UdemyMicroservice.Catalog.Api.Features.Categories.Remove;

public static class RemoveCategoryEndpoint
{
    public static RouteGroupBuilder RemoveCategoryEndpointGroupItem(this RouteGroupBuilder group)
    {
        group.MapDelete("/{id:guid}", async (IMediator mediator, Guid id) => (await mediator.Send(new RemoveCategoryCommand(id))).ToResult())
             .MapToApiVersion(1, 0);
        return group;
    }

}
