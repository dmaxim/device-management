using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace MxInfo.DeviceManager.Data.Contexts;

/// <summary>
/// Entity Framework Core DbContext for DeviceManager
/// </summary>
public class DeviceManagerEntityContext : DbContext, IDeviceManagerEntityContext
{
    public DbContext Context => this;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());

    }
    
}