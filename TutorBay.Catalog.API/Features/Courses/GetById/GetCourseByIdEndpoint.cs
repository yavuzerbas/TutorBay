namespace TutorBay.Catalog.API.Features.Courses.GetById
{
    public static class GetCourseByIdEndpoint
    {
        public static RouteGroupBuilder GetCourseByIdGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{id:guid}", async (IMediator mediator, Guid id) =>
            {
                var result = await mediator.Send(new GetCourseByIdQuery(id));
                return result.ToGenericResult();
            }).WithName("GetCourseById")
              .MapToApiVersion(1, 0);

            return group;
        }
    }
}
