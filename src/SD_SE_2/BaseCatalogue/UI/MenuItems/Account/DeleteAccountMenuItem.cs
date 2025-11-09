using SD_SE_2.BaseCatalogue.Facades.Interfaces;
using SD_SE_2.BaseCatalogue.UI.MenuUtility;

namespace SD_SE_2.BaseCatalogue.UI.MenuItems.Account;

public class DeleteAccountMenuItem(IAccountFacade accountFacade) : IMenuItem
{
    public string Title { get; } = "Delete Account";

    public void Select()
    {
        try
        {
            Console.WriteLine("Enter account ID to delete: ");
            Guid accountId = Guid.Parse(Console.ReadLine());

            accountFacade.DeleteAccount(accountId);
            Console.WriteLine("Account deletion command executed!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid account ID format.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting account: {ex.Message}");
        }
    }
}