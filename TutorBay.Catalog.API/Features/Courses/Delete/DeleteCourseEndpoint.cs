namespace TutorBay.Catalog.API.Features.Courses.Delete
{
    public static class DeleteCourseEndpoint
    {
        public static RouteGroupBuilder DeleteCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {

            group.MapDelete("/{id:guid}", async (IMediator mediator, Guid id) =>
            {
                var result = await mediator.Send(new DeleteCourseCommand(id));
                return result.ToGenericResult();
            }).WithName("DeleteCourse")
              .MapToApiVersion(1, 0);
            return group;
        }
    }
}
