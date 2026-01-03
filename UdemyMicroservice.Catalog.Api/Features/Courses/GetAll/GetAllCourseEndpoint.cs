namespace UdemyMicroservice.Catalog.Api.Features.Courses.GetAll;

public static class GetAllCourseEndpoint
{
    public static RouteGroupBuilder GetAllCourseEndpointGroupItem(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (IMediator mediator) => (await mediator.Send(new GetAllCourseQuery())).ToResult())
             .MapToApiVersion(1, 0);
        return group;
    }
}
