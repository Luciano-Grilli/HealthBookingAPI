using HealthBookingAPI.Application.Common.Interfaces;

namespace HealthBookingAPI.Application.CQRS.Professionals.Commands.CreateProfessionals;

public class CreateProfessionalsCommand : IRequest<Guid>
{
    public string Description { get; init; } = string.Empty;

    public Guid? CategoryId { get; init; }

    public Guid? UserId { get; init; }
}

public class CreateProfessionalsHandler(IApplicationDbContext _context) : IRequestHandler<CreateProfessionalsCommand, Guid>
{
    public async Task<Guid> Handle(CreateProfessionalsCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Professionals
        {
            Description = request.Description,
            UserId = request.UserId ?? Guid.Empty,
            CategoryId = request.CategoryId ?? Guid.Empty,
        };

        _context.Professionals.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
