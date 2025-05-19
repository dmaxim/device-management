using MxInfo.DeviceManager.Business.Commands;
using MxInfo.DeviceManager.Domain.Models;

namespace MxInfo.DeviceManager.Business.Managers;


/// <summary>
/// Contract for device management.
/// </summary>
public interface IDeviceManager
{
    Task<IList<Device>> GetAll();
    
    Task<Device> GetById(int id);
    
    Task Create(CreateDeviceCommand command);
}