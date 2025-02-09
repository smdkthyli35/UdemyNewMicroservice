using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UdemyNewMicroservice.Catalog.Api.Repositories;
using UdemyNewMicroservice.Shared;

namespace UdemyNewMicroservice.Catalog.Api.Features.Categories.Create
{
    public class CreateCategoryCommandHandler(AppDbContext context) : IRequestHandler<CreateCategoryCommand, ServiceResult<CreateCategoryResponse>>
    {
        public async Task<ServiceResult<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            bool existCategory = await context.Categories.AnyAsync(x => x.Name == request.Name, cancellationToken);
            if (existCategory)
            {
                ServiceResult<CreateCategoryResponse>.Error("Category name already exist", $"The category name {request.Name} aldready exist", HttpStatusCode.BadRequest);
            }

            Category category = new()
            {
                Id = NewId.NextSequentialGuid(),
                Name = request.Name
            };

            await context.AddAsync(category, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult<CreateCategoryResponse>.SuccessAsCreated(new CreateCategoryResponse(category.Id), "");
        }
    }
}