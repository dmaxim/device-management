using Mx.EntityFramework.Contracts;
using MxInfo.DeviceManager.Domain.Models;

namespace MxInfo.DeviceManager.Domain.Repositories;


/// <summary>
/// Contract for the Device repository.
/// </summary>
public interface IDeviceRepository : IRepository<Device>
{
    Task<Device> GetById(int id);
}