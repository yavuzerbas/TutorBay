using MediatR;
using TutorBay.Shared.Extensions;

namespace TutorBay.Basket.Api.Feature.RemoveDiscount
{
    public static class RemoveDiscountCouponEndpoint
    {
        public static RouteGroupBuilder RemoveDiscountCouponGroupItemEndpoint(this RouteGroupBuilder builder)
        {
            builder.MapDelete("/discount-coupon", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new RemoveDiscountCouponCommand());
                return result.ToGenericResult();

            }).WithName("RemoveDiscountCoupon")
              .MapToApiVersion(1, 0);

            return builder;
        }
    }
}
