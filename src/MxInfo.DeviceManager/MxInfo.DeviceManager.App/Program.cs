using MxInfo.DeviceManager.App.Components;
using MxInfo.DeviceManager.App.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();  // Add default services via the extension method from the ServiceDefaults project allowing for service discovery, configuration, and logging.

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDeviceManagerDependencies(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();
app.Run();