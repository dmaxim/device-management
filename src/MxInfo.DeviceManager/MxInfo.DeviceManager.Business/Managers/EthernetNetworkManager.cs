using Microsoft.EntityFrameworkCore;
using MxInfo.DeviceManager.Business.Commands;
using MxInfo.DeviceManager.Domain.Models;
using MxInfo.DeviceManager.Domain.Repositories;

namespace MxInfo.DeviceManager.Business.Managers;

public class EthernetNetworkManager(IEthernetNetworkRepository ethernetNetworkRepository) : IEthernetNetworkManager
{
    public async Task<IList<EthernetNetwork>> GetAll()
    {
        return await ethernetNetworkRepository.GetAll().ToListAsync().ConfigureAwait(false);
    }

    public async Task<EthernetNetwork> GetById(int id)
    {
        return await ethernetNetworkRepository.GetById(id).ConfigureAwait(false);
    }

    public async Task Create(CreateEthernetNetworkCommand ethernetNetwork)
    {
        ethernetNetworkRepository.Insert(new EthernetNetwork
        {
            Name = ethernetNetwork.Name,
            Description = ethernetNetwork.Description,
        });
        await ethernetNetworkRepository.SaveChangesAsync().ConfigureAwait(false);
    }
}