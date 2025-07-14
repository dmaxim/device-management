
using MxInfo.DeviceManager.AppDependencies.VoteApp;

var builder = DistributedApplication.CreateBuilder(args);

var agentApi = builder.AddProject<Projects.MxInfo_DeviceManager_Agent_Api>("agentApi");

var deviceConfigApi = builder.AddProject<Projects.MxInfo_DeviceManager_Config_Api>("deviceConfigApi")
    //  .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

var deviceManagerApi = builder.AddProject<Projects.MxInfo_DeviceManager_Api>("deviceManagerApi")
    .WithReference(deviceConfigApi)
    .WithReference(agentApi);

builder.AddProject<Projects.MxInfo_DeviceManager_App>("deviceManagerApp")
    //.WithReference(agentApi)
    .WithReference(deviceManagerApi)
    .WaitFor(deviceManagerApi)
    //  .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();
    
builder.AddNpmApp("react", "../MxInfo.DeviceManager.UI", "start")
    .WithReference(deviceManagerApi)
    .WaitFor(deviceManagerApi)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

//builder.AddDockerfile()
//builder.AddProject()

builder.AddVoteApp("voteApp", 8080);
    
builder.Build().Run();