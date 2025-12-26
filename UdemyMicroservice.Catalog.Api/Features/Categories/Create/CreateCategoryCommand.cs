using MediatR;
using UdemyMicroservice.Shared;

namespace UdemyMicroservice.Catalog.Api.Features.Categories.Create;

public record CreateCategoryCommand(string Name) : IRequest<ServiceResult<CreateCategoryResponse>>;
