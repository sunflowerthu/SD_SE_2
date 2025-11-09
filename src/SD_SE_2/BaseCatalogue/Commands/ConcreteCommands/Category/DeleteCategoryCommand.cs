using SD_SE_2.BaseCatalogue.Commands.Interfaces;
using SD_SE_2.BaseCatalogue.Services.Interfaces;

namespace SD_SE_2.BaseCatalogue.Commands.ConcreteCommands.Category;

public class DeleteCategoryCommand : ICommand   
{
    private readonly Entities.Category _category;
    private readonly ICategoryService _operationService;
    private bool _executed = false;

    public string Description => $"Delete category: {_category.Name}";
    
    public DeleteCategoryCommand(Entities.Category category, ICategoryService categoryService)
    {
        _category = category;
        _operationService = categoryService;
    }

    public void Execute()
    {
        if (!_executed)
        {
            _operationService.DeleteCategory(_category);
            _executed = true;
            Console.WriteLine($"[COMMAND] Category deleted: {_category.Name}");
        }
    }

    public void Undo()
    {
        if (_executed)
        {
            _operationService.AddCategory(_category);
            _executed = false;
            Console.WriteLine($"[COMMAND] Category deletion undone: {_category.Name}");
        }
    }
}