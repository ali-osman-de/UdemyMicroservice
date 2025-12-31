
using UdemyMicroservice.Catalog.Api.Repositories;

namespace UdemyMicroservice.Catalog.Api.Features.Categories.Update;

public class UpdateCategoryCommandHandler(UdemyDbContext context, IMapper mapper) : IRequestHandler<UpdateCategoryCommand, ServiceResult<CategoryDto>>
{
    public async Task<ServiceResult<CategoryDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var hasCategory = await context.Categories.FindAsync(request.Id, cancellationToken);
        if (hasCategory is null) return ServiceResult<CategoryDto>.Error("Category Not Found", $"{request.Id} is not valid", HttpStatusCode.NotFound);
        mapper.Map(request, hasCategory);
        await context.SaveChangesAsync(cancellationToken);
        var dto = mapper.Map<CategoryDto>(hasCategory);

        return ServiceResult<CategoryDto>.SuccessAsOk(dto);

    }
}
