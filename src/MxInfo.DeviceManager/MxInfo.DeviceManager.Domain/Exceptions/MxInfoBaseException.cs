namespace MxInfo.DeviceManager.Domain.Exceptions;

/// Base exception for all MxInfo exceptions
public abstract class MxInfoBaseException : SystemException
{
    protected MxInfoBaseException(string message) : base(message) { }
    
    protected MxInfoBaseException() : base() { }
    
    protected MxInfoBaseException(string message, Exception innerException) : base(message, innerException) { }
    
    public abstract int Status
    {
        get; 
    }
}