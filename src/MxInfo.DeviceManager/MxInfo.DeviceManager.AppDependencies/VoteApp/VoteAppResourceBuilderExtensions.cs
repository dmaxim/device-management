using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;

namespace MxInfo.DeviceManager.AppDependencies.VoteApp;

public static class VoteAppResourceBuilderExtensions
{
    public static IResourceBuilder<VoteAppResource> AddVoteApp(
        this IDistributedApplicationBuilder builder,
        string name,
        int? httpPort = null)
    {
        var resource = new VoteAppResource(name);
        return builder.AddResource(resource)
            .WithImage(VoteAppImageTags.Image, VoteAppImageTags.Tag)
            .WithImageRegistry(VoteAppImageTags.Registry)
            .WithHttpEndpoint(
                targetPort: 8080,
                port: httpPort,
                name: VoteAppResource.HttpEndpointName)
            .WithExternalHttpEndpoints();
    }
}