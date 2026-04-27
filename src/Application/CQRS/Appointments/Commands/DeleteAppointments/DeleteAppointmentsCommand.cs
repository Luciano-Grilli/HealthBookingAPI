using HealthBookingAPI.Application.Common.Interfaces;

namespace HealthBookingAPI.Application.CQRS.Appointments.Commands.DeleteAppointments;

public class DeleteAppointmentsCommand : IRequest<Guid>
{
    public Guid Id { get; }
}

public class DeleteAppointmentsHandler(IApplicationDbContext _context) : IRequestHandler<DeleteAppointmentsCommand, Guid>
{
    public async Task<Guid> Handle(DeleteAppointmentsCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Appointments
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Appointments.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
