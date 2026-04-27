using HealthBookingAPI.Application.Common.Interfaces;

namespace HealthBookingAPI.Application.CQRS.Categories.Commands.CreateCategories;

public class CreateCategoriesValidator : AbstractValidator<CreateCategoriesCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoriesValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Description)
            .NotEmpty()
            .MaximumLength(200);
    }
}

