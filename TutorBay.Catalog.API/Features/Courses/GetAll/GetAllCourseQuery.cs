using TutorBay.Catalog.API.Features.Courses.Dtos;

namespace TutorBay.Catalog.API.Features.Courses.GetAll
{
    public record GetAllCourseQuery() : IRequestByServiceResult<List<CourseDto>>;
}
