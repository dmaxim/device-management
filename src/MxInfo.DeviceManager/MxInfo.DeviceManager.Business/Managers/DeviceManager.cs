using Microsoft.EntityFrameworkCore;
using MxInfo.DeviceManager.Business.Commands;
using MxInfo.DeviceManager.Domain.Models;
using MxInfo.DeviceManager.Domain.Repositories;

namespace MxInfo.DeviceManager.Business.Managers;

/// <summary>
/// DeviceManager implementation of IDeviceManager.
/// </summary>
public class DeviceManager(IDeviceRepository deviceRepository) : IDeviceManager
{
    public async Task<IList<Device>> GetAll()
    {
        return await deviceRepository.GetAll().ToListAsync();
    }

    public async Task<Device> GetById(int id)
    {
        return await deviceRepository.GetById(id);
    }

    public async Task Create(CreateDeviceCommand command)
    {
        deviceRepository.Insert(new Device
        {
            Name = command.Name,
            Description = command.Description,
            Uid = command.Uid,
        });
        
        await deviceRepository.SaveChangesAsync().ConfigureAwait(false);
    }
}