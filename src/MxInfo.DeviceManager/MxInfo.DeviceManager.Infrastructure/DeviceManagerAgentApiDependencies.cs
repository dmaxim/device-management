using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MxInfo.DeviceManager.Agent.Business.Managers;


namespace MxInfo.DeviceManager.Infrastructure;

/// <summary>
/// Dependency injection configuration for the Device Manager Agent API
/// </summary>
public static class DeviceManagerAgentApiDependencies
{
    public static IServiceCollection AddAgentApiDependencies(this IServiceCollection services,
        IConfiguration configuration)
    {
        AddConfiguration(services, configuration);

        services.AddScoped<IOpenAiManager, OpenAiManager>();
        return services;
    }
    
    private static void AddConfiguration(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<OpenAiConfiguration>(configuration.GetSection("DeviceManagerApi"))
            .PostConfigure<OpenAiConfiguration>(config =>
            {
                config.ThrowIfInvalid();
            });
    }
}