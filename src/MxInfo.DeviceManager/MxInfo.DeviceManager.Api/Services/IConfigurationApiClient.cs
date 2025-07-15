using MxInfo.DeviceManager.Api.Models.DeviceConfiguration;

namespace MxInfo.DeviceManager.Api.Services;

public interface IConfigurationApiClient
{
    Task<string> GetConfigurationAsync(int  deviceId); 
    
    Task PublishConfigurationAsync(int deviceId, ConfigurationData configuration);
}