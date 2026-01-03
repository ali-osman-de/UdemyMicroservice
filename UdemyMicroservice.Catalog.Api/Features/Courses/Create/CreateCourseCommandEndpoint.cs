using UdemyMicroservice.Shared.Filters;

namespace UdemyMicroservice.Catalog.Api.Features.Courses.Create;

public static class CreateCourseCommandEndpoint
{
    public static RouteGroupBuilder CreateCourseEndpointGroupItem(this RouteGroupBuilder group)
    {
        group.MapPost("/", async (CreateCourseCommand command, IMediator mediator) => (await mediator.Send(command)).ToResult())
            .Produces<Guid>(StatusCodes.Status201Created)
            .MapToApiVersion(1, 0)
            .AddEndpointFilter<ValidationFilter<CreateCourseCommand>>(); 
        return group;
    }
}
