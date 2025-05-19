using Mx.EntityFramework.Repositories;
using MxInfo.DeviceManager.Data.Contexts;
using MxInfo.DeviceManager.Domain.Models;
using MxInfo.DeviceManager.Domain.Repositories;

namespace MxInfo.DeviceManager.Data.Repositories;

/// <summary>
/// Implementation of the ethernet network repository.
/// </summary>
public class EthernetNetworkRepository(IDeviceManagerEntityContext entityContext) : Repository<EthernetNetwork>(entityContext), IEthernetNetworkRepository;