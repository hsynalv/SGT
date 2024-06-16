using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SGT.Domain.Entities;
using System.Reflection;
using SGT.Domain.Entities.Identity;

namespace SGT.Persistence.Context
{
    public class SGT_APIDbContext : IdentityDbContext<AppUser,AppRole, string>
    {
        public SGT_APIDbContext(DbContextOptions<SGT_APIDbContext> options)
            : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<PracticalInfo> PracticalInfos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Statistics> Statistics { get; set; }
        public DbSet<CommunityInfo> CommunityInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Assembly'deki tüm IEntityTypeConfiguration implementasyonlarını uygula
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
