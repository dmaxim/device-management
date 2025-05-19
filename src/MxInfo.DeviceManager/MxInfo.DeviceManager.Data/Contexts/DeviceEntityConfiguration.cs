using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MxInfo.DeviceManager.Domain.Models;

namespace MxInfo.DeviceManager.Data.Contexts;

/// <summary>
/// Configure mapping of Device entity to the database schema
/// </summary>
public class DeviceEntityConfiguration: IEntityTypeConfiguration<Device>
{
    public void Configure(EntityTypeBuilder<Device> builder)
    {
        builder.ToTable(DataResources.DefaultSchema, DataResources.DefaultSchema);
        
        builder.Property(properties => properties.Id)
            .HasColumnName("DeviceId");

        builder.Property(properties => properties.Name)
            .HasColumnName("DeviceName")
            .IsUnicode(false);
        
        builder.Property(properties => properties.Description)
            .HasColumnName("DeviceDescription")
            .IsUnicode(false);

        builder.Property(properties => properties.Uid)
            .HasColumnName("DeviceUid");



    }
}