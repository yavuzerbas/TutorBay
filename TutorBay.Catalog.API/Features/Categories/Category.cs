using TutorBay.Catalog.API.Features.Courses;
using TutorBay.Catalog.API.Repositories;

namespace TutorBay.Catalog.API.Features.Categories
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = default!;
        public List<Course>? Courses { get; set; }
    }
}
