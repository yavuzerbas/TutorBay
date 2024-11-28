namespace TutorBay.Catalog.API.Features.Courses.Update
{
    public static class UpdateCourseEndpoint
    {
        public static RouteGroupBuilder UpdateCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {

            group.MapPut("/", async (UpdateCourseCommand request, IMediator mediator) =>
            {
                var result = await mediator.Send(request);
                return result.ToGenericResult();

            }).WithName("UpdateCourse")
              .MapToApiVersion(1, 0)
              .AddEndpointFilter<ValidationFilter<UpdateCourseCommandValidator>>();

            return group;
        }
    }
}
