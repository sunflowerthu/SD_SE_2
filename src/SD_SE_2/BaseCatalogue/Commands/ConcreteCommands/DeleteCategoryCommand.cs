using SD_SE_2.Domain.Commands;
using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Services.Interfaces;

namespace SD_SE_2.BaseCatalogue.Commands.ConcreteCommands;

public class DeleteCategoryCommand : ICommand   
{
    private readonly Category _category;
    private readonly ICategoryService _operationService;
    private bool _executed = false;

    public string Description => $"Delete category: {_category.Name}";
    
    public DeleteCategoryCommand(Category category, ICategoryService categoryService)
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
            Console.WriteLine($"[COMMAND] Operation deleted: {_category.Name}");
        }
    }

    public void Undo()
    {
        if (_executed)
        {
            _operationService.AddCategory(_category);
            _executed = false;
            Console.WriteLine($"[COMMAND] Operation deletion undone: {_category.Name}");
        }
    }
}