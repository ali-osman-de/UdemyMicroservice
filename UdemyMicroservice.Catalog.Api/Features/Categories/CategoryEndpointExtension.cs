using UdemyMicroservice.Catalog.Api.Features.Categories.Create;
using UdemyMicroservice.Catalog.Api.Features.Categories.GetAll;
using UdemyMicroservice.Catalog.Api.Features.Categories.GetById;
using UdemyMicroservice.Catalog.Api.Features.Categories.Remove;
using UdemyMicroservice.Catalog.Api.Features.Categories.Update;

namespace UdemyMicroservice.Catalog.Api.Features.Categories;

public static class CategoryEndpointExtension
{
    public static void AddCategoryEndpointExtension(this WebApplication app)
    {
        app.MapGroup("api/categories")
           .CreateCategoryEndpointGroupItem()
           .GetAllCategoryEndpointGroupItem()
           .GetByIdCategoryEndpointGroupItem()
           .RemoveCategoryEndpointGroupItem()
           .UpdateCategoryEndpointGroupItem();
    }
}
