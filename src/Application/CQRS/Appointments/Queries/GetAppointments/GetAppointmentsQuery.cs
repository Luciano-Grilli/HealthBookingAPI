using HealthBookingAPI.Application.Common.Interfaces;

namespace HealthBookingAPI.Application.CQRS.Appointments.Queries.GetAppointments;

public class GetAppointmentsQuery : IRequest<List<GetAppointmentsDto>>;

public class GetAppointmentsHandler(IApplicationDbContext _context, IMapper _mapper) : IRequestHandler<GetAppointmentsQuery, List<GetAppointmentsDto>>
{
    public async Task<List<GetAppointmentsDto>> Handle(GetAppointmentsQuery request, CancellationToken cancellationToken)
    {
        var Lists = await _context.Appointments
                .Include(x => x.Professional)
                .AsNoTracking()
                .ProjectTo<GetAppointmentsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

        return Lists;
    }
}
