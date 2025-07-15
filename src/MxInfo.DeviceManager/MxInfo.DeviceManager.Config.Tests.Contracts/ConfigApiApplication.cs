using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace MxInfo.DeviceManager.Config.Tests.Contracts;

internal class ConfigApiApplication : WebApplicationFactory<Program>
{

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        Environment.SetEnvironmentVariable("CacheSettings:UseCache", "false");
        
    }
    
}