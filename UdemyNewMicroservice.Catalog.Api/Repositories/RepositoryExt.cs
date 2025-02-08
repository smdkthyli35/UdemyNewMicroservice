using MongoDB.Driver;
using UdemyNewMicroservice.Catalog.Api.Options;

namespace UdemyNewMicroservice.Catalog.Api.Repositories
{
    public static class RepositoryExt
    {
        public static IServiceCollection AddDatabaseServiceExt(this IServiceCollection services)
        {
            services.AddSingleton<IMongoClient, MongoClient>(sp =>
            {
                MongoOption options = sp.GetRequiredService<MongoOption>();
                return new MongoClient(options.ConnectionString);
            });

            services.AddScoped(sp =>
            {
                IMongoClient mongoClient = sp.GetRequiredService<IMongoClient>();
                MongoOption options = sp.GetRequiredService<MongoOption>();
                return AppDbContext.Create(mongoClient.GetDatabase(options.DatabaseName));
            });

            return services;
        }
    }
}
