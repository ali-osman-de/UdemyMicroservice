using UdemyMicroservice.Shared.Interfaces;

namespace UdemyMicroservice.Catalog.Api.Features.Categories.GetAll;

public class GetAllCategoryQuery : IServiceResultWrapper.IRequestByServiceResult<List<CategoryDto>>;
