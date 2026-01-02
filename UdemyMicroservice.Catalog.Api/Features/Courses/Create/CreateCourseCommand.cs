using UdemyMicroservice.Shared.Interfaces;

namespace UdemyMicroservice.Catalog.Api.Features.Courses.Create;

public record CreateCourseCommand(string Name, 
                                  string Description, 
                                  decimal Price, 
                                  string ImageUri, 
                                  Guid CategoryId) : IServiceResultWrapper.IRequestByServiceResult<Guid>;
