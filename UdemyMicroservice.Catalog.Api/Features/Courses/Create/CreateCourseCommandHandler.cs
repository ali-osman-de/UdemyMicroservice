
using UdemyMicroservice.Catalog.Api.Repositories;

namespace UdemyMicroservice.Catalog.Api.Features.Courses.Create;

public class CreateCourseCommandHandler(UdemyDbContext context, IMapper mapper) : IRequestHandler<CreateCourseCommand, ServiceResult<Guid>>
{
    public async Task<ServiceResult<Guid>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var hasCategory = await context.Categories.AnyAsync(x => x.Id == request.CategoryId, cancellationToken);
        if (!hasCategory) return ServiceResult<Guid>.Error("Category Issue", "Category not found", HttpStatusCode.NotFound);

        var hasName = await context.Courses.AnyAsync(x => x.Name == request.Name, cancellationToken);
        if (hasName) return ServiceResult<Guid>.Error("Course Name Issue", "Name Already Token", HttpStatusCode.BadRequest);

        var course = mapper.Map<Course>(request);
        course.Id = NewId.NextSequentialGuid();
        course.Feature = new Feature
        {
            Duration = 10,
            Rating = 3,
            EducatorFullName = "AOD"
        };
        course.CreateAt = DateTime.UtcNow;
        course.UpdateAt = DateTime.UtcNow;
        context.Courses.Add(course);
        context.SaveChanges();
        return ServiceResult<Guid>.SuccessAsCreated(course.Id, $"/api/courses/{course.Id}");
    }
}
