using Microsoft.AspNetCore.Mvc;
using MxInfo.DeviceManager.Api.Models.DeviceConfiguration;
using MxInfo.DeviceManager.Api.Services;

namespace MxInfo.DeviceManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DeviceConfigurationController(IConfigurationApiClient configurationApiClient) : ControllerBase
{
    [HttpGet(template: "{id:int}", Name = "GetDeviceConfiguration")]
    public async Task<IActionResult> GetConfiguration(int id)
    {
        var result = await configurationApiClient.GetConfigurationAsync(id).ConfigureAwait(false);
        return Ok();
    }

    [HttpPost(template: "{id:int}", Name = "PublishDeviceConfiguration")]
    public async Task<IActionResult> PublishDeviceConfiguration(int id)
    {
        await configurationApiClient.PublishConfigurationAsync(id, new ConfigurationData
        {
            PublisherId = Guid.NewGuid(),
            Version = 1,
            ConfigurationModel = "Sample Configuration"
        }).ConfigureAwait(false);

        return Ok();
    }
    
    
}