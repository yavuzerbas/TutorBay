namespace TutorBay.Catalog.API.Features.Categories.GetById
{
    public static class GetCategoryByIdEndpoint
    {
        public static RouteGroupBuilder GetCategoryByIdGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{id:guid}", async (IMediator mediator, Guid id) =>
            {
                var result = await mediator.Send(new GetCategoryByIdQuery(id));

                return result.ToGenericResult();

            }).MapToApiVersion(1, 0)
              .WithName("GetCategoryById");

            return group;
        }
    }
}
