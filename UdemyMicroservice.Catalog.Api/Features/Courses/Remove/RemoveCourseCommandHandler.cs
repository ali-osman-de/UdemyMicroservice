
using UdemyMicroservice.Catalog.Api.Repositories;

namespace UdemyMicroservice.Catalog.Api.Features.Courses.Remove;

public class RemoveCourseCommandHandler(UdemyDbContext context) : IRequestHandler<RemoveCourseCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(RemoveCourseCommand request, CancellationToken cancellationToken)
    {
        var course = await context.Courses.FindAsync(request.Id, cancellationToken);
        if(course is null) return ServiceResult.ErrorAsNotFound();
        context.Courses.Remove(course);
        await context.SaveChangesAsync(cancellationToken);
        return ServiceResult.SuccessAsNoContent();
    }
}
