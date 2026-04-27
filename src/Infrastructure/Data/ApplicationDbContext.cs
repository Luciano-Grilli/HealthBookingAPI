using System.Reflection;
using HealthBookingAPI.Application.Common.Interfaces;
using HealthBookingAPI.Domain.Entities;
using HealthBookingAPI.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthBookingAPI.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Professionals> Professionals => Set<Professionals>();

    public DbSet<Categories> Categories => Set<Categories>();

    public DbSet<Appointments> Appointments => Set<Appointments>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
