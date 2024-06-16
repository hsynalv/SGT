using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using SGT.Domain.Entities.Common;
using SGT.Domain.Entities.Identity;

namespace SGT.Domain.Entities
{
    public class Announcement : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public AppUser Author { get; set; }
    }
}
