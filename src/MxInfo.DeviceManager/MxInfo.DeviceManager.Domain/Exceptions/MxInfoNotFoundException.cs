namespace MxInfo.DeviceManager.Domain.Exceptions;


/// <summary>
/// Exception thrown when the requested resource is not found
/// </summary>
public class MxInfoNotFoundException : MxInfoBaseException
{
    public override int Status { get; } = 404;
}