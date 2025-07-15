using System.Net;
using PactNet;
using Xunit.Abstractions;

namespace MxInfo.DeviceManager.Tests.Contracts;

    public class ConfigurationApiPactTests(ITestOutputHelper outputHelper)
    {

        [Fact]
        public async Task HandlesGetConfiguration()
        {
            var port = 9001;
                   
            
            var config = new PactConfig
            {
                PactDir = Path.Join("..", "..", "..", "..", "pacts"),
                Outputters = [new XUnitOutput(outputHelper)],
                LogLevel = PactLogLevel.Debug 
            };
       
            var pact = Pact.V3("ApiClient", "ConfigurationService", config).WithHttpInteractions(port);


            pact.UponReceiving("A valid GET request for configuration data")
                .Given("Configuration data is available")
                .WithRequest(HttpMethod.Get, "/deviceConfiguration/123")
                .WillRespond()
                .WithStatus(HttpStatusCode.OK);
               // .WithHeader("Content-Type", "application/json");
            
            
            await pact.VerifyAsync(async ctx =>
            {
                var client = new ConfigurationApiClient(new Uri($"http://localhost:{port}"));
                var response = await client.GetConfiguration(123).ConfigureAwait(false);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            
            
            });
        }
    }
