namespace MxInfo.DeviceManager.Agent.Business.Managers;

/// <summary>
///  Contract for interactive with OpenAI
/// </summary>
public interface IOpenAiManager
{
    Task<string> GetMessage();
}