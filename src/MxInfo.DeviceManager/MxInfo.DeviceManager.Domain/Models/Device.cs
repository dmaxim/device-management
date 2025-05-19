using System.ComponentModel.DataAnnotations;

namespace MxInfo.DeviceManager.Domain.Models;

/// <summary>
/// Device Model
/// </summary>
public class Device
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    [StringLength(255)]
    public string Description { get; set; } = string.Empty;
    [Required]
    public Guid Uid { get; set; } = Guid.NewGuid();
    
}