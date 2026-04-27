
namespace HealthBookingAPI.Domain.Entities;

public class Categories : BaseAuditableEntity
{
    public string Description { get; set; } = string.Empty;

    public ICollection<Professionals> CategoriesProfessionals { get; set; } = new List<Professionals>();
}
