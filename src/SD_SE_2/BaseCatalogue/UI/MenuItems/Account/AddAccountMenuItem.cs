using SD_SE_2.Domain.UI.MenuDirectory;
using SD_SE_2.Facades;

namespace SD_SE_2.Domain.UI.MenuItems;

public class AddAccountMenuItem(IAccountFacade accountFacade) : IMenuItem
{
    public string Title { get; } = "Create Account";

    public void Select()
    {
        try
        {
            string name;
            while (true)
            {
                Console.WriteLine("Enter account name: ");
                name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                    break;
                Console.WriteLine("Account name cannot be empty.");
            }

            decimal initialBalance;
            while (true)
            {
                Console.WriteLine("Enter initial balance: ");
                string balanceInput = Console.ReadLine();
                if (decimal.TryParse(balanceInput, out initialBalance) && initialBalance >= 0)
                    break;
                Console.WriteLine("Invalid balance. Please enter a non-negative number.");
            }

            accountFacade.CreateAccount(name, initialBalance);
            Console.WriteLine("Account successfully created!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating account: {ex.Message}");
        }
    }
}