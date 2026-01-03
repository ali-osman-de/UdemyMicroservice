using UdemyMicroservice.Catalog.Api.Features.Courses.GetAll;

namespace UdemyMicroservice.Catalog.Api.Features.Courses.GetAllByUserId;

public static class GetAllCourseByUserIdEndpoint
{
    public static RouteGroupBuilder GetAllCourseByUserIdEndpointGroupItem(this RouteGroupBuilder group)
    {
        group.MapGet("/user/{userId:guid}", async (IMediator mediator, Guid UserId) => (await mediator.Send(new GetAllCourseByUserIdQuery(UserId))).ToResult());
        return group;
    }
}
