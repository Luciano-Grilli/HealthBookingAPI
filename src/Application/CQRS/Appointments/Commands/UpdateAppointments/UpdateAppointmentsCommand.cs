using HealthBookingAPI.Application.Common.Interfaces;

namespace HealthBookingAPI.Application.CQRS.Appointments.Commands.UpdateAppointments;

public class UpdateAppointmentsCommand : IRequest<Guid>
{
    public Guid Id { get; set; }

    public string Status { get; init; } = string.Empty;
}

public class UpdateAppointmentsHandler(IApplicationDbContext _context) : IRequestHandler<UpdateAppointmentsCommand, Guid>
{
    public async Task<Guid> Handle(UpdateAppointmentsCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Appointments
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Status = request.Status;

        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
