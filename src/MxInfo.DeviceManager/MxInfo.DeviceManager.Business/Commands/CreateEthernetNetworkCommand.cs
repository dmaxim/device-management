namespace MxInfo.DeviceManager.Business.Commands;

public class CreateEthernetNetworkCommand(string name, string description)
{
    public string Name { get; init; } = name;
    public string Description { get; init; } = description;
    public Guid Id { get; init; } = Guid.NewGuid();
}