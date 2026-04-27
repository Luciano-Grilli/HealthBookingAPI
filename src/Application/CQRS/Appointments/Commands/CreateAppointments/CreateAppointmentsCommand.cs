using HealthBookingAPI.Application.Common.Interfaces;

namespace HealthBookingAPI.Application.CQRS.Appointments.Commands.CreateAppointments;

public class CreateAppointmentsCommand : IRequest<Guid>
{
    public Guid PatientId { get; set; }

    public Guid ProfessionalId { get; set; }

    public DateTime Date { get; set; }
}

public class CreateAppointmentsHandler(IApplicationDbContext _context) : IRequestHandler<CreateAppointmentsCommand, Guid>
{
    public async Task<Guid> Handle(CreateAppointmentsCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Appointments
        {
            Date = request.Date,
            PatientId = request.PatientId,
            ProfessionalId = request.ProfessionalId,
        };

        _context.Appointments.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
