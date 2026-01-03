
using UdemyMicroservice.Catalog.Api.Repositories;

namespace UdemyMicroservice.Catalog.Api.Features.Courses.Update;

public class UpdateCourseCommandHandler(UdemyDbContext context) : IRequestHandler<UpdateCourseCommand, ServiceResult<Guid>>
{
    public async Task<ServiceResult<Guid>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = await context.Courses.FindAsync(request.Id, cancellationToken);
        if (course is null) return ServiceResult<Guid>.Error("Not Found", "Id is not valid", HttpStatusCode.NotFound);
        course.Name = request.Name;
        course.Description = request.Description;
        course.Price = request.Price;
        course.ImageUri = request.ImageUri;
        course.CategoryId = request.CategoryId;

        context.Courses.Update(course);
        await context.SaveChangesAsync(cancellationToken);
        return ServiceResult<Guid>.SuccessAsOk(course.Id);
    }
}
