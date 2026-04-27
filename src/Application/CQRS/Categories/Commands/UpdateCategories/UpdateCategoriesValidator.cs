using HealthBookingAPI.Application.Common.Interfaces;

namespace HealthBookingAPI.Application.CQRS.Categories.Commands.UpdateCategories;

public class UpdateCategoriesValidator : AbstractValidator<UpdateCategoriesCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoriesValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Description)
            .NotEmpty()
            .MaximumLength(200);
    }
}
