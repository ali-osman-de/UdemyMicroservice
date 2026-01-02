using UdemyMicroservice.Catalog.Api;
using UdemyMicroservice.Catalog.Api.Features.Categories;
using UdemyMicroservice.Catalog.Api.Features.Courses;
using UdemyMicroservice.Catalog.Api.Options;
using UdemyMicroservice.Catalog.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddMongoOptionServiceExtension();
builder.Services.AddRepositoryExtension();
builder.Services.AddSwaggerGen();
builder.Services.AddCommonServiceExtension(typeof(CatalogAssembly));


var app = builder.Build();
app.AddCategoryEndpointExtension();
app.AddCourseEndpointExtension();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
    app.UseSwagger();
    app.MapOpenApi();
}

app.Run();
