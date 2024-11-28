using TutorBay.Catalog.API.Repositories;

namespace TutorBay.Catalog.API.Features.Courses.Update
{
    public class UpdateCourseCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<UpdateCourseCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await context.Courses.FindAsync(request.Id, cancellationToken);

            if (course == null)
            {
                return ServiceResult.Error($"Course id: {request.Id} not found!", HttpStatusCode.NotFound);
            }

            course.Name = request.Name ?? course.Name; //TODO check also the course name if already exists
            course.Description = request.Description ?? course.Description;
            course.Price = request.Price ?? course.Price;
            course.ImageUrl = request.ImageUrl ?? course.ImageUrl;

            if (request.CategoryId != null)
            {
                course.CategoryId = request.CategoryId.Value;
                var category = await context.Categories.FindAsync(request.CategoryId, cancellationToken);
                if (category == null)
                {
                    return ServiceResult.Error($"Category id: {request.CategoryId} not found!", HttpStatusCode.NotFound);
                }
            }
            context.Courses.Update(course);
            await context.SaveChangesAsync();

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
