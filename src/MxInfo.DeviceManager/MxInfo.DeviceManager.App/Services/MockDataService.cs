using MxInfo.DeviceManager.Domain.Models;

namespace MxInfo.DeviceManager.App.Services;

public class MockDataService
{
    private static List<Device>? _devices;

    public static List<Device> Devices
    {
        get
        {
            _devices = InitializeMockDevices();
            return _devices;
        }
    }
    
    private static List<Device> InitializeMockDevices()
    {
        var d1 = new Device
        {
            Id = 1,
            Name = "Device1",
            Description = "Device One",
            Uid = Guid.NewGuid()
        };

        var d2 = new Device
        {
            Id = 2,
            Name = "Device 2",
            Description = "Device Two",
            Uid = Guid.NewGuid()
        };

        return [d1, d2];
    }
}