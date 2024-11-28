using TutorBay.Catalog.API.Features.Categories;
using TutorBay.Catalog.API.Features.Courses;

namespace TutorBay.Catalog.API.Repositories
{
    public static class SeedData
    {
        public static async Task<bool> AddSeedDataExt(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetService<AppDbContext>();

            dbContext.Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;

            bool dataInserted = false;

            if (!dbContext.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new() {Id = NewId.NextSequentialGuid(), Name = "Development"},
                    new() {Id = NewId.NextSequentialGuid(), Name = "Business"},
                    new() {Id = NewId.NextSequentialGuid(), Name = "IT & Software"},
                    new() {Id = NewId.NextSequentialGuid(), Name = "Office Productivity"},
                    new() {Id = NewId.NextSequentialGuid(), Name = "Personal Development"},
                };

                await dbContext.Categories.AddRangeAsync(categories);
                await dbContext.SaveChangesAsync();
                dataInserted = true;
            }

            if (!dbContext.Courses.Any())
            {
                var categories = await dbContext.Categories.ToListAsync();
                var courses = new List<Course>();
                var userId = NewId.NextSequentialGuid();

                foreach (var category in categories)
                {
                    courses.Add(new Course
                    {
                        Id = NewId.NextSequentialGuid(),
                        Name = $"Course 1 in {category.Name}",
                        Description = $"Description for Course 1 in {category.Name}",
                        Price = 100,
                        UserId = userId,
                        ImageUrl = null,
                        Created = DateTime.UtcNow,
                        CategoryId = category.Id,
                        Category = category,
                        Feature = new Feature
                        {
                            Duration = 0,
                            Rating = 0,
                            EducatorFullName = string.Empty
                        }
                    });

                    courses.Add(new Course
                    {
                        Id = NewId.NextSequentialGuid(),
                        Name = $"Course 2 in {category.Name}",
                        Description = $"Description for Course 2 in {category.Name}",
                        Price = 100,
                        UserId = userId,
                        ImageUrl = null,
                        Created = DateTime.UtcNow,
                        CategoryId = category.Id,
                        Category = category,
                        Feature = new Feature
                        {
                            Duration = 0,
                            Rating = 0,
                            EducatorFullName = string.Empty
                        }
                    });
                }

                await dbContext.Courses.AddRangeAsync(courses);
                await dbContext.SaveChangesAsync();
                dataInserted = true;
            }
            return dataInserted;
        }
    }
}
