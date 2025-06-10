using System.Net;

namespace MxInfo.DeviceManager.Api.Services;

public class AgentClient(HttpClient httpClient) : IAgentClient
{
    public async Task<string> GetMessageAsync()
    {
        var response = await httpClient.GetAsync("openai");
        return await response.Content.ReadAsStringAsync();
    }
}