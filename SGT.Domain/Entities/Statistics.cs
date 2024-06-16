using SGT.Domain.Entities.Common;

namespace SGT.Domain.Entities;

public class Statistics : BaseEntity
{
    public int BlogViews { get; set; }
    public int VideoViews { get; set; }
    public int TotalUsers { get; set; }
    public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
}