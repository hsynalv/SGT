using SGT.Domain.Entities.Common;
using SGT.Domain.Entities.Identity;

namespace SGT.Domain.Entities;

public class Blog: BaseEntity
{

    public string Title { get; set; }
    public string Content { get; set; }
    public string AuthorId { get; set; }
    public AppUser Author { get; set; }
    public string Slug { get; set; }  // Yeni eklenen alan
    public ICollection<Tag> Tags { get; set; }  // Yeni eklenen alan
    public ICollection<Comment> Comments { get; set; }  // Yeni eklenen alan
}