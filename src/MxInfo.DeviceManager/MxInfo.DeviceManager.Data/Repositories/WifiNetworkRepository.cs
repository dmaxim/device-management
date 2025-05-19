using Microsoft.EntityFrameworkCore;
using Mx.EntityFramework.Repositories;
using MxInfo.DeviceManager.Data.Contexts;
using MxInfo.DeviceManager.Domain.Exceptions;
using MxInfo.DeviceManager.Domain.Models;
using MxInfo.DeviceManager.Domain.Repositories;

namespace MxInfo.DeviceManager.Data.Repositories;

/// <summary>
/// Implementation of the wifi network repository.
/// </summary>
public class WifiNetworkRepository(IDeviceManagerEntityContext entityContext) : Repository<WifiNetwork>(entityContext), IWifiNetworkRepository
{
    public async Task<WifiNetwork> GetById(int id)
    {
        var wifiNetwork = await GetAll().Where(wifiNetwork => wifiNetwork.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);

        if (wifiNetwork == null)
        {
            throw new MxInfoNotFoundException($"WifiNetwork with id {id} not found.");
        }
        return wifiNetwork;
        
    }
}