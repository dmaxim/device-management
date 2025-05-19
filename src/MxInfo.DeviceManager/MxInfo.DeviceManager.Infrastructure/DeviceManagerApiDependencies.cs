using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MxInfo.DeviceManager.Business.Managers;
using MxInfo.DeviceManager.Data.Contexts;
using MxInfo.DeviceManager.Data.Repositories;
using MxInfo.DeviceManager.Domain.Repositories;

namespace MxInfo.DeviceManager.Infrastructure;


/// <summary>
/// Dependency injection configuration for the Device Manager API
/// </summary>
public static class DeviceManagerApiDependencies
{
    public static IServiceCollection AddDeviceManagerApiDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        AddConfiguration(services, configuration);
        services.AddDbContext<DeviceManagerEntityContext>((provider, options) =>
        {
            var appConfig = provider.GetRequiredService<IOptions<DeviceManagerApiConfiguration>>().Value;
            options.UseSqlServer(appConfig.DbConnectionString, sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(15), errorNumbersToAdd: new List<int>());
            });
        });
        
        services.AddScoped<IDeviceManagerEntityContext>(provider => provider.GetRequiredService<DeviceManagerEntityContext>());
        services.AddScoped<IDeviceRepository, DeviceRepository>();
        services.AddScoped<IWifiNetworkRepository, WifiNetworkRepository>();
        services.AddScoped<IEthernetNetworkRepository, EthernetNetworkRepository>();
        services.AddScoped<IDeviceManager, Business.Managers.DeviceManager>();
        services.AddScoped<IWifiNetworkManager, WifiNetworkManager>();
        services.AddScoped<IEthernetNetworkManager, EthernetNetworkManager>();
        
        
        
        
        return services;
    }

    private static void AddConfiguration(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DeviceManagerApiConfiguration>(configuration.GetSection("DeviceManagerApi"))
            .PostConfigure<DeviceManagerApiConfiguration>(config =>
            {
                config.ThrowIfInvalid();
            });
    }
}