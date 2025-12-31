using UdemyMicroservice.Shared.Interfaces;

namespace UdemyMicroservice.Catalog.Api.Features.Categories.Remove;

public record RemoveCategoryCommand(Guid Id) : IServiceResultWrapper.IRequestByServiceResult;