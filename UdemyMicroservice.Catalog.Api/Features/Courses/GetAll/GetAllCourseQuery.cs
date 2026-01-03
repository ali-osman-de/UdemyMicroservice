using UdemyMicroservice.Catalog.Api.Features.Courses.Dtos;
using UdemyMicroservice.Shared.Interfaces;

namespace UdemyMicroservice.Catalog.Api.Features.Courses.GetAll;

public class GetAllCourseQuery : IServiceResultWrapper.IRequestByServiceResult<List<CourseDto>>;
