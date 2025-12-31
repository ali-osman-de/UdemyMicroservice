using UdemyMicroservice.Catalog.Api.Features.Categories.Create;
using UdemyMicroservice.Shared.Filters;

namespace UdemyMicroservice.Catalog.Api.Features.Categories.Update;

public static class UpdateCategoryEndpoint
{
    public static RouteGroupBuilder UpdateCategoryEndpointGroupItem(this RouteGroupBuilder group)
    {
        group.MapPut("/", async (IMediator mediator, UpdateCategoryRequest request) 
              => (await mediator.Send(new UpdateCategoryCommand(request.Id, request.Name))).ToResult())
             .AddEndpointFilter<ValidationFilter<UpdateCategoryRequest>>();
        return group; 
    }
}
