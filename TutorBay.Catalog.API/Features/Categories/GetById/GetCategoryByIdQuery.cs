namespace TutorBay.Catalog.API.Features.Categories.GetById
{
    public record GetCategoryByIdQuery(Guid Id) : IRequestByServiceResult<CategoryDto>;
}
