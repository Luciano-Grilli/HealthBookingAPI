using HealthBookingAPI.Application.Common.Interfaces;


namespace HealthBookingAPI.Application.CQRS.Professionals.Queries.GetProfessionals;

public class GetProfessionalsQuery : IRequest<List<GetProfessionalsDto>>;

public class GetProfessionalsHandler(IApplicationDbContext _context, IMapper _mapper) : IRequestHandler<GetProfessionalsQuery, List<GetProfessionalsDto>>
{
    public async Task<List<GetProfessionalsDto>> Handle(GetProfessionalsQuery request, CancellationToken cancellationToken)
    {
        var Lists = await _context.Professionals
                .Include(x => x.Categories)
                .AsNoTracking()
                .ProjectTo<GetProfessionalsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

        return Lists;
    }
}
