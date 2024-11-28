using TutorBay.Catalog.API.Features.Courses.Dtos;
using TutorBay.Catalog.API.Repositories;

namespace TutorBay.Catalog.API.Features.Courses.GetAll
{
    public class GetAllCourseQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllCourseQuery, ServiceResult<List<CourseDto>>>
    {
        public async Task<ServiceResult<List<CourseDto>>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
        {
            var courses = await context.Courses.ToListAsync();
            var categories = await context.Categories.ToListAsync();

            foreach (var course in courses)
            {
                course.Category = categories.First(x => x.Id == course.CategoryId);
            }
            var courseDtos = mapper.Map<List<CourseDto>>(courses);

            return ServiceResult<List<CourseDto>>.SuccessAsOk(courseDtos);
        }
    }
}
