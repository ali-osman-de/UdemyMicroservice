using UdemyMicroservice.Shared.Interfaces;

namespace UdemyMicroservice.Catalog.Api.Features.Categories.Update;

public record UpdateCategoryCommand(Guid Id, string Name) : IServiceResultWrapper.IRequestByServiceResult<CategoryDto>;
