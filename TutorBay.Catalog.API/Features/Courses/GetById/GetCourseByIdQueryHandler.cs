using TutorBay.Catalog.API.Features.Courses.Dtos;
using TutorBay.Catalog.API.Repositories;

namespace TutorBay.Catalog.API.Features.Courses.GetById
{
    public class GetCourseByIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCourseByIdQuery, ServiceResult<CourseDto>>
    {
        public async Task<ServiceResult<CourseDto>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await context.Courses.FindAsync(request.Id, cancellationToken);
            if (course == null)
            {
                return ServiceResult<CourseDto>.Error($"Course with id {request.Id} not found.", HttpStatusCode.NotFound);
            }
            var category = await context.Categories.FindAsync(course.CategoryId, cancellationToken);
            course.Category = category!;
            var courseDto = mapper.Map<CourseDto>(course);
            return ServiceResult<CourseDto>.SuccessAsOk(courseDto);
        }
    }
}
