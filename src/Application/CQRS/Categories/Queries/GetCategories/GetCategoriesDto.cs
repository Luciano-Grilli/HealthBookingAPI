namespace HealthBookingAPI.Application.CQRS.Categories.Queries.GetCategories;

public class GetCategoriesDto
{
    public string Description { get; set; } = string.Empty;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.Categories, GetCategoriesDto>();
        }
    }
}
