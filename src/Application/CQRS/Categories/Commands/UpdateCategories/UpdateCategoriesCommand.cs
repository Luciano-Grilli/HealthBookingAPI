using HealthBookingAPI.Application.Common.Interfaces;

namespace HealthBookingAPI.Application.CQRS.Categories.Commands.UpdateCategories;

public class UpdateCategoriesCommand : IRequest<Guid>
{
    public Guid Id { get; set; }

    public string Description { get; init; } = string.Empty;
}

public class UpdateCategoriesHandler(IApplicationDbContext _context) : IRequestHandler<UpdateCategoriesCommand, Guid>
{
    public async Task<Guid> Handle(UpdateCategoriesCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Categories
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
