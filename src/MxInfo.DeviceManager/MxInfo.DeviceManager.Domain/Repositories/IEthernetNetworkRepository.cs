using Mx.EntityFramework.Contracts;
using MxInfo.DeviceManager.Domain.Models;

namespace MxInfo.DeviceManager.Domain.Repositories;

public interface IEthernetNetworkRepository : IRepository<EthernetNetwork>
{
    Task<EthernetNetwork> GetById(int id);
}