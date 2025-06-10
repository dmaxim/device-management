namespace MxInfo.DeviceManager.App.Services;

/// <summary>
/// Dependency injection configuration for the Device Manager App
/// </summary>
public static class DeviceManagerAppDependencies
{
    
    public static IServiceCollection AddDeviceManagerDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        //AddConfiguration(services, configuration);
        services.AddScoped<IDeviceApiClient, DeviceApiClient>();
        return services;
    }
    
    // private static void AddConfiguration(IServiceCollection services, IConfiguration configuration)
    // {
    //     services.Configure<OpenAiConfiguration>(configuration.GetSection("DeviceManagerApi"))
    //         .PostConfigure<OpenAiConfiguration>(config =>
    //         {
    //             config.ThrowIfInvalid();
    //         });
    // }
}