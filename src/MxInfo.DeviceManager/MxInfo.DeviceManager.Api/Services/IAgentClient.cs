namespace MxInfo.DeviceManager.Api.Services;

public interface IAgentClient
{
    Task<string> GetMessageAsync();
}