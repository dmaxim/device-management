using Microsoft.AspNetCore.Components;
using MxInfo.DeviceManager.App.Models;
using MxInfo.DeviceManager.App.Services;
using MxInfo.DeviceManager.Domain.Models;

namespace MxInfo.DeviceManager.App.Components.Pages;

public partial class Devices(IDeviceApiClient deviceApiClient) : ComponentBase
{
    public List<DeviceModel>? DeviceList { get; set; } = null!;
    
    protected override async Task OnInitializedAsync()
    {
        DeviceList = await deviceApiClient.GetDevicesAsync().ConfigureAwait(false);
    }
}