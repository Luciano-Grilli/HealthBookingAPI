
namespace HealthBookingAPI.Domain.Events;

public class ProfessionalsCompletedEvent : BaseEvent
{
    public ProfessionalsCompletedEvent(Professionals item)
    {
        Item = item;
    }

    public Professionals Item { get; }
}
