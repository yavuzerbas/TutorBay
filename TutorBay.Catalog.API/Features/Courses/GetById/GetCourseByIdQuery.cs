using TutorBay.Catalog.API.Features.Courses.Dtos;

namespace TutorBay.Catalog.API.Features.Courses.GetById
{
    public record GetCourseByIdQuery(Guid Id) : IRequestByServiceResult<CourseDto>;
}
