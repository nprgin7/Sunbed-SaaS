using SunbedSaaS.Core.Common;

namespace SunbedSaaS.Core.Entities;

public class Organization : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? StripeAccountId { get; set; } 
    public ICollection<Asset> Assets { get; set; } = new List<Asset>();
}