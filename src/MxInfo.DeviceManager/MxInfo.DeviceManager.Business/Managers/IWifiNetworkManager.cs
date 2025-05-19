using MxInfo.DeviceManager.Business.Commands;
using MxInfo.DeviceManager.Domain.Models;

namespace MxInfo.DeviceManager.Business.Managers;

public interface IWifiNetworkManager
{
    public Task<IList<WifiNetwork>> GetAll();
    public Task<WifiNetwork> GetById(int id);
    public Task Create(CreateWifiNetworkCommand wifiNetwork);
}