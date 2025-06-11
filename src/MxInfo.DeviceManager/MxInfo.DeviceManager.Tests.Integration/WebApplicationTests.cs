using MxInfo.DeviceManager.Tests.Integration.Infrastructure;


namespace MxInfo.DeviceManager.Tests.Integration;

/// <summary>
/// Tests to validate the web application functionality.
/// </summary>
[Collection(nameof(WebApplicationFixtureCollection))]
public class WebApplicationTests(WebApplicationFixture testFixture)
{
    
    [Fact] 
    public async Task GetWebResourceRootReturnsOkStatusCode()
    {
        var cancellationToken = testFixture.DefaultCancellationToken;
        var response = await testFixture.ApiClient.GetAsync("/", cancellationToken);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    /// <summary>
    /// Test to demonstrate the use of HTML parsing in integration tests.
    /// </summary>
    [Fact]
    public async Task GetDevicesReturnsExpectedContent()
    {
        var response = await testFixture.ApiClient.GetAsync("/devices", testFixture.DefaultCancellationToken);
        var responseBody = await HtmlHelpers.GetDocumentAsync(response);
       
        var initialParagraph = responseBody.QuerySelector("p");
        Assert.NotNull(initialParagraph);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}