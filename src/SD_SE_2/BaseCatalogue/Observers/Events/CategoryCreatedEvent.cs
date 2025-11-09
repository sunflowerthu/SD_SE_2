using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Observers.Events;

public class CategoryCreatedEvent : DomainEvent
{
    public Category Category { get; }

    public CategoryCreatedEvent(Category category)
    {
        Category = category;
    }
}
