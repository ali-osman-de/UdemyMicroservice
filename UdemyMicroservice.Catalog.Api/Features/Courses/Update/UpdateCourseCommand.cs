using UdemyMicroservice.Shared.Interfaces;

namespace UdemyMicroservice.Catalog.Api.Features.Courses.Update;

public record UpdateCourseCommand(Guid Id,
                                  string Name,
                                  string Description,
                                  decimal Price,
                                  string ImageUri,
                                  Guid CategoryId) : IServiceResultWrapper.IRequestByServiceResult<Guid>;
