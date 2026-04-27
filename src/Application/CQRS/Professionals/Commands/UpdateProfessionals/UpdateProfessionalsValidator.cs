using HealthBookingAPI.Application.Common.Interfaces;

namespace HealthBookingAPI.Application.CQRS.Professionals.Commands.UpdateProfessionals;

public class UpdateProfessionalsValidator : AbstractValidator<UpdateProfessionalsCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateProfessionalsValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Description)
            .NotEmpty()
            .MaximumLength(200);
    }
}
