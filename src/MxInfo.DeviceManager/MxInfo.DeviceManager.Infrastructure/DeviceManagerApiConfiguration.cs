namespace MxInfo.DeviceManager.Infrastructure;

public class DeviceManagerApiConfiguration
{
    public string  DbConnectionString { get; set; } = string.Empty;
    public string OpenAiKey { get; set; } = string.Empty;
    public void ThrowIfInvalid()
    {
        if (string.IsNullOrWhiteSpace(DbConnectionString))
        {
            throw new ArgumentNullException(nameof(DbConnectionString));
        }

        if (string.IsNullOrEmpty(OpenAiKey))
        {
            throw new ArgumentNullException(nameof(OpenAiKey));
        }
    }
}