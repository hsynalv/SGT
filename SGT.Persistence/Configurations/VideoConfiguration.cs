using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGT.Domain.Entities;

public class VideoConfiguration : IEntityTypeConfiguration<Video>
{
    public void Configure(EntityTypeBuilder<Video> builder)
    {
        builder.HasKey(v => v.Id);
        builder.Property(v => v.Title).IsRequired().HasMaxLength(200);
        builder.Property(v => v.Url).IsRequired().HasMaxLength(500);
        builder.HasOne(v => v.AddedBy)
            .WithMany()
            .HasForeignKey(v => v.AddedById)
            .OnDelete(DeleteBehavior.Cascade);
    }
}