using Microsoft.AspNetCore.Mvc;
using MxInfo.DeviceManager.Api.Models.Networks;
using MxInfo.DeviceManager.Business.Commands;
using MxInfo.DeviceManager.Business.Managers;

namespace MxInfo.DeviceManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WifiNetworkController(IWifiNetworkManager wifiNetworkManager) : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IList<WifiNetworkModel>> GetAll()
        {
            var networks = await wifiNetworkManager.GetAll().ConfigureAwait(false);
            return networks.Select(network => new WifiNetworkModel(network)).ToList();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateWifiNetworkModel model)
        {
            await wifiNetworkManager.Create(new CreateWifiNetworkCommand(model.Name, model.Description))
                .ConfigureAwait(false);
            return Created();
        }
    }
}
