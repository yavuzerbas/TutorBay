using MediatR;
using TutorBay.Shared.Extensions;
using TutorBay.Shared.Filters;

namespace TutorBay.Basket.Api.Feature.AddBasketItem
{
    public static class AddBasketItemEndpoint
    {
        public static RouteGroupBuilder AddBasketItemGroupItemEndpoint(this RouteGroupBuilder routeGroupBuilder)
        {
            routeGroupBuilder.MapPost("/item", async (IMediator mediator, AddBasketItemCommand request) =>
            {
                var result = await mediator.Send(request);
                return result.ToGenericResult();


            }).WithName("AddBasketItem")
              .MapToApiVersion(1, 0)
              .AddEndpointFilter<ValidationFilter<AddBasketItemCommand>>();
            return routeGroupBuilder;
        }
    }
}
