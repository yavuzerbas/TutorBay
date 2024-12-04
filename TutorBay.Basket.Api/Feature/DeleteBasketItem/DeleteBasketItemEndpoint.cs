using MediatR;
using TutorBay.Shared.Extensions;

namespace TutorBay.Basket.Api.Feature.DeleteBasketItem
{
    public static class DeleteBasketItemEndpoint
    {
        public static RouteGroupBuilder DeleteBasketItemGroupItemEndpoint(this RouteGroupBuilder routeGroupBuilder)
        {
            routeGroupBuilder.MapDelete("/item{id:guid}", async (IMediator mediator, Guid id) =>
            {
                var result = await mediator.Send(new DeleteBasketItemCommand(id));
                return result.ToGenericResult();
            }).MapToApiVersion(1, 0).WithName("DeleteBasketItem");

            return routeGroupBuilder;
        }

    }
}
