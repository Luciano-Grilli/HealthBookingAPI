
namespace HealthBookingAPI.Domain.Entities;

public class Professionals : BaseAuditableEntity
{
    public string Description { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    public Guid CategoryId { get; set; }

    public Categories Categories { get; set; } = null!;

    public bool IsActive { get; set; }

    public ICollection<Appointments> ProfessionalsAppointments { get; set; } = new List<Appointments>();
}
