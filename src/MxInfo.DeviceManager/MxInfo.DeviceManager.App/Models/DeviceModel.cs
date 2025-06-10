namespace MxInfo.DeviceManager.App.Models;

public class DeviceModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid Uid { get; set; }
}