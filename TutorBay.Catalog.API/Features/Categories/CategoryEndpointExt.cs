using Asp.Versioning.Builder;
using TutorBay.Catalog.API.Features.Categories.Create;
using TutorBay.Catalog.API.Features.Categories.GetAll;
using TutorBay.Catalog.API.Features.Categories.GetById;

namespace TutorBay.Catalog.API.Features.Categories
{
    public static class CategoryEndpointExt
    {
        public static void AddCategoryGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiversion}/categories")
                .WithTags("Categories")
                .WithApiVersionSet(apiVersionSet)
                .CreateCategoryGroupItemEndpoint()
                .GetAllCategoryGroupItemEndpoint()
                .GetCategoryByIdGroupItemEndpoint();
        }
    }
}
