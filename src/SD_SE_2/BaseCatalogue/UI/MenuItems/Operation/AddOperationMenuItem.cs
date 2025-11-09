using SD_SE_2.BaseCatalogue.Enums;
using SD_SE_2.BaseCatalogue.Facades.Interfaces;
using SD_SE_2.BaseCatalogue.UI.MenuUtility;

namespace SD_SE_2.BaseCatalogue.UI.MenuItems.Operation;

public class AddOperationMenuItem(
    IOperationFacade operationFacade
) : IMenuItem
{
    public string Title { get; } = "Add Operation";

    public void Select()
    {
        try
        {
            OperationType type;
            while (true)
            {
                Console.WriteLine("Enter operation type: Income, Expense");
                string typeInput = Console.ReadLine();
                if (Enum.TryParse<OperationType>(typeInput, true, out type))
                    break;
                Console.WriteLine("Invalid operation type. Please try again.");
            }

            Guid accountId;
            while (true)
            {
                Console.WriteLine("Enter unique bank account ID: ");
                string accountInput = Console.ReadLine();
                if (Guid.TryParse(accountInput, out accountId))
                    break;
                Console.WriteLine("Invalid ID format. Please try again.");
            }

            decimal amount;
            while (true)
            {
                Console.WriteLine("Enter operation amount: ");
                string amountInput = Console.ReadLine();
                if (decimal.TryParse(amountInput, out amount) && amount > 0)
                    break;
                Console.WriteLine("Invalid amount. Please enter a positive number.");
            }

            Guid categoryId;
            while (true)
            {
                Console.WriteLine("Enter category ID: ");
                string categoryInput = Console.ReadLine();
                if (Guid.TryParse(categoryInput, out categoryId))
                    break;
                Console.WriteLine("Invalid category ID format. Please try again.");
            }

            string description;
            while (true)
            {
                Console.WriteLine("Enter operation description:");
                description = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(description))
                    break;
                Console.WriteLine("Description cannot be empty.");
            }

            operationFacade.CreateOperation(type, accountId, amount, categoryId, description);

            Console.WriteLine("Operation successfully created!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating operation: {ex.Message}");
        }
    }
}