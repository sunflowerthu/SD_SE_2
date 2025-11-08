using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Enums;

namespace SD_SE_2.Domain.Repositories;

public class OperationRepository : BaseRepository<Operation>, IOperationRepository
{
    public OperationRepository() : base("Operation") { }

    protected override string GetEntityDisplayName(Operation entity)
    {
        return $"{entity.Description} - {entity.Amount:C}";
    }

    public List<Operation> GetByAccountId(Guid accountId)
    {
        return Find(o => o.AccountId == accountId);
    }

    public List<Operation> GetByCategoryId(Guid categoryId)
    {
        return Find(o => o.CategoryId == categoryId);
    }

    public List<Operation> GetByPeriod(DateTime startDate, DateTime endDate)
    {
        return Find(o => o.Date >= startDate && o.Date <= endDate);
    }

    public List<Operation> GetByType(OperationType type)
    {
        return Find(o => o.Type == type);
    }

    public List<Operation> GetIncomeOperations() => GetByType(OperationType.Income);
    public List<Operation> GetExpenseOperations() => GetByType(OperationType.Expense);

    public decimal GetTotalIncome(DateTime? startDate = null, DateTime? endDate = null)
    {
        var incomeOperations = GetIncomeOperations();
        
        if (startDate.HasValue && endDate.HasValue)
        {
            incomeOperations = incomeOperations.Where(o => o.Date >= startDate && o.Date <= endDate).ToList();
        }
        
        return incomeOperations.Sum(o => o.Amount);
    }

    public decimal GetTotalExpense(DateTime? startDate = null, DateTime? endDate = null)
    {
        var expenseOperations = GetExpenseOperations();
        
        if (startDate.HasValue && endDate.HasValue)
        {
            expenseOperations = expenseOperations.Where(o => o.Date >= startDate && o.Date <= endDate).ToList();
        }
        
        return expenseOperations.Sum(o => o.Amount);
    }

    public Dictionary<Guid, decimal> GetCategoryTotals(DateTime? startDate = null, DateTime? endDate = null)
    {
        var operations = GetAll();
        
        if (startDate.HasValue && endDate.HasValue)
        {
            operations = operations.Where(o => o.Date >= startDate && o.Date <= endDate).ToList();
        }

        return operations
            .GroupBy(o => o.CategoryId)
            .ToDictionary(g => g.Key, g => g.Sum(o => o.Amount));
    }
}