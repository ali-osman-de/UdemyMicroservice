namespace UdemyMicroservice.Catalog.Api.Features.Courses.Dtos;

public record CourseDto(Guid Id, string Name, string Description, decimal Price, string ImageUri, CategoryDto Category, FeatureDto Feature);
