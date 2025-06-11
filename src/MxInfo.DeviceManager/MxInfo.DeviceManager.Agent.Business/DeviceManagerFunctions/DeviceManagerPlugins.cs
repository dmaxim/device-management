using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace MxInfo.DeviceManager.Agent.Business.DeviceManagerFunctions;

public class DeviceManagerPlugins
{
    [KernelFunction]
    [Description("Gets the detailed information about a device based on its serial number.")]
    public string GetDeviceInfo(string serialNumber)
    {
        // Simulate fetching device info
        return $"Device Info for {serialNumber}";
    }
    
}