using SD_SE_2.BaseCatalogue.Facades.Interfaces;
using SD_SE_2.BaseCatalogue.UI.MenuUtility;

namespace SD_SE_2.BaseCatalogue.UI.MenuItems.Account;

public class EditAccountMenuItem : IMenuItem
{
    private readonly IAccountFacade _accountFacade;
    
    public string Title { get; } = "Edit Account";

    public EditAccountMenuItem(IAccountFacade accountFacade)
    {
        _accountFacade = accountFacade;
    }

    public void Select()
    {
        try
        {
            Console.WriteLine("Enter account ID to edit: ");
            Guid accountId = Guid.Parse(Console.ReadLine());

            Console.WriteLine("Enter new account name (press Enter to keep current): ");
            string newName = Console.ReadLine();
            if (string.IsNullOrEmpty(newName))
                newName = null;

            decimal? newBalance = null;
            Console.WriteLine("Enter new balance (press Enter to keep current): ");
            string balanceInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(balanceInput))
            {
                if (decimal.TryParse(balanceInput, out decimal balance) && balance >= 0)
                    newBalance = balance;
                else
                    Console.WriteLine("Invalid balance. Keeping current balance.");
            }

            _accountFacade.EditAccount(accountId, newName, newBalance);
            Console.WriteLine("Account successfully updated!");
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
            Console.WriteLine($"Error editing account: {ex.Message}");
        }
    }
}