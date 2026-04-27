
namespace HealthBookingAPI.Application.CQRS.Professionals.Queries.GetProfessionals;

public class GetProfessionalsDto
{
    public string Description { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    public Guid CategoryId { get; set; }

    public bool IsActive { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.Professionals, GetProfessionalsDto>();
        }
    }
}
