using SD_SE_2.BaseCatalogue.Commands.Interfaces;
using SD_SE_2.BaseCatalogue.Services.Interfaces;

namespace SD_SE_2.BaseCatalogue.Commands.ConcreteCommands.Category;

public class AddCategoryCommand : ICommand
{
    private readonly Entities.Category _category;
    private readonly ICategoryService _categoryService;
    private bool _executed = false;

    public string Description => $"Add category: {_category.Name}";

    public AddCategoryCommand(Entities.Category category, ICategoryService categoryServiceService)
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