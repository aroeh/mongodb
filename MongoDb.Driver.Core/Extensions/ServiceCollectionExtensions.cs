using MongoDb.Driver.Core.Orchestrations;
using Microsoft.Extensions.DependencyInjection;

namespace MongoDb.Driver.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoreOrchestrations(this IServiceCollection services)
    {
        services.AddTransient<IRestuarantOrchestration, RestuarantOrchestration>();

        return services;
    }
}