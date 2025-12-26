using UdemyMicroservice.Catalog.Api;
using UdemyMicroservice.Catalog.Api.Features.Categories;
using UdemyMicroservice.Catalog.Api.Options;
using UdemyMicroservice.Catalog.Api.Repositories;
using UdemyMicroservice.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddMongoOptionServiceExtension();
builder.Services.AddRepositoryExtension();
builder.Services.AddCommonServiceExtension(typeof(CatalogAssembly));


var app = builder.Build();
app.AddCategoryEndpointExtension();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Run();
