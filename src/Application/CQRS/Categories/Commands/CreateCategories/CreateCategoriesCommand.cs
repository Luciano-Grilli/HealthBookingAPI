using HealthBookingAPI.Application.Common.Interfaces;

namespace HealthBookingAPI.Application.CQRS.Categories.Commands.CreateCategories;

public class CreateCategoriesCommand : IRequest<Guid>
{
    public string Description { get; init; } = string.Empty;
}

public class CreateCategoriesHandler(IApplicationDbContext _context) : IRequestHandler<CreateCategoriesCommand, Guid>
{
    public async Task<Guid> Handle(CreateCategoriesCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Categories
        {
            Description = request.Description,
        };

        _context.Categories.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
