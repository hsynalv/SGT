using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGT.Domain.Entities.Identity;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(u => u.NameSurname).IsRequired().HasMaxLength(100);
        builder.Property(u => u.ProfilePicture).HasMaxLength(500);
        builder.Property(u => u.Bio).HasMaxLength(1000);
    }
}