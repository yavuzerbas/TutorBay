
using TutorBay.Catalog.API.Features.Courses.Dtos;
using TutorBay.Catalog.API.Repositories;

namespace TutorBay.Catalog.API.Features.Courses.GetAllByUserId
{
    public class GetAllByUserIdQueryHandler(AppDbContext context, IMapper mapper)
        : IRequestHandler<GetAllByUserIdQuery, ServiceResult<List<CourseDto>>>
    {
        public async Task<ServiceResult<List<CourseDto>>> Handle(GetAllByUserIdQuery request, CancellationToken cancellationToken)
        {
            var courses = await context.Courses.Where(x => x.UserId == request.Id).ToListAsync(cancellationToken);
            var categories = await context.Categories.ToListAsync(cancellationToken);
            foreach (var course in courses)
            {
                course.Category = categories.First(x => x.Id == course.CategoryId);
            }
            var courseDtos = mapper.Map<List<CourseDto>>(courses);

            return ServiceResult<List<CourseDto>>.SuccessAsOk(courseDtos);
        }
    }
}
