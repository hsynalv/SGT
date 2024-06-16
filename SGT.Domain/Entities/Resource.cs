using SGT.Domain.Entities.Common;
using SGT.Domain.Entities.Identity;

namespace SGT.Domain.Entities;

public class Resource : BaseEntity
{
    public string Title { get; set; }
    public string Url { get; set; }
    public ResourceType Type { get; set; }
    public string AddedById { get; set; }
    public AppUser AddedBy { get; set; }
}