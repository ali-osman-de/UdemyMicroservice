namespace UdemyMicroservice.Catalog.Api.Features.Categories.GetAll;

public static class GetAllCategoryEndpoint
{

    public static RouteGroupBuilder GetAllCategoryEndpointGroupItem(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (IMediator mediator) => (await mediator.Send(new GetAllCategoryQuery())).ToResult())
             .MapToApiVersion(1, 0);
        return group;
    }

}
