namespace TutorBay.Catalog.API.Features.Courses.GetAllByUserId
{
    public static class GetAllByUserIdEndpoint
    {
        public static RouteGroupBuilder GetAllByUserIdGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("user/{userId:guid}", async (IMediator mediator, Guid userId) =>
            {

                var result = await mediator.Send(new GetAllByUserIdQuery(userId));
                return result.ToGenericResult();

            }).WithName("GetAllByUserId")
              .MapToApiVersion(1, 0);
            return group;
        }
    }
}
