using Microsoft.AspNetCore.Components;
using MxInfo.DeviceManager.App.Services;
using MxInfo.DeviceManager.Domain.Models;

namespace MxInfo.DeviceManager.App.Components.Pages;

public partial class Devices : ComponentBase
{
    public List<Device>? DeviceList { get; set; } = null!;
    
    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(2000);
        DeviceList = MockDataService.Devices;
    }
}