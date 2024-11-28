using Microsoft.AspNetCore.Mvc;

namespace TutorBay.Catalog.API.Features.Courses.Create
{
    public static class CreateCourseEndpoint
    {
        public static RouteGroupBuilder CreateCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/", async (CreateCourseCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);

                return result.ToGenericResult();

            }).WithName("CreateCourse")
            .MapToApiVersion(1, 0)
            .Produces<Guid>(StatusCodes.Status201Created)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
            .AddEndpointFilter<ValidationFilter<CreateCourseCommandValidator>>();

            return group;
        }
    }
}
