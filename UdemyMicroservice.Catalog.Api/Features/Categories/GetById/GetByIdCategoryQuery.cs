using UdemyMicroservice.Shared.Interfaces;

namespace UdemyMicroservice.Catalog.Api.Features.Categories.GetById;

public record GetByIdCategoryQuery(Guid Id) : IServiceResultWrapper.IRequestByServiceResult<CategoryDto>;
