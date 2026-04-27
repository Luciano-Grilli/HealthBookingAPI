using HealthBookingAPI.Domain.Entities;
using HealthBookingAPI.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthBookingAPI.Infrastructure.Data.Configurations;

public class AppointmentsConfiguration : IEntityTypeConfiguration<Appointments>
{
    public void Configure(EntityTypeBuilder<Appointments> builder)
    {
        builder.HasOne(p => p.Professional)
            .WithMany(c => c.ProfessionalsAppointments)
            .HasForeignKey(p => p.ProfessionalId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(p => p.PatientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
