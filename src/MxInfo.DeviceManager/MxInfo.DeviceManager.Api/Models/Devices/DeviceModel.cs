using MxInfo.DeviceManager.Domain.Models;

namespace MxInfo.DeviceManager.Api.Models.Devices;

public class DeviceModel(Device device)
{
    public int Id { get; set; } = device.Id;
    public string Name { get; set; } = device.Name;
    public string Description { get; set; } = device.Description;
    public Guid Uid { get; set; } = device.Uid;
}