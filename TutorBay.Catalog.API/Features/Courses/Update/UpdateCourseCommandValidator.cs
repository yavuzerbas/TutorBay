namespace TutorBay.Catalog.API.Features.Courses.Update
{
    public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
