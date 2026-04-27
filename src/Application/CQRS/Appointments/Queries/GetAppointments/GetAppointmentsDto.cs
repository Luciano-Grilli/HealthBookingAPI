namespace HealthBookingAPI.Application.CQRS.Appointments.Queries.GetAppointments;

public class GetAppointmentsDto
{
    public Guid PatientId { get; set; }

    public Guid ProfessionalId { get; set; }

    public DateTime Date { get; set; }

    public string Status { get; set; } = string.Empty;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.Appointments, GetAppointmentsDto>();
        }
    }
}
