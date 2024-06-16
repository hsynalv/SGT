using SGT.Domain.Entities.Common;
using SGT.Domain.Entities.Identity;

namespace SGT.Domain.Entities;

public class PracticalInfo : BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string AuthorId { get; set; }
    public AppUser Author { get; set; }
}