using SD_SE_2.BaseCatalogue.Commands.Interfaces;
using SD_SE_2.BaseCatalogue.Services.Interfaces;

namespace SD_SE_2.BaseCatalogue.Commands.ConcreteCommands.Category;

public class EditCategoryCommand : ICommand
{
    private readonly Entities.Category _oldCategory;
    private readonly Entities.Category _newCategory;
    private readonly ICategoryService _categoryService;
    private bool _executed = false;

    public string Description => $"Edit category: {_oldCategory.Name} -> {_newCategory.Name}";

    public EditCategoryCommand(Entities.Category oldCategory, Entities.Category newCategory, ICategoryService categoryService)
    {
        _oldCategory = oldCategory;
        _newCategory = newCategory;
        _categoryService = categoryService;
    }

    public void Execute()
    {
        if (!_executed)
        {
            _categoryService.UpdateCategory(_newCategory);
            _executed = true;
            Console.WriteLine($"[COMMAND] Category edited: {_oldCategory.Name} -> {_newCategory.Name}");
        }
    }

    public void Undo()
    {
        if (_executed)
        {
            _categoryService.UpdateCategory(_oldCategory);
            _executed = false;
            Console.WriteLine($"[COMMAND] Category edit undone: {_newCategory.Name} -> {_oldCategory.Name}");
        }
    }
}