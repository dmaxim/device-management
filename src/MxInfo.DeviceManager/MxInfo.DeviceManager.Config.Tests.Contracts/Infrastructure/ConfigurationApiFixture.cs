using Aspire.Hosting;
using Aspire.Hosting.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MxInfo.DeviceManager.Config.Tests.Contracts.Infrastructure;

// ReSharper disable once ClassNeverInstantiated.Global
public class ConfigurationApiFixture : IDisposable
{
 
    private const string HostName = "deviceConfigApi";
    private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(30);
    public HttpClient ApiClient { get; set; } = null!;

    public ConfigurationApiFixture()
    {
        InitializeAppHost().GetAwaiter().GetResult();
    }
    
    private DistributedApplication? _configApiApp = null;
    public CancellationToken DefaultCancellationToken { get; private set; }
    
    private async Task InitializeAppHost()
    {
        DefaultCancellationToken = new CancellationTokenSource(DefaultTimeout).Token;
        var appHost =
            await DistributedApplicationTestingBuilder.CreateAsync<Projects.MxInfo_DeviceManager_Config_Api>(
                DefaultCancellationToken);
        appHost.Services.AddLogging(logging =>
        {
            logging.SetMinimumLevel(LogLevel.Debug);
            // Override the logging filters from the app's configuration
            FilterLoggingBuilderExtensions.AddFilter((ILoggingBuilder)logging, appHost.Environment.ApplicationName, LogLevel.Debug);
            FilterLoggingBuilderExtensions.AddFilter((ILoggingBuilder)logging, "Aspire.", LogLevel.Debug);
            // To output logs to the xUnit.net ITestOutputHelper, consider adding a package from https://www.nuget.org/packages?q=xunit+logging
        });
        appHost.Services.ConfigureHttpClientDefaults(clientBuilder =>
        {
            clientBuilder.AddStandardResilienceHandler();
        });

        _configApiApp = await appHost.BuildAsync(DefaultCancellationToken)
            .WaitAsync(DefaultTimeout, DefaultCancellationToken);
        await _configApiApp.StartAsync(DefaultCancellationToken)
            .WaitAsync(DefaultTimeout, DefaultCancellationToken);

        
        ApiClient = _configApiApp.CreateHttpClient(HostName);
        
        await _configApiApp.ResourceNotifications.WaitForResourceHealthyAsync(HostName, DefaultCancellationToken)
            .WaitAsync(DefaultTimeout, DefaultCancellationToken);

    }
    
    public void Dispose()
    {
        _configApiApp?.Dispose();
        ApiClient.Dispose();
    }
}