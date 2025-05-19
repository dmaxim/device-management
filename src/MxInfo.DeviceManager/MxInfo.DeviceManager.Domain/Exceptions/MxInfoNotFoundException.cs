namespace MxInfo.DeviceManager.Domain.Exceptions;


/// <summary>
/// Exception thrown when the requested resource is not found
/// </summary>
public class MxInfoNotFoundException : MxInfoBaseException
{
    public MxInfoNotFoundException(string message) : base(message) { }
    public MxInfoNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    
    public override int Status { get; } = 404;
}