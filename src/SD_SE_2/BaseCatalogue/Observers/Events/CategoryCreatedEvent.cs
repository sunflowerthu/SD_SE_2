using SD_SE_2.BaseCatalogue.Entities;

namespace SD_SE_2.BaseCatalogue.Observers.Events;

public class CategoryCreatedEvent : DomainEvent
{
    public Category Category { get; }

    public CategoryCreatedEvent(Category category)
    {
        Category = category;
    }
}
