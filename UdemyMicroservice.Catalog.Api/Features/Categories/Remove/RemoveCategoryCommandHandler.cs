
using UdemyMicroservice.Catalog.Api.Repositories;

namespace UdemyMicroservice.Catalog.Api.Features.Categories.Remove;

public class RemoveCategoryCommandHandler(UdemyDbContext context) : IRequestHandler<RemoveCategoryCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.FindAsync(request.Id, cancellationToken);
        if (category == null) return ServiceResult.Error("Id Not Found", "The category Id is not valid", HttpStatusCode.NotFound);
        context.Categories.Remove(category);
        await context.SaveChangesAsync(cancellationToken);
        return ServiceResult.SuccessAsNoContent();
    }
}
