using System.Text.Json.Serialization;

namespace MxInfo.DeviceManager.Config.Api.Models;

public class DeviceConfiguration
{
    [JsonPropertyName("deviceId")]
    public int DeviceId { get; set; }
    
    [JsonPropertyName("configurationData")]
    public string ConfigurationData { get; set; } = string.Empty;
}