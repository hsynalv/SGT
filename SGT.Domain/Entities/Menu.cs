using SGT.Domain.Entities;
using SGT.Domain.Entities.Common;

public class Menu : BaseEntity
{
    public string Name { get; set; }

    public ICollection<Endpoint> Endpoints { get; set; }
}