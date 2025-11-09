namespace SD_SE_2.Domain.Observers.Publisher;

public class EventPublisher : IEventPublisher
{
    private readonly Dictionary<Type, List<object>> _subscribers = new();

    public void Subscribe<TEvent>(Action<TEvent> handler)
    {
        var eventType = typeof(TEvent);
        if (!_subscribers.ContainsKey(eventType))
        {
            _subscribers[eventType] = new List<object>();
        }
        
        _subscribers[eventType].Add(handler);
    }

    public void Unsubscribe<TEvent>(Action<TEvent> handler)
    {
        var eventType = typeof(TEvent);
        if (_subscribers.ContainsKey(eventType))
        {
            _subscribers[eventType].Remove(handler);
        }
    }

    public void Publish<TEvent>(TEvent myEvent)
    {
        var eventType = typeof(TEvent);
        if (_subscribers.ContainsKey(eventType))
        {
            foreach (var subscriber in _subscribers[eventType].ToList())
            {
                var handler = (Action<TEvent>)subscriber;
                handler(myEvent);
            }
        }
    }
}