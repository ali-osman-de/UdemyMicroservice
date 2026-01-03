using UdemyMicroservice.Catalog.Api.Features.Courses.Dtos;
using UdemyMicroservice.Catalog.Api.Repositories;

namespace UdemyMicroservice.Catalog.Api.Features.Courses.GetAll;

public class GetAllCourseQueryHandler(UdemyDbContext context, IMapper mapper) : IRequestHandler<GetAllCourseQuery, ServiceResult<List<CourseDto>>>
{
    public async Task<ServiceResult<List<CourseDto>>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
    {
        var courses = await context.Courses.ToListAsync(cancellationToken);
        var categories = await context.Categories.ToListAsync(cancellationToken);

        foreach (var course in courses)
        {
            course.Category = categories.First(x => x.Id == course.CategoryId);
        }

        return ServiceResult<List<CourseDto>>.SuccessAsOk(mapper.Map<List<CourseDto>>(courses));
    }
}
