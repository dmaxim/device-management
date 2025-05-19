using Microsoft.EntityFrameworkCore;
using MxInfo.DeviceManager.Business.Commands;
using MxInfo.DeviceManager.Domain.Models;
using MxInfo.DeviceManager.Domain.Repositories;

namespace MxInfo.DeviceManager.Business.Managers;

public class WifiNetworkManager(IWifiNetworkRepository wifiNetworkRepository) : IWifiNetworkManager
{
    public async Task<IList<WifiNetwork>> GetAll()
    {
        return await wifiNetworkRepository.GetAll().ToListAsync().ConfigureAwait(false);
    }

    public async Task<WifiNetwork> GetById(int id)
    {
        return await wifiNetworkRepository.GetById(id).ConfigureAwait(false);
    }

    public async Task Create(CreateWifiNetworkCommand wifiNetwork)
    {
        wifiNetworkRepository.Insert(new WifiNetwork
        {
            Name = wifiNetwork.Name,
            Description = wifiNetwork.Description,
        });
        await wifiNetworkRepository.SaveChangesAsync().ConfigureAwait(false);
    }
}