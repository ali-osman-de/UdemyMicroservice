using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UdemyMicroservice.Catalog.Api.Repositories;
using UdemyMicroservice.Shared;

namespace UdemyMicroservice.Catalog.Api.Features.Categories.Create;

public class CreateCategoryCommandHandler(UdemyDbContext context) : IRequestHandler<CreateCategoryCommand, ServiceResult<CreateCategoryResponse>>
{
    public async Task<ServiceResult<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var existsCategory = await context.Categories.AnyAsync(x => x.Name == request.Name, cancellationToken);
        if (existsCategory)
        {
            return ServiceResult<CreateCategoryResponse>.Error("Category Name already exists", $"The category name {request.Name} already in use", HttpStatusCode.BadRequest);
        }

        var category = new Category
        {
            Id = NewId.NextSequentialGuid(),
            Name = request.Name
        };

        await context.AddAsync(category, cancellationToken);
        await context.SaveChangesAsync();
        return ServiceResult<CreateCategoryResponse>.SuccessAsCreated(new CreateCategoryResponse(category.Id), "<empty>");
    }
}
