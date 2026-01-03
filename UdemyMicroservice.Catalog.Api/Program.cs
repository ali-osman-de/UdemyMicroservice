using UdemyMicroservice.Catalog.Api;
using UdemyMicroservice.Catalog.Api.Features.Categories;
using UdemyMicroservice.Catalog.Api.Features.Courses;
using UdemyMicroservice.Catalog.Api.Options;
using UdemyMicroservice.Catalog.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddMongoOptionServiceExtension();
builder.Services.AddRepositoryExtension();
builder.Services.AddVersioningExtension();
builder.Services.AddSwaggerGen();
builder.Services.AddCommonServiceExtension(typeof(CatalogAssembly));


var app = builder.Build();
app.AddSeedDataExtension().ContinueWith(x =>
{
    Console.WriteLine(x.IsFaulted ? x.Exception?.Message : "Seed Data has been successfully loaded!");
});

app.AddCategoryEndpointExtension(app.AddVersionSetExtension());
app.AddCourseEndpointExtension(app.AddVersionSetExtension());

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
    app.UseSwagger();
    app.MapOpenApi();
}

app.Run();
