using MxInfo.DeviceManager.Api.Models.DeviceConfiguration;

namespace MxInfo.DeviceManager.Api.Services;

public class ConfigurationApiClient(HttpClient httpClient) : IConfigurationApiClient
{
    public async Task<string> GetConfigurationAsync(int deviceId)
    {
        var requestUri = $"/deviceConfiguration/{deviceId}";
        var response = await httpClient.GetAsync(requestUri).ConfigureAwait(false);
        if(response.IsSuccessStatusCode)
        {
            return $"Retrieved configuration for device {deviceId}";
        }
        throw new InvalidOperationException("Unable to call configuration API");
    }

    public async Task PublishConfigurationAsync(int deviceId, ConfigurationData configuration)
    {
        var requestUri = $"/deviceConfiguration/{deviceId}";
        var requestContent = new StringContent(
            System.Text.Json.JsonSerializer.Serialize(configuration),
            System.Text.Encoding.UTF8,
            "application/json");

        var response = await httpClient.PostAsync(requestUri, requestContent).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException("Unable to publish a configuration");
        }
    }
    
}