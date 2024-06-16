using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGT.Domain.Entities;

public class StatisticsConfiguration : IEntityTypeConfiguration<Statistics>
{
    public void Configure(EntityTypeBuilder<Statistics> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.BlogViews).IsRequired();
        builder.Property(s => s.VideoViews).IsRequired();
        builder.Property(s => s.TotalUsers).IsRequired();
        builder.Property(s => s.UpdatedDate).IsRequired();
    }
}