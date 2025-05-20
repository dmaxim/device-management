using Microsoft.AspNetCore.Mvc;
using MxInfo.DeviceManager.Api.Models.Networks;
using MxInfo.DeviceManager.Business.Commands;
using MxInfo.DeviceManager.Business.Managers;

namespace MxInfo.DeviceManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EthernetNetworksController(IEthernetNetworkManager ethernetNetworkManager) : ControllerBase
{
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IList<EthernetNetworkModel>> GetAll()
    {
        var networks = await ethernetNetworkManager.GetAll().ConfigureAwait(false);
        return networks.Select(network => new EthernetNetworkModel(network)).ToList();
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] CreateEthernetNetworkModel model)
    {
        await ethernetNetworkManager.Create(new CreateEthernetNetworkCommand(model.Name, model.Description)).ConfigureAwait(false);
        return Created();
    }
}