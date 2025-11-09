using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Observers.Events;

public class CategoryUpdatedEvent : DomainEvent
{
    public Category OldCategory { get; }
    public Category NewCategory { get; }

    public CategoryUpdatedEvent(Category oldCategory, Category newCategory)
    {
        OldCategory = oldCategory;
        NewCategory = newCategory;
    }
}