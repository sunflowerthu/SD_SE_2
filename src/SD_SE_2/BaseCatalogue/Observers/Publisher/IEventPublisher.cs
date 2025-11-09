namespace SD_SE_2.BaseCatalogue.Observers.Publisher;

public interface IEventPublisher
{
    void Subscribe<TEvent>(Action<TEvent> handler);
    void Unsubscribe<TEvent>(Action<TEvent> handler);
    void Publish<TEvent>(TEvent myEvent);
}