using System.Net;
using PactNet.Infrastructure.Outputters;
using PactNet.Output.Xunit;
using PactNet.Verifier;
using Xunit.Abstractions;

namespace MxInfo.DeviceManager.Config.Tests.Contracts;

[Collection(nameof(ConfigurationApiFixtureCollection))]
public class ConfigurationApiPactTests
{
    private string _pactServiceUri = "http://127.0.01:9001";
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

        // using var webHost = WebHost.CreateDefaultBuilder().UseStartup<TestStartup>().UseUrls(_pactServiceUri).Build();
        // webHost.Start();
        //
        var client = _fixture.ApiClient;
        var baseUri = client.BaseAddress;

        // var response = await client.GetAsync("/deviceConfiguration/123");
        // Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        
        var pactVerifier = new PactVerifier("ConfigService", config);
        var pactFile = new FileInfo(Path.Join("..", "..", "..", "..", "pacts", "ApiClient-ConfigurationService.json"));
        pactVerifier.WithHttpEndpoint(baseUri)
            .WithFileSource(pactFile)
            //.WithProviderStateUrl(new Uri($"{_pactServiceUri}/provider-states"))
            .Verify();
    }
}