using UdemyMicroservice.Catalog.Api.Repositories;

namespace UdemyMicroservice.Catalog.Api.Features.Categories.GetById;

public class GetByIdCategoryQueryHandler(UdemyDbContext context, IMapper mapper) : IRequestHandler<GetByIdCategoryQuery, ServiceResult<CategoryDto>>
{
    public async Task<ServiceResult<CategoryDto>> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.FindAsync(request.Id, cancellationToken);
        if (category == null) return ServiceResult<CategoryDto>.Error("Category not found", $"The Category ${request.Id} Id is not valid!", HttpStatusCode.NotFound);
        return ServiceResult<CategoryDto>.SuccessAsOk(mapper.Map<CategoryDto>(category));
    }
}
