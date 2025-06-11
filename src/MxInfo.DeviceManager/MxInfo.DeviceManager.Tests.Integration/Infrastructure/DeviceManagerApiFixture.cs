using Aspire.Hosting;
using Microsoft.Extensions.Logging;

namespace MxInfo.DeviceManager.Tests.Integration.Infrastructure;

// ReSharper disable once ClassNeverInstantiated.Global
public class DeviceManagerApiFixture : IDisposable
{
    private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(30);
    private const string HostName = "deviceManagerApi";
    public HttpClient ApiClient { get; private set; } = null!;
    public CancellationToken DefaultCancellationToken { get; private set; }
    
    
    public DeviceManagerApiFixture()
    {
        InitializeAppHost().GetAwaiter().GetResult();
    }

    private DistributedApplication? _deviceManagerApiApp = null;

    private async Task InitializeAppHost()
    {
        DefaultCancellationToken = new CancellationTokenSource(DefaultTimeout).Token;
        var appHost =
            await DistributedApplicationTestingBuilder.CreateAsync<Projects.MxInfo_DeviceManager_AppHost>(
                DefaultCancellationToken);
        appHost.Services.AddLogging(logging =>
        {
            logging.SetMinimumLevel(LogLevel.Debug);
            // Override the logging filters from the app's configuration
            logging.AddFilter(appHost.Environment.ApplicationName, LogLevel.Debug);
            logging.AddFilter("Aspire.", LogLevel.Debug);
            // To output logs to the xUnit.net ITestOutputHelper, consider adding a package from https://www.nuget.org/packages?q=xunit+logging
        });
        appHost.Services.ConfigureHttpClientDefaults(clientBuilder =>
        {
            clientBuilder.AddStandardResilienceHandler();
        });

        _deviceManagerApiApp = await appHost.BuildAsync(DefaultCancellationToken)
            .WaitAsync(DefaultTimeout, DefaultCancellationToken);
        await _deviceManagerApiApp.StartAsync(DefaultCancellationToken)
            .WaitAsync(DefaultTimeout, DefaultCancellationToken);

        // Act
        ApiClient = _deviceManagerApiApp.CreateHttpClient(HostName);
        await _deviceManagerApiApp.ResourceNotifications.WaitForResourceHealthyAsync(HostName, DefaultCancellationToken)
            .WaitAsync(DefaultTimeout, DefaultCancellationToken);

    }

    public void Dispose()
    {
        _deviceManagerApiApp?.Dispose();
        ApiClient.Dispose();
    }
}