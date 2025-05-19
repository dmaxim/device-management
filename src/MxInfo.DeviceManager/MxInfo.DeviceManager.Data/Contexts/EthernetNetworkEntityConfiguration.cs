using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MxInfo.DeviceManager.Domain.Models;

namespace MxInfo.DeviceManager.Data.Contexts;

/// <summary>
/// Configuration for the Ethernet Network entity
/// </summary>
public class EthernetNetworkEntityConfiguration : IEntityTypeConfiguration<EthernetNetwork>
{
    public void Configure(EntityTypeBuilder<EthernetNetwork> builder)
    {
        builder.ToTable(DataResources.EthernetNetworkTable, DataResources.DefaultSchema);
        
        builder.Property(properties => properties.Id)
            .HasColumnName("EthernetNetworkId");

        builder.Property(properties => properties.Name)
            .HasColumnName("EthernetNetworkName")
            .IsUnicode(false);
            
        builder.Property(properties => properties.Description)
            .HasColumnName("EthernetNetworkDescription")
            .IsUnicode(false);
    }
}