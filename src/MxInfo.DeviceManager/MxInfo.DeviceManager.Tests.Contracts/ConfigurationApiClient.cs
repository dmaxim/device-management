using System.Text;
using System.Text.Json;
using MxInfo.DeviceManager.Tests.Contracts.Models;

namespace MxInfo.DeviceManager.Tests.Contracts;

public class ConfigurationApiClient
{
    private readonly Uri _baseUri;

    public ConfigurationApiClient(Uri baseUri)
    {
        _baseUri = baseUri;
    }

    public async Task<HttpResponseMessage> GetConfiguration(int deviceId)
    {
        using var client = new HttpClient();
        client.BaseAddress = _baseUri;
        var requestUri = $"/deviceConfiguration/{deviceId}";

        try
        {
            var response = await client.GetAsync(requestUri);
            return response;
        }
        catch (Exception ex)
        {
            throw new Exception("Unable to call configuration API get config end point", ex);
        }
    }

    public async Task<HttpResponseMessage> PublishConfiguration(PublishConfigurationRequest request)
    {
        using var client = new HttpClient();
        client.BaseAddress = _baseUri;
        var requestUri = "/deviceConfiguration/123";
        var content = new StringContent(
            JsonSerializer.Serialize(request),
            Encoding.UTF8,
            "application/json"
        );
        try
        {
            var response = await client.PostAsync(requestUri, content);
            return response;
        }
        catch (Exception ex)
        {
            throw new Exception("Unable to call configuration API publish config end point", ex);
        }
    }
    
    
}