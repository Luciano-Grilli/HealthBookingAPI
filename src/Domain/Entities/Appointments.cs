
namespace HealthBookingAPI.Domain.Entities;

public class Appointments : BaseAuditableEntity
{
    public Guid PatientId { get; set; }

    public Guid ProfessionalId { get; set; }

    public Professionals Professional { get; set; } = new Professionals();

    public DateTime Date { get; set; }

    public string Status { get; set; } = string.Empty;
}
