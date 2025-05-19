using Mx.EntityFramework.Repositories;
using MxInfo.DeviceManager.Data.Contexts;
using MxInfo.DeviceManager.Domain.Models;
using MxInfo.DeviceManager.Domain.Repositories;

namespace MxInfo.DeviceManager.Data.Repositories;

/// <summary>
/// Implementation of the wifi network repository.
/// </summary>
public class WifiNetworkRepository(IDeviceManagerEntityContext entityContext) : Repository<WifiNetwork>(entityContext), IWifiNetworkRepository;