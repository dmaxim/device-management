namespace MxInfo.DeviceManager.Business.Commands;

public class CreateDeviceCommand(string name, string description)
{
    public string Name { get; } = name;
    public string Description { get; } = description;
    public Guid Uid { get; } = Guid.NewGuid();
}