using HealthBookingAPI.Application.Common.Interfaces;

namespace HealthBookingAPI.Application.CQRS.Appointments.Commands.CreateAppointments;

internal class CreateAppointmentsValidator : AbstractValidator<CreateAppointmentsCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateAppointmentsValidator(IApplicationDbContext context)
    {
        _context = context;
    }
}
