﻿namespace TutorBay.Catalog.API.Features.Courses.Create
{
    public record CreateCourseCommand(
        string Name,
        string Description,
        decimal Price,
        string? ImageUrl,
        Guid CategoryId) : IRequestByServiceResult<Guid>;
}
