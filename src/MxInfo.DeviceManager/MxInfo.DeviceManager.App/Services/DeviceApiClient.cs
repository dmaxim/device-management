using MxInfo.DeviceManager.App.Models;

namespace MxInfo.DeviceManager.App.Services;

public class DeviceApiClient(HttpClient httpClient) : IDeviceApiClient
{
    public async Task<List<DeviceModel>> GetDevicesAsync()
    {
        var deviceModels = await httpClient.GetFromJsonAsync<List<DeviceModel>>("devices");
        return deviceModels ?? [];
    }
}