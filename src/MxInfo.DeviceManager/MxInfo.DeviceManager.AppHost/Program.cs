var builder = DistributedApplication.CreateBuilder(args);

var deviceManagerApi = builder.AddProject<Projects.MxInfo_DeviceManager_Api>("deviceManagerApi");
    
builder.AddNpmApp("react", "../MxInfo.DeviceManager.UI", "start")
    .WithReference(deviceManagerApi)
    .WaitFor(deviceManagerApi)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();