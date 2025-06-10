using MxInfo.DeviceManager.App.Models;

namespace MxInfo.DeviceManager.App.Services;

public class DeviceApiClient : IDeviceApiClient
{
    public Task<List<DeviceModel>> GetDevicesAsync()
    {
        var devices = MockDataService.Devices;
        var deviceModels = devices.Select(d => new DeviceModel
        {
            Id = d.Id,
            Name = d.Name,
            Description = d.Description,
            Uid = d.Uid
        }).ToList();
        
        return Task.FromResult(deviceModels);
    }
}