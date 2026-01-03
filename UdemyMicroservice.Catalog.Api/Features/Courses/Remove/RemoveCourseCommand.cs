using UdemyMicroservice.Shared.Interfaces;

namespace UdemyMicroservice.Catalog.Api.Features.Courses.Remove;

public record RemoveCourseCommand(Guid Id) : IServiceResultWrapper.IRequestByServiceResult;
