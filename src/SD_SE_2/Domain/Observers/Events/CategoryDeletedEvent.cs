using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Observers.Events;

public class CategoryDeletedEvent : DomainEvent
{
    public Category Category { get; }

    public CategoryDeletedEvent(Category category)
    {
        Category = category;
    }
}