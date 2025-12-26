using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Reflection;
using UdemyMicroservice.Catalog.Api.Features.Categories;
using UdemyMicroservice.Catalog.Api.Features.Courses;

namespace UdemyMicroservice.Catalog.Api.Repositories;

public class UdemyDbContext(DbContextOptions<UdemyDbContext> options) : DbContext(options)
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public static UdemyDbContext Create(IMongoDatabase database)
    {
        var optionsBuilder = new DbContextOptionsBuilder<UdemyDbContext>().UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName);

        return new UdemyDbContext(optionsBuilder.Options);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
