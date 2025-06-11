using Aspire.Hosting.ApplicationModel;

namespace MxInfo.DeviceManager.AppDependencies.VoteApp;

public class VoteAppResource(string name): ContainerResource(name)
{

    internal const string HttpEndpointName = "http";
    
}