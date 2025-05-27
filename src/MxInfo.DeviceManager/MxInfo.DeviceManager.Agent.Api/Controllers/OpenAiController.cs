using Microsoft.AspNetCore.Mvc;
using MxInfo.DeviceManager.Agent.Business.Managers;


namespace MxInfo.DeviceManager.Agent.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OpenAiController(IOpenAiManager openAiManager) : ControllerBase
{
    [HttpGet(Name = "GetResponse")]
    public async Task<IActionResult> Get()
    {
        return Ok(await openAiManager.GetMessage());
    }
}