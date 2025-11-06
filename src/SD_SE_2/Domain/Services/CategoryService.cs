using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Enums;
using SD_SE_2.Domain.Observers.Events;
using SD_SE_2.Domain.Observers.Publisher;
using SD_SE_2.Domain.Repositories;

namespace SD_SE_2.Domain.Services;

public class CategoryService
{
    private readonly CategoryRepository _categoryRepository;
    private readonly IEventPublisher _eventPublisher;

    public CategoryService(CategoryRepository categoryRepository, IEventPublisher eventPublisher)
    {
        _categoryRepository = categoryRepository;
        _eventPublisher = eventPublisher;
    }

    public void CreateCategory(string name, CategoryType type)
    {
        // и сюда фабрику, хз как то надо по красоте сделать
        var category = new Category(name, type);
        _categoryRepository.Add(category);
        
        _eventPublisher.Publish(new CategoryCreatedEvent(category));
    }

    public void UpdateCategory(Category category)
    {
        _categoryRepository.Update(category);
    }

    public void DeleteCategory(Guid categoryId)
    {
        _categoryRepository.Delete(categoryId);
    }
}