using MxInfo.DeviceManager.App.Models;

namespace MxInfo.DeviceManager.App.Services;

public interface IDeviceApiClient
{
    Task<List<DeviceModel>> GetDevicesAsync();
    // Task<Device> GetDeviceByIdAsync(string deviceId);
    // Task AddDeviceAsync(Device device);
    // Task UpdateDeviceAsync(Device device);
    // Task DeleteDeviceAsync(string deviceId);
    
}