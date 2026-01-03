using UdemyMicroservice.Catalog.Api.Features.Courses.Dtos;
using UdemyMicroservice.Catalog.Api.Repositories;

namespace UdemyMicroservice.Catalog.Api.Features.Courses.GetById;

public class GetByIdCourseQueryHandler(UdemyDbContext context, IMapper mapper) : IRequestHandler<GetByIdCourseQuery, ServiceResult<CourseDto>>
{
    public async Task<ServiceResult<CourseDto>> Handle(GetByIdCourseQuery request, CancellationToken cancellationToken)
    {
        var course = await context.Courses.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (course is null) return ServiceResult<CourseDto>.Error("Course Not Found", "Course Id not valid", HttpStatusCode.NotFound);
        var categories = (await context.Categories.FindAsync(course.CategoryId, cancellationToken))!;
        course.Category = categories;

        return ServiceResult<CourseDto>.SuccessAsOk(mapper.Map<CourseDto>(course));
    }
}
