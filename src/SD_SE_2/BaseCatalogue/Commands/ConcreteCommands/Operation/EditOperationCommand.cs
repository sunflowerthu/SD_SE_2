using SD_SE_2.BaseCatalogue.Commands.Interfaces;
using SD_SE_2.BaseCatalogue.Entities;
using SD_SE_2.Domain.Services.Interfaces;

namespace SD_SE_2.BaseCatalogue.Commands.ConcreteCommands;

public class EditOperationCommand : ICommand
{
    private readonly Operation _oldOperation;
    private readonly Operation _newOperation;
    private readonly IOperationService _operationService;
    private bool _executed = false;

    public string Description => $"Edit operation: {_oldOperation.Description} -> {_newOperation.Description}";

    public EditOperationCommand(Operation oldOperation, Operation newOperation, IOperationService operationService)
    {
        _oldOperation = oldOperation;
        _newOperation = newOperation;
        _operationService = operationService;
    }

    public void Execute()
    {
        if (!_executed)
        {
            _operationService.UpdateOperation(_newOperation);
            _executed = true;
            Console.WriteLine($"[COMMAND] Operation edited: {_oldOperation.Description} -> {_newOperation.Description}");
        }
    }

    public void Undo()
    {
        if (_executed)
        {
            _operationService.UpdateOperation(_oldOperation);
            _executed = false;
            Console.WriteLine($"[COMMAND] Operation edit undone: {_newOperation.Description} -> {_oldOperation.Description}");
        }
    }
}