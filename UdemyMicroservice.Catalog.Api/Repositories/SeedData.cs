using MongoDB.Driver;
using UdemyMicroservice.Catalog.Api.Features.Categories;
using UdemyMicroservice.Catalog.Api.Features.Courses;

namespace UdemyMicroservice.Catalog.Api.Repositories
{
    public static class SeedData
    {
        public static async Task AddSeedDataExtension(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<UdemyDbContext>();

            dbContext.Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;

            if (!dbContext.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new() { Id = NewId.NextSequentialGuid(), Name = "Development" },
                    new() { Id = NewId.NextSequentialGuid(), Name = "Business" },
                    new() { Id = NewId.NextSequentialGuid(), Name = "IT & Software" },
                    new() { Id = NewId.NextSequentialGuid(), Name = "Office Productivity" },
                    new() { Id = NewId.NextSequentialGuid(), Name = "Personal Development" }
                };
                await dbContext.Categories.AddRangeAsync(categories);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Courses.Any())
            {
                var category = await dbContext.Categories.FirstAsync();

                var randomUserId = NewId.NextGuid();

                var courses = new List<Course>
                {
                    new()
                    {
                        Id = NewId.NextSequentialGuid(),
                        Name = "Complete C# Developer Course",
                        Description = "Learn C# from scratch and become a professional C# developer.",
                        Price = 49,
                        UserId = randomUserId,
                        ImageUri = "https://example.com/images/csharp-course.jpg",
                        CreateAt = DateTime.Now,
                        UpdateAt = DateTime.Now,
                        Feature = new Feature
                        {
                            Duration = 15,
                            Rating = 2,
                            EducatorFullName = "Jane Smith"
                        },
                        CategoryId = category.Id
                    },
                    new()
                    {
                        Id = NewId.NextSequentialGuid(),
                        Name = "ASP.NET Core Web API",
                        Description = "Build robust and scalable web APIs using ASP.NET Core.",
                        Price = 59,
                        UserId = randomUserId,
                        ImageUri = "https://example.com/images/aspnetcore-course.jpg",
                        CreateAt = DateTime.Now,
                        UpdateAt = DateTime.Now,
                        Feature = new Feature
                        {
                            Duration = 15,
                            Rating = 2,
                            EducatorFullName = "Jane Smith"
                        },
                        CategoryId = category.Id
                    },
                    new(){
                        Id = NewId.NextSequentialGuid(),
                        Name = "Entity Framework Core",
                        Description = "Master Entity Framework Core for data access in .NET applications.",
                        Price = 39,
                        UserId = randomUserId,
                        ImageUri = "https://example.com/images/efcore-course.jpg",
                        CreateAt = DateTime.Now,
                        UpdateAt = DateTime.Now,
                        Feature = new Feature
                        {
                            Duration = 15,
                            Rating = 2,
                            EducatorFullName = "Jane Smith"
                        },
                        CategoryId = category.Id
                    },
                    new()
                    {
                        Id = NewId.NextSequentialGuid(),
                        Name = "Blazor WebAssembly",
                        Description = "Create interactive web applications using Blazor WebAssembly.",
                        Price = 69,
                        UserId = randomUserId,
                        ImageUri = "https://example.com/images/blazor-course.jpg",
                        CreateAt = DateTime.Now,
                        UpdateAt = DateTime.Now,
                        Feature = new Feature
                        {
                            Duration = 15,
                            Rating = 2,
                            EducatorFullName = "Jane Smith"
                        },
                        CategoryId = category.Id
                    },
                };
                await dbContext.Courses.AddRangeAsync(courses);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
