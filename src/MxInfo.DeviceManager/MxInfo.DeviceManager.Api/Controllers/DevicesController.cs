using Microsoft.AspNetCore.Mvc;
using MxInfo.DeviceManager.Api.Models.Devices;
using MxInfo.DeviceManager.Api.Services;
using MxInfo.DeviceManager.Business.Commands;
using MxInfo.DeviceManager.Business.Managers;

namespace MxInfo.DeviceManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DevicesController(IDeviceManager deviceManager, IAgentClient agentClient): ControllerBase
{

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IList<DeviceModel>> GetAll()
    {
        //_ = await agentClient.GetMessageAsync().ConfigureAwait(false);
        var devices = await deviceManager.GetAll().ConfigureAwait(false);
        return devices.Select(device => new DeviceModel(device)).ToList();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] CreateDeviceModel model)
    {
        await deviceManager.Create(new CreateDeviceCommand(model.Name, model.Description)).ConfigureAwait(false);

        return Created();
    }
}