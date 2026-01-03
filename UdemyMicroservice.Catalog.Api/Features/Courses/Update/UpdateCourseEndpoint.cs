using UdemyMicroservice.Shared.Filters;

namespace UdemyMicroservice.Catalog.Api.Features.Courses.Update;

public static class UpdateCourseEndpoint
{
    public static RouteGroupBuilder UpdateCourseEndpointGroupItem(this RouteGroupBuilder group)
    {
        group.MapPut("/", async (IMediator mediator, UpdateCourseCommand command)
              => (await mediator.Send(new UpdateCourseCommand(command.Id, 
                                                              command.Name, 
                                                              command.Description, 
                                                              command.Price, 
                                                              command.ImageUri, 
                                                              command.CategoryId))).ToResult())
             .AddEndpointFilter<ValidationFilter<UpdateCourseCommand>>();
        return group;
    }
}
