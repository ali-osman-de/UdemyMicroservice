using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using UdemyMicroservice.Catalog.Api.Features.Categories;

namespace UdemyMicroservice.Catalog.Api.Repositories;

public class CategoryEntityConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToCollection("categories");
        builder.HasKey();
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Ignore(x => x.Courses);
    }
}
