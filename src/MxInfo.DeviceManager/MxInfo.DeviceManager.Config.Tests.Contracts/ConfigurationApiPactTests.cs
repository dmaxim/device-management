using MxInfo.DeviceManager.Config.Tests.Contracts.Infrastructure;
using PactNet.Infrastructure.Outputters;
using PactNet.Output.Xunit;
using PactNet.Verifier;
using Xunit.Abstractions;

namespace MxInfo.DeviceManager.Config.Tests.Contracts;

[Collection(nameof(ConfigurationApiFixtureCollection))]
public class ConfigurationApiPactTests
{
    private readonly ITestOutputHelper _output;
    private readonly ConfigurationApiFixture _fixture;

    public ConfigurationApiPactTests(ITestOutputHelper output, ConfigurationApiFixture fixture)
    {
        _output = output;
        _fixture = fixture;
    }

    [Fact]
    public void EnsureConfigApiHonorsPactWithConsumer()
    {
        
        var config = new PactVerifierConfig
        {
            Outputters = new List<IOutput>
            {
                new XunitOutput(_output)
            }
            
        };

        var pactVerifier = new PactVerifier("ConfigurationService", config);
        // var pactFile = new FileInfo(Path.Join("..", "..", "..", "..", "pacts", "ApiClient-ConfigurationService.json"));
        // pactVerifier.WithHttpEndpoint(_fixture.ApiClient.BaseAddress)
        //     .WithFileSource(pactFile)
        //     //.WithProviderStateUrl(new Uri($"{_pactServiceUri}/provider-states"))
        //     .Verify();
        
        pactVerifier.WithHttpEndpoint(_fixture.ApiClient.BaseAddress)
            .WithPactBrokerSource(new Uri("http://localhost:9292"), options =>
            {
                options.ConsumerVersionSelectors(new List<ConsumerVersionSelector>
                {
                    new ConsumerVersionSelector
                    {
                       Branch = "main",
                       
                    }
                });
                
            })
            .Verify();
    }
}