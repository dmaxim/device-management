using Mx.EntityFramework.Repositories;
using MxInfo.DeviceManager.Data.Contexts;
using MxInfo.DeviceManager.Domain.Models;
using MxInfo.DeviceManager.Domain.Repositories;

namespace MxInfo.DeviceManager.Data.Repositories;

/// <summary>
/// Implementation of the device repository.
/// </summary>
public class DeviceRepository(IDeviceManagerEntityContext entityContext) : Repository<Device>(entityContext), IDeviceRepository;