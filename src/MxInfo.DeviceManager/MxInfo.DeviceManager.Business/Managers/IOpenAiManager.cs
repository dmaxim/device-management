namespace MxInfo.DeviceManager.Business.Managers;

/// <summary>
///  Contract for interactive with OpenAI
/// </summary>
public interface IOpenAiManager
{
    string GetMessage();
}