namespace MxInfo.DeviceManager.Tests.Contracts.Models;

public class PublishConfigurationRequest
{
    public Guid PublisherId { get; set; }
    
    public int Version { get; set; }
}