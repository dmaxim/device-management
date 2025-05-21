using Microsoft.AspNetCore.Mvc;
using MxInfo.DeviceManager.Business.Managers;

namespace MxInfo.DeviceManager.Agent.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OpenAiController(IOpenAiManager openAiManager) : ControllerBase
{
    [HttpGet(Name = "GetResponse")]
    public IActionResult Get()
    {
        return Ok(openAiManager.GetMessage());
    }
}