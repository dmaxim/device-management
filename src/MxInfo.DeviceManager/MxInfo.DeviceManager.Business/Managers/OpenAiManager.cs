using Microsoft.Extensions.Options;

namespace MxInfo.DeviceManager.Business.Managers;


/// <summary>
/// Implementation of the OpenAI manager
/// </summary>
public class OpenAiManager(IOptions<OpenAiConfiguration> configuration) : IOpenAiManager
{
    public string GetMessage()
    {
        var key = configuration.Value.OpenAiKey;
        return "message from manager";
        
    }
}