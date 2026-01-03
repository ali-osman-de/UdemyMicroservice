namespace UdemyMicroservice.Catalog.Api.Features.Categories.GetById;

public static class GetByIdCategoryEndpoint
{
    public static RouteGroupBuilder GetByIdCategoryEndpointGroupItem(this RouteGroupBuilder group)
    {
        group.MapGet("/{id:guid}", async (IMediator mediator, Guid id) => (await mediator.Send(new GetByIdCategoryQuery(id))).ToResult())
             .MapToApiVersion(1, 0);
        return group;
    }
}
