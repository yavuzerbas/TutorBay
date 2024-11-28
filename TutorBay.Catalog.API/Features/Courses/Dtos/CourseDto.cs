namespace TutorBay.Catalog.API.Features.Courses.Dtos
{
    public record CourseDto(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        string? ImageUrl,
        DateTime Created,
        FeatureDto Feature,
        CategoryDto Category
        );
}
