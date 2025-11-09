using SD_SE_2.BaseCatalogue.Facades.Interfaces;
using SD_SE_2.BaseCatalogue.UI.MenuUtility;

namespace SD_SE_2.BaseCatalogue.UI.MenuItems.Operation;

public class DeleteOperationMenuItem(IOperationFacade operationFacade) : IMenuItem
{
    public string Title { get; } = "Delete Operation";
    public void Select()
    {
        try
        {
            Console.WriteLine("Enter operation ID to delete: ");
            Guid operationId = Guid.Parse(Console.ReadLine());

            operationFacade.DeleteOperation(operationId);
            Console.WriteLine("Operation deletion command executed!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid operation ID format.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting operation: {ex.Message}");
        }
    }
}