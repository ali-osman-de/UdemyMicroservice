using UdemyMicroservice.Catalog.Api.Features.Courses.Dtos;
using UdemyMicroservice.Catalog.Api.Repositories;

namespace UdemyMicroservice.Catalog.Api.Features.Courses.GetAllByUserId;

public class GetAllCourseByUserIdQueryHandler(UdemyDbContext context, IMapper mapper) : IRequestHandler<GetAllCourseByUserIdQuery, ServiceResult<List<CourseDto>>>
{
    public async Task<ServiceResult<List<CourseDto>>> Handle(GetAllCourseByUserIdQuery request, CancellationToken cancellationToken)
    {
        var courses = await context.Courses.Where(x => x.UserId == request.Id).ToListAsync(cancellationToken);
        var categories = await context.Categories.ToListAsync(cancellationToken);

        foreach (var course in courses)
        {
            course.Category = categories.First(x => x.Id == course.CategoryId);
        }

        return ServiceResult<List<CourseDto>>.SuccessAsOk(mapper.Map<List<CourseDto>>(courses));
    }
}
