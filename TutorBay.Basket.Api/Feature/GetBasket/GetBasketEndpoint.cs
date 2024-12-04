using MediatR;
using TutorBay.Shared.Extensions;

namespace TutorBay.Basket.Api.Feature.GetBasket
{
    public static class GetBasketEndpoint
    {
        public static RouteGroupBuilder GetBasketGroupItemEndpoint(this RouteGroupBuilder routeGroupBuilder)
        {
            routeGroupBuilder.MapGet("/", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetBasketQuery());
                return result.ToGenericResult();

            }).MapToApiVersion(1, 0)
              .WithName("GetBasket");
            return routeGroupBuilder;
        }
    }
}
