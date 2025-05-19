using Microsoft.EntityFrameworkCore;
using Mx.EntityFramework.Repositories;
using MxInfo.DeviceManager.Data.Contexts;
using MxInfo.DeviceManager.Domain.Exceptions;
using MxInfo.DeviceManager.Domain.Models;
using MxInfo.DeviceManager.Domain.Repositories;

namespace MxInfo.DeviceManager.Data.Repositories;

/// <summary>
/// Implementation of the ethernet network repository.
/// </summary>
public class EthernetNetworkRepository(IDeviceManagerEntityContext entityContext) : Repository<EthernetNetwork>(entityContext), IEthernetNetworkRepository
{
    public async Task<EthernetNetwork> GetById(int id)
    {
        var ethernetNetwork = await GetAll().Where(ethernetNetwork => ethernetNetwork.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
        if (ethernetNetwork == null)
        {
            throw new MxInfoNotFoundException($"EthernetNetwork with id {id} not found.");
        }
        return ethernetNetwork;
        
    }
}