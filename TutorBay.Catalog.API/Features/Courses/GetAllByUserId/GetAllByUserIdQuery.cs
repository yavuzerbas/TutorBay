using TutorBay.Catalog.API.Features.Courses.Dtos;

namespace TutorBay.Catalog.API.Features.Courses.GetAllByUserId
{
    public record GetAllByUserIdQuery(Guid Id) : IRequestByServiceResult<List<CourseDto>>;
}
