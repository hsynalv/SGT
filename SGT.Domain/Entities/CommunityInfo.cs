using SGT.Domain.Entities.Common;

namespace SGT.Domain.Entities;

public class CommunityInfo : BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
}