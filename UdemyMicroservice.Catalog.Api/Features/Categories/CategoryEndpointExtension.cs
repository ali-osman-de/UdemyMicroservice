namespace UdemyMicroservice.Catalog.Api.Features.Categories;

public static class CategoryEndpointExtension
{
    public static void AddCategoryEndpointExtension(this WebApplication app)
    {
        app.MapGroup("api/categories").CategoryEndpointGroupItem();
    }
}
