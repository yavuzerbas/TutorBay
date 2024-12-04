using FluentValidation;

namespace TutorBay.Basket.Api.Feature.ApplyDiscount
{
    public class ApplyDiscountCouponCommandValidator : AbstractValidator<ApplyDiscountCouponCommand>
    {
        public ApplyDiscountCouponCommandValidator()
        {
            RuleFor(x => x.discountRate).LessThanOrEqualTo(1).WithMessage("{PropertyName} cannot be higher than 1");
            RuleFor(x => x.discountRate).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");

            RuleFor(x => x.couponCode).NotEmpty().WithMessage("{PropertyName} must be filled.");
        }
    }
}
