namespace TutorBay.Catalog.API.Features.Courses.GetAll
{
    public static class GetAllCourseEndpoint
    {
        public static RouteGroupBuilder GetAllCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {

            group.MapGet("/", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetAllCourseQuery());
                return result.ToGenericResult();
            }).WithName("GetAllCourse")
              .MapToApiVersion(1, 0);

            return group;
        }
    }
}
