using SunbedSaaS.Core.Common;

namespace SunbedSaaS.Core.Entities;

public class Asset : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

    public Guid OrganizationId { get; set; }
    public Organization Organization { get; set; } = null!;
}