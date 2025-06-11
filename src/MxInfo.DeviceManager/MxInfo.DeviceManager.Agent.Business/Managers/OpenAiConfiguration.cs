namespace MxInfo.DeviceManager.Agent.Business.Managers;

public class OpenAiConfiguration
{
    public string OpenAiKey { get; set; } = string.Empty;
    public string OpenAiModel { get; set; } = string.Empty;
    public void ThrowIfInvalid()
    {
        if (string.IsNullOrEmpty(OpenAiKey))
        {
            throw new ArgumentNullException(nameof(OpenAiKey));
        }
        
        if (string.IsNullOrEmpty(OpenAiModel))
        {
            throw new ArgumentNullException(nameof(OpenAiModel));
        }
    }
}