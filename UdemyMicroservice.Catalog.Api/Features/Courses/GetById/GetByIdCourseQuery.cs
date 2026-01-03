using UdemyMicroservice.Catalog.Api.Features.Courses.Dtos;
using UdemyMicroservice.Shared.Interfaces;

namespace UdemyMicroservice.Catalog.Api.Features.Courses.GetById;

public record GetByIdCourseQuery(Guid Id) : IServiceResultWrapper.IRequestByServiceResult<CourseDto>;
