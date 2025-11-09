using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Enums;

namespace SD_SE_2.Domain.Repositories;

public interface IOperationRepository : IRepository<Operation>
{
    List<Operation> GetByAccountId(Guid accountId);
    List<Operation> GetByCategoryId(Guid categoryId);
    List<Operation> GetByPeriod(DateTime startDate, DateTime endDate);
    List<Operation> GetByType(OperationType type);
    List<Operation> GetIncomeOperations();
    List<Operation> GetExpenseOperations();
    decimal GetTotalIncome(DateTime? startDate = null, DateTime? endDate = null);
    decimal GetTotalExpense(DateTime? startDate = null, DateTime? endDate = null);
    Dictionary<Guid, decimal> GetCategoryTotals(DateTime? startDate = null, DateTime? endDate = null);
}