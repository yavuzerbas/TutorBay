using TutorBay.Catalog.API.Repositories;

namespace TutorBay.Catalog.API.Features.Categories.GetAll
{
    public class GetAllCategoryQueryHandler(AppDbContext context, IMapper mapper) :
        IRequestHandler<GetAllCategoryQuery, ServiceResult<List<CategoryDto>>>
    {
        public async Task<ServiceResult<List<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await context.Categories.ToListAsync(cancellationToken: cancellationToken);
            var categoryDtos = mapper.Map<List<CategoryDto>>(categories);
            //var categoryDtos = categories.Select(x => new CategoryDto(x.Id, x.Name)).ToList();


            return ServiceResult<List<CategoryDto>>.SuccessAsOk(categoryDtos);
        }
    }
}
