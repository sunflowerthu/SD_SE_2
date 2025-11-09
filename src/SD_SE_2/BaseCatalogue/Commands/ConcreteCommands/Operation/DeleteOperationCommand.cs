using SD_SE_2.BaseCatalogue.Commands.Interfaces;
using SD_SE_2.BaseCatalogue.Entities;
using SD_SE_2.BaseCatalogue.Services.Interfaces;

namespace SD_SE_2.BaseCatalogue.Commands.ConcreteCommands;

public class DeleteOperationCommand : ICommand
{
    private readonly Operation _operation;
    private readonly IOperationService _operationService;
    private bool _executed = false;

    public string Description => $"Delete operation: {_operation.Description}";
    
    public DeleteOperationCommand(Operation operation, IOperationService operationService)
    {
        _operation = operation;
        _operationService = operationService;
    }

    public void Execute()
    {
        if (!_executed)
        {
            _operationService.DeleteOperation(_operation);
            _executed = true;
            Console.WriteLine($"[COMMAND] Operation deleted: {_operation.Description}");
        }
    }

    public void Undo()
    {
        if (_executed)
        {
            _operationService.AddOperation(_operation);
            _executed = false;
            Console.WriteLine($"[COMMAND] Operation deletion undone: {_operation.Description}");
        }
    }
}