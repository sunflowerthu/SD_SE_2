using SD_SE_2.Domain.Commands;
using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Services.Interfaces;

namespace SD_SE_2.BaseCatalogue.Commands.ConcreteCommands;

public class AddCategoryCommand : ICommand
{
    private readonly Category _category;
    private readonly ICategoryService _categoryService;
    private bool _executed = false;

    public string Description => $"Add category: {_category.Name}";

    public AddCategoryCommand(Category category, ICategoryService categoryServiceService)
    {
        _category = category;
        _categoryService = categoryServiceService;
    }

    public void Execute()
    {
        if (!_executed)
        {
            _categoryService.AddCategory(_category);
            _executed = true;
        }
    }

    public void Undo()
    {
        if (_executed)
        {
            _categoryService.DeleteCategory(_category);
            _executed = false;
        }
    }
}