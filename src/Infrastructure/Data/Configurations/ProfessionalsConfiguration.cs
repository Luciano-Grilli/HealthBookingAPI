using HealthBookingAPI.Domain.Entities;
using HealthBookingAPI.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthBookingAPI.Infrastructure.Data.Configurations;

public class ProfessionalsConfiguration : IEntityTypeConfiguration<Professionals>
{
    public void Configure(EntityTypeBuilder<Professionals> builder)
    {
        builder.HasOne<ApplicationUser>()
            .WithOne()
            .HasForeignKey<Professionals>(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(p => p.UserId)
            .IsUnique();

        builder.HasOne(p => p.Categories)
            .WithMany(c => c.CategoriesProfessionals)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
