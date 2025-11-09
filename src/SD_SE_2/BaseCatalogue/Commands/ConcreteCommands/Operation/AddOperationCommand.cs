using SD_SE_2.BaseCatalogue.Commands.Interfaces;
using SD_SE_2.BaseCatalogue.Entities;
using SD_SE_2.BaseCatalogue.Services.Interfaces;

namespace SD_SE_2.BaseCatalogue.Commands.ConcreteCommands;

public class AddOperationCommand : ICommand
{
    private readonly Operation _operation;
    private readonly IOperationService _operationService;
    private bool _executed = false;

    public string Description => $"Add operation: {_operation.Description}";

    public AddOperationCommand(Operation operation, IOperationService operationService)
    {
        _operation = operation;
        _operationService = operationService;
    }

    public void Execute()
    {
        if (!_executed)
        {
            _operationService.AddOperation(_operation);
            _executed = true;
        }
    }

    public void Undo()
    {
        if (_executed)
        {
            _operationService.DeleteOperation(_operation);
            _executed = false;
        }
    }
}