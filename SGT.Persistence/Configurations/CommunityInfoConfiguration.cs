using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGT.Domain.Entities;

public class CommunityInfoConfiguration : IEntityTypeConfiguration<CommunityInfo>
{
    public void Configure(EntityTypeBuilder<CommunityInfo> builder)
    {
        builder.HasKey(ci => ci.Id);
        builder.Property(ci => ci.Title).IsRequired().HasMaxLength(200);
        builder.Property(ci => ci.Content).IsRequired();
        builder.Property(ci => ci.UpdatedDate).IsRequired();
    }
}