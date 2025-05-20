using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MxInfo.DeviceManager.Domain.Models;

namespace MxInfo.DeviceManager.Data.Contexts;

/// <summary>
/// Configuration for the WifeNetwork entity
/// </summary>
public class WifiNetworkEntityConfiguration : IEntityTypeConfiguration<WifiNetwork>
{
    public void Configure(EntityTypeBuilder<WifiNetwork> builder)
    {
        builder.ToTable(DataResources.WifiNetworkTable, DataResources.DefaultSchema);
        
        builder.Property(properties => properties.Id)
            .HasColumnName("WifiNetworkId");

        builder.Property(properties => properties.Name)
            .HasColumnName("WifiNetworkName")
            .IsUnicode(false);
            
        builder.Property(properties => properties.Description)
            .HasColumnName("WifiNetworkDescription")
            .IsUnicode(false);
        
        builder.Property(properties => properties.Uid)
            .HasColumnName("WifiNetworkUid");
    }
}