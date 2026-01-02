using UdemyMicroservice.Catalog.Api.Features.Courses.Create;

namespace UdemyMicroservice.Catalog.Api.Features.Courses;

public static class CourseEndpointExtension
{
    public static void AddCourseEndpointExtension(this WebApplication app)
    {
        app.MapGroup("api/courses")
           .CreateCourseEndpointGroupItem();
    }
}
