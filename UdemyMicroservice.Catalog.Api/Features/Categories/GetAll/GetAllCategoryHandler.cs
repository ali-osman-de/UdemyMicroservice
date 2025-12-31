using UdemyMicroservice.Catalog.Api.Repositories;

namespace UdemyMicroservice.Catalog.Api.Features.Categories.GetAll;

public class GetAllCategoryHandler(UdemyDbContext context, IMapper mapper) : IRequestHandler<GetAllCategoryQuery, ServiceResult<List<CategoryDto>>>
{
    public async Task<ServiceResult<List<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await context.Categories.ToListAsync(cancellationToken);
        var mappedList = mapper.Map<List<CategoryDto>>(categories);

        return ServiceResult<List<CategoryDto>>.SuccessAsOk(mappedList);
    }
}
