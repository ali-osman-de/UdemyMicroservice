using UdemyMicroservice.Catalog.Api.Features.Courses.Create;
using UdemyMicroservice.Catalog.Api.Features.Courses.GetAll;
using UdemyMicroservice.Catalog.Api.Features.Courses.GetAllByUserId;
using UdemyMicroservice.Catalog.Api.Features.Courses.GetById;
using UdemyMicroservice.Catalog.Api.Features.Courses.Remove;
using UdemyMicroservice.Catalog.Api.Features.Courses.Update;

namespace UdemyMicroservice.Catalog.Api.Features.Courses;

public static class CourseEndpointExtension
{
    public static void AddCourseEndpointExtension(this WebApplication app)
    {
        app.MapGroup("api/courses")
           .CreateCourseEndpointGroupItem()
           .GetAllCourseEndpointGroupItem()
           .GetByIdCourseEndpointGroupItem()
           .UpdateCourseEndpointGroupItem()
           .RemoveCourseEndpointGroupItem()
           .GetAllCourseByUserIdEndpointGroupItem();
    }
}
