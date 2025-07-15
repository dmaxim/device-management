using PactNet;
using Xunit.Abstractions;

namespace MxInfo.DeviceManager.Tests.Contracts.Infrastructure;


/// <summary>
/// Test fixture for the configuration API contract tests.
/// </summary>
public class ConfigurationApiFixture
{
    public IPactBuilderV3 PactBuilder { get; private set; }
    private const int Port = 9001;
    public bool Initialized { get; private set; } = false;
    
    public void InitializePact(ITestOutputHelper outputHelper)
    {
        var config = new PactConfig
        {
            PactDir = Path.Join("..", "..", "..", "..", "pacts"),
            Outputters = [new XUnitOutput(outputHelper)],
            LogLevel = PactLogLevel.Debug 
        };
     
        PactBuilder = Pact.V3("ApiClient", "ConfigurationService", config)
            .WithHttpInteractions(Port);
        
        Initialized = true;
    }
}