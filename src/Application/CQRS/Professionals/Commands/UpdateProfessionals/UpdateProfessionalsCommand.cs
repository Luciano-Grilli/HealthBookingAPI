using HealthBookingAPI.Application.Common.Interfaces;

namespace HealthBookingAPI.Application.CQRS.Professionals.Commands.UpdateProfessionals;

public class UpdateProfessionalsCommand : IRequest<Guid>
{
    public Guid Id { get; set; }

    public string Description { get; init; } = string.Empty;

    public Guid CategoryId { get; init; }
}

public class UpdateProfessionalsHandler(IApplicationDbContext _context) : IRequestHandler<UpdateProfessionalsCommand, Guid>
{
    public async Task<Guid> Handle(UpdateProfessionalsCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Professionals
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Description = request.Description;
        entity.CategoryId = request.CategoryId;

        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
