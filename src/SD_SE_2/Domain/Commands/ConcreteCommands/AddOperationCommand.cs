using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Repositories;
using SD_SE_2.Domain.Services;
using SD_SE_2.Domain.Services.Interfaces;

namespace SD_SE_2.Domain.Commands;

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
            _operationService.DeleteOperation(_operation.Id);
            _executed = false;
        }
    }
}