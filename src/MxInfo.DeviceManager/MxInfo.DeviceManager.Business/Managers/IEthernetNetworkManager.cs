using MxInfo.DeviceManager.Business.Commands;
using MxInfo.DeviceManager.Domain.Models;

namespace MxInfo.DeviceManager.Business.Managers;

public interface IEthernetNetworkManager
{
    Task<IList<EthernetNetwork>> GetAll();
    
    Task<EthernetNetwork> GetById(int id);
    
    Task Create(CreateEthernetNetworkCommand ethernetNetwork);
}