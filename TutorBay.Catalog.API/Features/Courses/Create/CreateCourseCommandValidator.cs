﻿namespace TutorBay.Catalog.API.Features.Courses.Create
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(x => x.Description).NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters");

            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
