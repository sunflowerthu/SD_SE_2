using SD_SE_2.Domain.Enums;
using SD_SE_2.Domain.UI.MenuDirectory;
using SD_SE_2.Facades;

namespace SD_SE_2.BaseCatalogue.UI.MenuItems;

public class EditOperationMenuItem(IOperationFacade operationFacade) : IMenuItem
{
    public string Title { get; } = "Edit Operation";

    public void Select()
    {
        try
        {
            Console.WriteLine("Enter operation ID to edit: ");
            Guid operationId = Guid.Parse(Console.ReadLine());

            OperationType newType;
            while (true)
            {
                Console.WriteLine("Enter new operation type (Income/Expense): ");
                string typeInput = Console.ReadLine();
                if (Enum.TryParse<OperationType>(typeInput, true, out newType))
                    break;
                Console.WriteLine("Invalid operation type. Please try again.");
            }

            decimal newAmount;
            while (true)
            {
                Console.WriteLine("Enter new amount: ");
                string amountInput = Console.ReadLine();
                if (decimal.TryParse(amountInput, out newAmount) && newAmount > 0)
                    break;
                Console.WriteLine("Invalid amount. Please enter a positive number.");
            }

            Guid newCategoryId;
            while (true)
            {
                Console.WriteLine("Enter new category ID: ");
                string categoryInput = Console.ReadLine();
                if (Guid.TryParse(categoryInput, out newCategoryId))
                    break;
                Console.WriteLine("Invalid category ID format. Please try again.");
            }

            Console.WriteLine("Enter new description: ");
            string newDescription = Console.ReadLine();

            operationFacade.EditOperation(operationId, newType, newAmount, newCategoryId, newDescription);
            Console.WriteLine("Operation successfully updated!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input format.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error editing operation: {ex.Message}");
        }
    }
}