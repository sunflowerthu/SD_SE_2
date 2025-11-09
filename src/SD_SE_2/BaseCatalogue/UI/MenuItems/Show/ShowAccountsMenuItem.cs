using SD_SE_2.BaseCatalogue.Facades.Interfaces;
using SD_SE_2.BaseCatalogue.UI.MenuUtility;

namespace SD_SE_2.BaseCatalogue.UI.MenuItems.Show;

public class ShowAccountsMenuItem(IAccountFacade accountFacade) : IMenuItem
{
    public string Title { get; } = "Show all bank accounts";

    public void Select()
    {
        try
        {
            var accounts = accountFacade.GetAllAccounts();
            
            if (!accounts.Any())
            {
                Console.WriteLine("No accounts found.");
                return;
            }

            Console.WriteLine("\n=== ACCOUNTS LIST ===");
            Console.WriteLine("ID | Name | Balance | Status");
            Console.WriteLine("----------------------------------------");
            
            foreach (var account in accounts)
            {
                string status = account.IsActive ? "Active" : "Inactive";
                Console.WriteLine($"{account.Id} | {account.Name} | {account.Balance:C} | {status}");
            }
            
            Console.WriteLine($"\nTotal accounts: {accounts.Count()}");
            Console.WriteLine($"Total balance: {accounts.Sum(a => a.Balance):C}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error listing accounts: {ex.Message}");
        }
    }
}