using HealthBookingAPI.Domain.Entities;

namespace HealthBookingAPI.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Professionals> Professionals { get; }

    DbSet<Categories> Categories { get; }

    DbSet<Appointments> Appointments { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
