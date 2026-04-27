using HealthBookingAPI.Application.Common.Interfaces;

namespace HealthBookingAPI.Application.CQRS.Professionals.Commands.CreateProfessionals;

public class CreateProfessionalsValidator : AbstractValidator<CreateProfessionalsCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateProfessionalsValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Description)
            .NotEmpty()
            .MaximumLength(200);
    }
}
