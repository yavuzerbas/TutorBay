using TutorBay.Catalog.API;
using TutorBay.Catalog.API.Features.Categories;
using TutorBay.Catalog.API.Features.Courses;
using TutorBay.Catalog.API.Options;
using TutorBay.Catalog.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptionsExt();
builder.Services.AddDatabaseServiceExt();
builder.Services.AddCommonServiceExt(typeof(CatalogAssembly));
builder.Services.AddVersioningExt();

var app = builder.Build();

app.AddSeedDataExt().ContinueWith(task =>
{
    if (task.IsFaulted)
    {
        Console.WriteLine(task.Exception?.Message);
    }
    else if (task.Result)
    {
        Console.WriteLine("Seed data has been saved successfully");
    }
    else
    {
        Console.WriteLine("No data was inserted; the database is already seeded.");
    }
});
app.AddCategoryGroupEndpointExt(app.AddVersionSetExtension());
app.AddCourseGroupEndpointExt(app.AddVersionSetExtension());


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();