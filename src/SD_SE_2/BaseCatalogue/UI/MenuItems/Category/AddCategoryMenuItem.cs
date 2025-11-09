using SD_SE_2.BaseCatalogue.Enums;
using SD_SE_2.BaseCatalogue.Facades.Interfaces;
using SD_SE_2.BaseCatalogue.UI.MenuUtility;

namespace SD_SE_2.BaseCatalogue.UI.MenuItems.Category;

public class AddCategoryMenuItem(ICategoryFacade categoryFacade) : IMenuItem
{
    public string Title { get; } = "Add Category";

    public void Select()
    {
        try
        {
            // Ввод названия категории
            string name;
            while (true)
            {
                Console.WriteLine("Enter category name: ");
                name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                    break;
                Console.WriteLine("Category name cannot be empty.");
            }

            CategoryType categoryType;
            while (true)
            {
                Console.WriteLine("Enter category type (Income/Expense): ");
                string typeInput = Console.ReadLine();
                if (Enum.TryParse<CategoryType>(typeInput, true, out categoryType))
                    break;
                Console.WriteLine("Invalid category type. Please try again.");
            }

            categoryFacade.CreateCategory(name, categoryType);
            Console.WriteLine("Category successfully created!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating category: {ex.Message}");
        }
    }
}