using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MxInfo.DeviceManager.Config.Tests.Contracts;

public class TestStartup
{
    private readonly ConfigApiStartup _proxy;

    public TestStartup(IConfiguration configuration)
    {
        _proxy = new ConfigApiStartup(configuration);
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        _proxy.ConfigureServices(services);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
       // app.UseMiddleware<ProviderStateMiddleware>();
       // app.UseMiddleware<AuthTokenRequestFilter>(); 
        _proxy.Configure(app, env);
    }
}