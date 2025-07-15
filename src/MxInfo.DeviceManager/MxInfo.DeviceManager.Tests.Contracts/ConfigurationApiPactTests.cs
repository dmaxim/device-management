using System.Net;
using MxInfo.DeviceManager.Tests.Contracts.Infrastructure;
using MxInfo.DeviceManager.Tests.Contracts.Models;
using PactNet;
using Xunit.Abstractions;

namespace MxInfo.DeviceManager.Tests.Contracts;


/// <summary>
/// Tests to generate the Pact for the Configuration API.
/// </summary>
/// <param name="fixture"></param>
[Collection(nameof(ConfigurationApiFixtureCollection))]
public class ConfigurationApiPactTests
{

    private readonly ConfigurationApiFixture _fixture;
    public ConfigurationApiPactTests(ITestOutputHelper output, ConfigurationApiFixture fixture)
    {
        _fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));
        _fixture.InitializePact(output);
    }
    [Fact]
    public async Task HandlesGetConfiguration()
    {
        var port = 9001;


        _fixture.PactBuilder.UponReceiving("A valid GET request for configuration data")
            .Given("Configuration data is available")
            .WithRequest(HttpMethod.Get, "/deviceConfiguration/123")
            .WillRespond()
            .WithStatus(HttpStatusCode.OK)
            .WithHeader("Content-Type", "application/json");


        await _fixture.PactBuilder.VerifyAsync(async ctx =>
        {
            var client = new ConfigurationApiClient(new Uri($"http://localhost:{port}"));
            var response = await client.GetConfiguration(123).ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);


        });
    }
    
    [Fact]
    public async Task HandlesPublishConfiguration()
    {
        var port = 9001;

        _fixture.PactBuilder.UponReceiving("A valid POST request to publish configuration")
            .Given("Configuration can be published")
            .WithRequest(HttpMethod.Post, "/deviceConfiguration/123")
            .WithHeader("Content-Type", "application/json")
            .WithJsonBody(new
            {
                PublisherId = "123e4567-e89b-12d3-a456-426614174000",
                Version = 1
            })
            .WillRespond()
            .WithStatus(HttpStatusCode.Created);

        await _fixture.PactBuilder.VerifyAsync(async ctx =>
        {
            var client = new ConfigurationApiClient(new Uri($"http://localhost:{port}"));
            var response = await client.PublishConfiguration(new PublishConfigurationRequest
            {
                PublisherId = Guid.Parse("123e4567-e89b-12d3-a456-426614174000"),
                Version = 1
            }).ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        });
    }


}
