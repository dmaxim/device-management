namespace MxInfo.DeviceManager.Api.Models.DeviceConfiguration;

public class ConfigurationData
{
    public Guid PublisherId { get; set; }
    public int Version { get; set; }
    public string ConfigurationModel { get; set; } = string.Empty;
}