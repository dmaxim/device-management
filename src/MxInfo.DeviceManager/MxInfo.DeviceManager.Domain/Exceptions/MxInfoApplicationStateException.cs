namespace MxInfo.DeviceManager.Domain.Exceptions;

/// <summary>
/// Application Exception thrown when the application is in an invalid state
/// </summary>
public class MxInfoApplicationStateException : MxInfoBaseException
{
    public MxInfoApplicationStateException(string message) : base(message) { }
    public MxInfoApplicationStateException(string message, Exception innerException) : base(message, innerException) { }
    
    public override int Status { get; } = 500;
}