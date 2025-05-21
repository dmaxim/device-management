namespace MxInfo.DeviceManager.Business.Managers;

public class OpenAiConfiguration
{
    public string OpenAiKey { get; set; } = string.Empty;
    
    public void ThrowIfInvalid()
    {
        if (string.IsNullOrEmpty(OpenAiKey))
        {
            throw new ArgumentNullException(nameof(OpenAiKey));
        }
    }
}