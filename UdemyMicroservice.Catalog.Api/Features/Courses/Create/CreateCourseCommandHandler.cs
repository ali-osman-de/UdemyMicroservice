
using UdemyMicroservice.Catalog.Api.Repositories;

namespace UdemyMicroservice.Catalog.Api.Features.Courses.Create;

public class CreateCourseCommandHandler(UdemyDbContext context, IMapper mapper) : IRequestHandler<CreateCourseCommand, ServiceResult<Guid>>
{
    public Task<ServiceResult<Guid>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        
    }
}
