using HealthBookingAPI.Application.Common.Interfaces;

namespace HealthBookingAPI.Application.CQRS.Appointments.Commands.UpdateAppointments;

public class UpdateAppointmentsValidator : AbstractValidator<UpdateAppointmentsCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateAppointmentsValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Status)
            .NotEmpty()
            .MaximumLength(30);
    }
}
