using UdemyMicroservice.Shared.Interfaces;

namespace UdemyMicroservice.Catalog.Api.Features.Categories.Create;

public record CreateCategoryCommand(string Name) : IServiceResultWrapper.IRequestByServiceResult<CreateCategoryResponse>;
