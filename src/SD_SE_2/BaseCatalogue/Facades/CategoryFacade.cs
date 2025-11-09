using SD_SE_2.BaseCatalogue.Commands.ConcreteCommands;
using SD_SE_2.BaseCatalogue.Commands.ConcreteCommands.Category;
using SD_SE_2.BaseCatalogue.Commands.Interfaces;
using SD_SE_2.BaseCatalogue.Entities;
using SD_SE_2.BaseCatalogue.Enums;
using SD_SE_2.BaseCatalogue.Facades.Interfaces;
using SD_SE_2.BaseCatalogue.Factories.Interfaces;
using SD_SE_2.BaseCatalogue.Services.Interfaces;

namespace SD_SE_2.BaseCatalogue.Facades;

public class CategoryFacade(
    ICategoryService categoryService,
    ICategoryFactory categoryFactory,
    ICommandManager commandManager
    ) : ICategoryFacade
{
    public void CreateCategory(string name, CategoryType categoryType)
    {
        var category = categoryFactory.CreateCategory(name, categoryType);
        var addCategoryCommand = new AddCategoryCommand(category, categoryService);
        commandManager.ExecuteCommand(addCategoryCommand);
    }
    
    public void DeleteCategory(Guid categoryId)
    {
        var category = categoryService.GetCategoryById(categoryId);
        if (category == null)
        {
            throw new ArgumentException($"Category with ID {categoryId} not found");
        }

        var deleteCommand = new DeleteCategoryCommand(category, categoryService);
        commandManager.ExecuteCommand(deleteCommand);
    }
    
    public void EditCategory(Guid categoryId, string newName = null, CategoryType? newType = null)
    {
        var oldCategory = categoryService.GetCategoryById(categoryId);
        if (oldCategory == null)
        {
            throw new ArgumentException($"Category with ID {categoryId} not found");
        }

        var newCategory = new Category
        {
            Id = oldCategory.Id,
            Name = newName ?? oldCategory.Name,
            Type = newType ?? oldCategory.Type,
        };

        var editCommand = new EditCategoryCommand(oldCategory, newCategory, categoryService);
        commandManager.ExecuteCommand(editCommand);
    }
    
    public IEnumerable<Category> GetAllCategories()
    {
        return categoryService.GetAllCategories();
    }
}