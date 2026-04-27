using HealthBookingAPI.Application.Common.Interfaces;

namespace HealthBookingAPI.Application.CQRS.Categories.Commands.DeleteCategories;

public class DeleteCategoriesCommand : IRequest<Guid>
{
    public Guid Id { get; }
}

public class DeleteCategoriesHandler(IApplicationDbContext _context) : IRequestHandler<DeleteCategoriesCommand, Guid>
{
    public async Task<Guid> Handle(DeleteCategoriesCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Categories
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Categories.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
