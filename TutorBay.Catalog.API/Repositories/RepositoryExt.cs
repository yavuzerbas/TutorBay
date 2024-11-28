using MongoDB.Driver;
using TutorBay.Catalog.API.Options;

namespace TutorBay.Catalog.API.Repositories
{
    public static class RepositoryExt
    {
        public static IServiceCollection AddDatabaseServiceExt(this IServiceCollection services)
        {

            services.AddSingleton<IMongoClient, MongoClient>(sp =>
            {
                var mongoOption = sp.GetRequiredService<MongoOption>();
                return new MongoClient(mongoOption.ConnectionString);
            });

            services.AddScoped<AppDbContext>(sp =>
            {
                var mongoClient = sp.GetRequiredService<IMongoClient>();
                var mongoOption = sp.GetRequiredService<MongoOption>();

                return AppDbContext.Create(mongoClient.GetDatabase(mongoOption.DatabaseName));

            });

            return services;
        }
    }
}
