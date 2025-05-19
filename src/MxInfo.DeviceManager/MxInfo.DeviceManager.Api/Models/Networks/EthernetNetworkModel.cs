using MxInfo.DeviceManager.Domain.Models;

namespace MxInfo.DeviceManager.Api.Models.Networks;

public class EthernetNetworkModel(EthernetNetwork network)
{
    public int Id { get; set; } = network.Id;
    public string Name { get; set; } = network.Name;
    public string Description { get; set; } = network.Description;
    public Guid Uid { get; set; } = network.Uid;
}