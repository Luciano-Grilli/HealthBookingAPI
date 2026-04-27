using HealthBookingAPI.Application.Common.Interfaces;

namespace HealthBookingAPI.Application.CQRS.Professionals.Commands.DeleteProfessionals;

public class DeleteProfessionalsCommand: IRequest<Guid>
{
    public Guid Id { get; }
}

public class DeleteProfessionalsHandler(IApplicationDbContext _context) : IRequestHandler<DeleteProfessionalsCommand,Guid>
{
    public async Task<Guid> Handle(DeleteProfessionalsCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Professionals
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Professionals.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}

