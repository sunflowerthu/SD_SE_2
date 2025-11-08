using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Enums;
using SD_SE_2.Domain.Observers.Events;
using SD_SE_2.Domain.Observers.Publisher;
using SD_SE_2.Domain.Repositories;
using SD_SE_2.Domain.Services.Interfaces;

namespace SD_SE_2.Domain.Services;

public class CategoryService(
    ICategoryRepository categoryRepository, 
    IEventPublisher eventPublisher)
: ICategoryService
{
    public void AddCategory(Category category)
    {
        categoryRepository.Add(category);
        eventPublisher.Publish(new CategoryCreatedEvent(category));
    }

    public void UpdateCategory(Category category)
    {
        var oldCategory = categoryRepository.GetById(category.Id);
        if (oldCategory != null)
        {
            categoryRepository.Update(category);
            
            eventPublisher.Publish(new CategoryUpdatedEvent(oldCategory, category));
        }
        else
        {
            throw new NullReferenceException("Category not found");
        }
        
    }

    public void DeleteCategory(Category category)
    {
        var categoryExists = categoryRepository.GetById(category.Id);
        if (categoryExists != null)
        {
            categoryRepository.Delete(category.Id);
            
            eventPublisher.Publish(new CategoryDeletedEvent(category));
        }
        
    }
}