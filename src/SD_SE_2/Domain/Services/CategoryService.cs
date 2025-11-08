using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Enums;
using SD_SE_2.Domain.Observers.Events;
using SD_SE_2.Domain.Observers.Publisher;
using SD_SE_2.Domain.Repositories;

namespace SD_SE_2.Domain.Services;

public class CategoryService(ICategoryRepository categoryRepository, IEventPublisher eventPublisher)
{
    public void CreateCategory(string name, CategoryType type) // TODO: удалить нахуй, сделать по аналогии с CreateOperation
    {
        // и сюда фабрику, хз как то надо по красоте сделать
        var category = new Category(name, type);
        categoryRepository.Add(category);
        
        eventPublisher.Publish(new CategoryCreatedEvent(category));
    }

    public void UpdateCategory(Category category)
    {
        categoryRepository.Update(category);
    }

    public void DeleteCategory(Guid categoryId)
    {
        categoryRepository.Delete(categoryId);
    }
}