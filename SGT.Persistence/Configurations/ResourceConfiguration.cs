using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGT.Domain.Entities;

public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
{
    public void Configure(EntityTypeBuilder<Resource> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Title).IsRequired().HasMaxLength(200);
        builder.Property(r => r.Url).IsRequired().HasMaxLength(500);
        builder.Property(r => r.Type).IsRequired();
        builder.Property(r => r.CreatedDate).IsRequired();
        builder.HasOne(r => r.AddedBy)
            .WithMany()
            .HasForeignKey(r => r.AddedById)
            .OnDelete(DeleteBehavior.Cascade);
    }
}