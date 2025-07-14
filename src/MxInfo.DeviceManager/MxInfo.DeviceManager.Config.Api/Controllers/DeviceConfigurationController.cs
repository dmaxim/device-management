using Microsoft.AspNetCore.Mvc;

namespace MxInfo.DeviceManager.Config.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DeviceConfigurationController : ControllerBase
{
    [HttpPost("{id:int}", Name="PublishDeviceConfiguration")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Publish(int id, [FromBody] Models.PublishConfiguration configuration)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid device ID.");
        }

        if (configuration.PublisherId == Guid.Empty)
        {
            return BadRequest("Invalid configuration.");
        }

        // Logic to publish the device configuration would go here.
        
        return CreatedAtAction(nameof(Get), new { id }, null);
    }

    
    
    [HttpGet(template: "{id:int}", Name = "GetDeviceConfiguration")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get(int id)
    {
        if(id <= 0)
        {
           return NotFound();
        }

        return Ok();
    }
}