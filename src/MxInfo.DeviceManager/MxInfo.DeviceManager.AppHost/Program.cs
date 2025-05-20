var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.MxInfo_DeviceManager_Api>("deviceManagerApi");
    
    
builder.Build().Run();