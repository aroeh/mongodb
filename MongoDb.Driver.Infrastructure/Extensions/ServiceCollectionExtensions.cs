using MongoDb.Driver.Infrastructure.Repos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDb.Driver.Infrastructure.DbService;

namespace MongoDb.Driver.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureRepos(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<IRestuarantRepo, RestuarantRepo>();

        services.AddTransient<IMongoWrapper, MongoWrapper>();

        return services;
    }
}
