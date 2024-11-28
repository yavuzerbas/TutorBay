using TutorBay.Catalog.API.Repositories;

namespace TutorBay.Catalog.API.Features.Courses.Create
{
    public class CreateCourseCommandHandler(
        AppDbContext context,
        IMapper mapper) : IRequestHandler<CreateCourseCommand, ServiceResult<Guid>>
    {
        public async Task<ServiceResult<Guid>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {

            var hasCategory = await context.Categories.AnyAsync(x => x.Id == request.CategoryId, cancellationToken);
            if (!hasCategory)
            {
                return ServiceResult<Guid>.Error($"Category with id {request.CategoryId} not found", HttpStatusCode.NotFound);
            }

            var hasCourse = await context.Courses.AnyAsync(x => x.Name == request.Name);

            if (hasCourse)
            {
                return ServiceResult<Guid>.Error($"Course with name {request.Name} already exist", HttpStatusCode.BadRequest);
            }

            var newCourse = mapper.Map<Course>(request);
            newCourse.Created = DateTime.Now;
            newCourse.Id = NewId.NextSequentialGuid();
            newCourse.Feature = new Feature()
            {
                Duration = 0,
                EducatorFullName = "", // get by token payload
                Rating = 0
            };

            context.Courses.Add(newCourse);
            await context.SaveChangesAsync();

            return ServiceResult<Guid>.SuccessAsCreated(newCourse.Id, $"/api/courses/{newCourse.Id}");


        }
    }
}
