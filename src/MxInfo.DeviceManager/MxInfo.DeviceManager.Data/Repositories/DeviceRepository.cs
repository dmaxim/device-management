using Microsoft.EntityFrameworkCore;
using Mx.EntityFramework.Repositories;
using MxInfo.DeviceManager.Data.Contexts;
using MxInfo.DeviceManager.Domain.Exceptions;
using MxInfo.DeviceManager.Domain.Models;
using MxInfo.DeviceManager.Domain.Repositories;

namespace MxInfo.DeviceManager.Data.Repositories;

/// <summary>
/// Implementation of the device repository.
/// </summary>
public class DeviceRepository(IDeviceManagerEntityContext entityContext) : Repository<Device>(entityContext), IDeviceRepository
{
    public async Task<Device> GetById(int id)
    {
        var device = await GetAll().Where(device => device.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
        if(device == null)
        {
            throw new MxInfoNotFoundException($"Device with id {id} not found.");
        }
        return device;
        
    }
}