using TutorBay.Catalog.API.Repositories;

namespace TutorBay.Catalog.API.Features.Categories.GetById
{
    public class GetCategoryByIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, ServiceResult<CategoryDto>>
    {
        public async Task<ServiceResult<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await context.Categories.FindAsync(request.Id, cancellationToken);

            if (category == null)
            {
                return ServiceResult<CategoryDto>.Error($"Category with id:{request.Id} found", System.Net.HttpStatusCode.NotFound);
            }
            var categoryDto = mapper.Map<CategoryDto>(category);
            return ServiceResult<CategoryDto>.SuccessAsOk(categoryDto);
        }
    }
}
