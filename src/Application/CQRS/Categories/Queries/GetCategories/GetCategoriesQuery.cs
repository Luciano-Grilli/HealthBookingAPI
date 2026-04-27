using HealthBookingAPI.Application.Common.Interfaces;

namespace HealthBookingAPI.Application.CQRS.Categories.Queries.GetCategories;

public class GetCategoriesQuery : IRequest<List<GetCategoriesDto>>;

public class GetCategoriesHandler(IApplicationDbContext _context, IMapper _mapper) : IRequestHandler<GetCategoriesQuery, List<GetCategoriesDto>>
{
    public async Task<List<GetCategoriesDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var Lists = await _context.Categories
                .AsNoTracking()
                .ProjectTo<GetCategoriesDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

        return Lists;
    }
}
