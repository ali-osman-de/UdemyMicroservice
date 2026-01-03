namespace UdemyMicroservice.Catalog.Api.Features.Courses.Remove;

public static class RemoveCourseEndpoint
{
    public static RouteGroupBuilder RemoveCourseEndpointGroupItem(this RouteGroupBuilder group)
    {
        group.MapDelete("/{id:guid}", async (IMediator mediator, Guid id) => (await mediator.Send(new RemoveCourseCommand(id))).ToResult())
             .MapToApiVersion(1, 0);
        return group;
    }
}
