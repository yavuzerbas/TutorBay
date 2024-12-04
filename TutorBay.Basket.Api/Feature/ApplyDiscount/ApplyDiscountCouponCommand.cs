using TutorBay.Shared;

namespace TutorBay.Basket.Api.Feature.ApplyDiscount
{
    public record ApplyDiscountCouponCommand(
        float discountRate,
        string couponCode) : IRequestByServiceResult;
}
