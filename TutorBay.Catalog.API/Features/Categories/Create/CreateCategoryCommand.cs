﻿namespace TutorBay.Catalog.API.Features.Categories.Create
{
    public record CreateCategoryCommand(string Name) : IRequestByServiceResult<CreateCategoryResponse>;
}
