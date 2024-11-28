

using TutorBay.Catalog.API.Repositories;

namespace TutorBay.Catalog.API.Features.Courses.Delete
{
    public class DeleteCourseCommandHandler(AppDbContext context) : IRequestHandler<DeleteCourseCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await context.Courses.FindAsync(request.Id, cancellationToken);
            if (course == null)
            {
                return ServiceResult.ErrorAsNotFound();
            }

            context.Courses.Remove(course);
            context.SaveChanges();

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
