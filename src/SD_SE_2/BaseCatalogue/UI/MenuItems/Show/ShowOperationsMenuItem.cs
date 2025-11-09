using SD_SE_2.Domain.Enums;
using SD_SE_2.Domain.UI.MenuDirectory;
using SD_SE_2.Facades;

namespace SD_SE_2.Domain.UI.MenuItems;

public class ShowOperationsMenuItem(IOperationFacade operationFacade) : IMenuItem
{
    public string Title { get; } = "Show all operations";

    public void Select()
    {
        try
        {
            var operations = operationFacade.GetAllOperations();
            
            if (!operations.Any())
            {
                Console.WriteLine("No operations found.");
                return;
            }

            Console.WriteLine("\n=== OPERATIONS LIST ===");
            Console.WriteLine("ID | Date | Type | Amount | Description | Account ID | Category ID");
            Console.WriteLine("-------------------------------------------------------------------");
            
            foreach (var operation in operations.OrderByDescending(o => o.Date))
            {
                Console.WriteLine($"{operation.Id} | {operation.Date:yyyy-MM-dd} | {operation.Type} | {operation.Amount:C} | {operation.Description} | {operation.AccountId} | {operation.CategoryId}");
            }
            
            var totalIncome = operations.Where(o => o.Type == OperationType.Income).Sum(o => o.Amount);
            var totalExpense = operations.Where(o => o.Type == OperationType.Expense).Sum(o => o.Amount);
            
            Console.WriteLine($"\nTotal operations: {operations.Count()}");
            Console.WriteLine($"Total income: {totalIncome:C}");
            Console.WriteLine($"Total expense: {totalExpense:C}");
            Console.WriteLine($"Balance: {totalIncome - totalExpense:C}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error listing operations: {ex.Message}");
        }
    }
}