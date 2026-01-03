using UdemyMicroservice.Catalog.Api.Features.Courses.Dtos;
using UdemyMicroservice.Shared.Interfaces;

namespace UdemyMicroservice.Catalog.Api.Features.Courses.GetAllByUserId;

public record GetAllCourseByUserIdQuery(Guid Id) : IServiceResultWrapper.IRequestByServiceResult<List<CourseDto>>;
