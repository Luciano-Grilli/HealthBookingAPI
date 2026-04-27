using HealthBookingAPI.Application.Common.Interfaces;


namespace HealthBookingAPI.Application.CQRS.Professionals.Queries.GetProfessionals;

public class GetProfessionalsQuery : IRequest<List<GetProfessionalsDto>>;

public class GetProfessionalsHandler : IRequestHandler<GetProfessionalsQuery, List<GetProfessionalsDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProfessionalsHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

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
