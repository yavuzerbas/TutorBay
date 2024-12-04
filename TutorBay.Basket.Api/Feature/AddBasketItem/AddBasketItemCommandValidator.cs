using FluentValidation;

namespace TutorBay.Basket.Api.Feature.AddBasketItem
{
    public class AddBasketItemCommandValidator : AbstractValidator<AddBasketItemCommand>
    {
        public AddBasketItemCommandValidator()
        {
            RuleFor(x => x.CourseId).NotEmpty().WithMessage("CourseId is required");
            RuleFor(x => x.CourseName).NotEmpty().WithMessage("CourseName is required");
            RuleFor(x => x.CoursePrice).GreaterThan(-1).WithMessage("CoursePrice must be greater or equal to 0");
        }
    }
}
