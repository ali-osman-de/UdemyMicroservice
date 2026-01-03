namespace UdemyMicroservice.Catalog.Api.Features.Courses.GetById;

public static class GetByIdCourseEndpoint
{
    public static RouteGroupBuilder GetByIdCourseEndpointGroupItem(this RouteGroupBuilder group)
    {
        group.MapGet("/{id:guid}", async (IMediator mediator, Guid id) => (await mediator.Send(new GetByIdCourseQuery(id))).ToResult());
        return group;
    }
}
