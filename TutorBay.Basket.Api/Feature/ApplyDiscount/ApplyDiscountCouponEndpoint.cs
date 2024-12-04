using MediatR;
using TutorBay.Shared.Extensions;
using TutorBay.Shared.Filters;

namespace TutorBay.Basket.Api.Feature.ApplyDiscount
{
    public static class ApplyDiscountCouponEndpoint
    {
        public static RouteGroupBuilder ApplyDiscountCouponGroupItemEndpoint(this RouteGroupBuilder builder)
        {

            builder.MapPut("/discount-coupon", async (IMediator mediator, ApplyDiscountCouponCommand request) =>
            {
                var result = await mediator.Send(request);
                return result.ToGenericResult();

            }).WithName("ApplyDiscountCoupon")
              .MapToApiVersion(1, 0)
              .AddEndpointFilter<ValidationFilter<ApplyDiscountCouponCommand>>();

            return builder;
        }
    }
}
