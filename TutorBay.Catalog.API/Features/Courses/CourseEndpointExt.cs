using Asp.Versioning.Builder;
using TutorBay.Catalog.API.Features.Courses.Create;
using TutorBay.Catalog.API.Features.Courses.Delete;
using TutorBay.Catalog.API.Features.Courses.GetAll;
using TutorBay.Catalog.API.Features.Courses.GetAllByUserId;
using TutorBay.Catalog.API.Features.Courses.GetById;
using TutorBay.Catalog.API.Features.Courses.Update;

namespace TutorBay.Catalog.API.Features.Courses
{
    public static class CourseEndpointExt
    {
        public static void AddCourseGroupEndpointExt(this WebApplication application, ApiVersionSet apiVersionSet)
        {
            application.MapGroup("api/v{version:apiversion}/courses").WithTags("Courses")
                .WithApiVersionSet(apiVersionSet)
                .CreateCourseGroupItemEndpoint()
                .GetAllCourseGroupItemEndpoint()
                .GetCourseByIdGroupItemEndpoint()
                .UpdateCourseGroupItemEndpoint()
                .DeleteCourseGroupItemEndpoint()
                .GetAllByUserIdGroupItemEndpoint();
        }
    }
}
