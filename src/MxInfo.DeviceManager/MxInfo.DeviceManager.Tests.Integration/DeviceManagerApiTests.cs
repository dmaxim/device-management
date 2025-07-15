using MxInfo.DeviceManager.Tests.Integration.Infrastructure;

namespace MxInfo.DeviceManager.Tests.Integration;

[Collection(nameof(DeviceManagerApiFixtureCollection))]
public class DeviceManagerApiTests(DeviceManagerApiFixture testFixture)
{
    private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(30);

    [Fact]
    public async Task GetWebResourceRootReturnsOkStatusCode()
    {

        var response = await testFixture.ApiClient.GetAsync("/devices", testFixture.DefaultCancellationToken);
    
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task GetDeviceConfigurationReturnsOkStatusCode()
    {
        var deviceId = 1;

        var response = await testFixture.ApiClient.GetAsync($"/deviceConfiguration/{deviceId}", testFixture.DefaultCancellationToken);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
