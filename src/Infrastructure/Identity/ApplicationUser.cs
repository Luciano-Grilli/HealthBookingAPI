using HealthBookingAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace HealthBookingAPI.Infrastructure.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public Professionals? Professional { get; set; }

    public ICollection<Appointments> UserAppointments { get; set; } = new List<Appointments>();

}
