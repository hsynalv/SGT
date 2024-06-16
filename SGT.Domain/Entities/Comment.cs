using SGT.Domain.Entities.Common;
using SGT.Domain.Entities.Identity;

namespace SGT.Domain.Entities;

public class Comment : BaseEntity
{
    public string Content { get; set; }
    public string AuthorId { get; set; }
    public AppUser Author { get; set; }
    public Guid BlogId { get; set; }
    public Blog Blog { get; set; }
}