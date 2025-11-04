using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Repositories;
using SD_SE_2.Domain.Services;

namespace SD_SE_2.Domain.Commands;

public class AddOperationCommand : ICommand
{
    private readonly Operation _operation;
    private readonly IFinancialService _financialService;
    private readonly OperationRepository _operationRepository;
    private bool _executed = false;

    public string Description => $"Add operation: {_operation.Description}";

    public AddOperationCommand(Operation operation, IFinancialService financialService, OperationRepository operationRepository)
    {
        _operation = operation;
        _financialService = financialService;
        _operationRepository = operationRepository;
    }

    public void Execute()
    {
        if (!_executed)
        {
            _financialService.AddOperation(_operation);
            _executed = true;
        }
    }

    public void Undo()
    {
        if (_executed)
        {
            _financialService.DeleteOperation(_operation.Id);
            _executed = false;
        }
    }
}