using SD_SE_2.BaseCatalogue.Entities;

namespace SD_SE_2.BaseCatalogue.Observers.Events;

public class CategoryDeletedEvent : DomainEvent
{
    public Category Category { get; }

    public CategoryDeletedEvent(Category category)
    {
        Category = category;
    }
}