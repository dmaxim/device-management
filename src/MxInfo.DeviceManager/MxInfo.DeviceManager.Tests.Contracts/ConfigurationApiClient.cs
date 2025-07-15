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
            throw new Exception("Unable to call configuration API", ex);
        }
    }
    
    
}