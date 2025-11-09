using SD_SE_2.BaseCatalogue.Enums;
using SD_SE_2.BaseCatalogue.Facades.Interfaces;
using SD_SE_2.BaseCatalogue.UI.MenuUtility;

namespace SD_SE_2.BaseCatalogue.UI.MenuItems.Category;

public class EditCategoryMenuItem(ICategoryFacade categoryFacade) : IMenuItem
{
    public string Title { get; } = "Edit Category";

    public void Select()
    {
        try
        {
            Console.WriteLine("Enter category ID to edit: ");
            Guid categoryId = Guid.Parse(Console.ReadLine());

            Console.WriteLine("Enter new category name (press Enter to keep current): ");
            string newName = Console.ReadLine();
            if (string.IsNullOrEmpty(newName))
            {
                newName = null;
            }

            CategoryType? newType = null;
            Console.WriteLine("Enter new category type (Income/Expense, press Enter to keep current): ");
            string typeInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(typeInput))
            {
                if (Enum.TryParse<CategoryType>(typeInput, true, out CategoryType parsedType))
                {
                    newType = parsedType;
                }
                else
                {
                    Console.WriteLine("Invalid category type. Keeping current type.");
                }
            }

            categoryFacade.EditCategory(categoryId, newName, newType);
            Console.WriteLine("Category successfully updated!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid category ID format.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error editing category: {ex.Message}");
        }
    }
}