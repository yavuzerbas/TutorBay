﻿using TutorBay.Catalog.API.Features.Categories;
using TutorBay.Catalog.API.Repositories;

namespace TutorBay.Catalog.API.Features.Courses
{
    public class Course : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public Guid UserId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime Created { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = default!;
        public Feature Feature { get; set; } = default!;

    }
}
