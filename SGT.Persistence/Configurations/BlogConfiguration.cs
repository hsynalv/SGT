using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGT.Domain.Entities;

namespace SGT.Persistence.Configurations
{

    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title).IsRequired().HasMaxLength(200);
            builder.Property(b => b.Content).IsRequired();
            builder.Property(b => b.Slug).IsRequired().HasMaxLength(200);
            builder.HasOne(b => b.Author)
                .WithMany()
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(b => b.Tags)
                .WithMany(t => t.Blogs)
                .UsingEntity(j => j.ToTable("BlogTags"));
            builder.HasMany(b => b.Comments)
                .WithOne(c => c.Blog)
                .HasForeignKey(c => c.BlogId)
                .OnDelete(DeleteBehavior.NoAction); // Cascade delete'i tamamen devre dışı bırak
        }
    }

}