using SD_SE_2.Domain.Enums;
using SD_SE_2.Domain.UI.MenuDirectory;
using SD_SE_2.Facades;

namespace SD_SE_2.BaseCatalogue.UI.MenuItems.Show;

public class ShowCategoriesMenuItem(ICategoryFacade categoryFacade) : IMenuItem
{
    public string Title { get; } = "Show all categories";

    public void Select()
    {
        try
        {
            var categories = categoryFacade.GetAllCategories();
            
            if (!categories.Any())
            {
                Console.WriteLine("No categories found.");
                return;
            }

            Console.WriteLine("\n=== CATEGORIES LIST ===");
            Console.WriteLine("ID | Name | Type");
            Console.WriteLine("--------------------------");
            
            foreach (var category in categories.OrderBy(c => c.Type).ThenBy(c => c.Name))
            {
                Console.WriteLine($"{category.Id} | {category.Name} | {category.Type}");
            }
            
            var incomeCount = categories.Count(c => c.Type == CategoryType.Income);
            var expenseCount = categories.Count(c => c.Type == CategoryType.Expense);
            
            Console.WriteLine($"\nTotal categories: {categories.Count()}");
            Console.WriteLine($"Income categories: {incomeCount}");
            Console.WriteLine($"Expense categories: {expenseCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error listing categories: {ex.Message}");
        }
    }
}
