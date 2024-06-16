using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGT.Domain.Entities;

public class PracticalInfoConfiguration : IEntityTypeConfiguration<PracticalInfo>
{
    public void Configure(EntityTypeBuilder<PracticalInfo> builder)
    {
        builder.HasKey(pi => pi.Id);
        builder.Property(pi => pi.Title).IsRequired().HasMaxLength(200);
        builder.Property(pi => pi.Content).IsRequired();
        builder.Property(pi => pi.CreatedDate).IsRequired();
        builder.HasOne(pi => pi.Author)
            .WithMany()
            .HasForeignKey(pi => pi.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}